///<summary>
/// <Author>Volkan Uzun</Author>
/// <Date>10/04/2023</Date>
///</summary>
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PokeRestaurant.Data.Entity;
using PokeRestaurant.Web.Helpers;
using PokeRestaurant.Web.ViewModels;
using System.Net.Http.Headers;

namespace PokeRestaurant.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> _logger;
        private IMemoryCache _cache;
        private APICallHelper _apiCall;
        private ShoppingCart _shoppingCart;

        public OrderController(ILogger<OrderController> logger, IMemoryCache _memoryCache, ShoppingCart cart, APICallHelper apiCall)
        {
            _logger = logger;
            this._cache = _memoryCache;
            this._shoppingCart = cart;
            this._apiCall = apiCall;
        }

        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            var items = _shoppingCart.Items;
            OrderViewModel vm = new OrderViewModel();
            vm.Items = items;

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkout(OrderViewModel vm)
        {
            var items = _shoppingCart.Items;
            vm.Items = items;

            bool isValid = TryValidateModel(vm);

            if (!isValid)
            {
                return View(vm);
            }

            //we can use dto mapper here like automapper , for simplicity we skip it
            Order newOrder = new Order()
            {
                DeliveryAddress = vm.DeliveryAddress,
                IsActive = true,
                IsShipped = false,
                Name = vm.Name,
                EmailAddress = vm.EmailAddress,
                DateAddedUTC = DateTime.UtcNow,
                Cart = new ShoppingCart() { Items = vm.Items, DateAddedUTC = DateTime.UtcNow, IsActive = true },
                TotalCost = vm.Items.Sum(c => c.TotalPrice)
            };


            int orderID = await _apiCall.SaveOrder(newOrder);
            return RedirectToAction("OrderComplete", new {id=orderID});

        }


        //ideally this action needs authentication or authorization as it reads from database for a specific order
        public async Task<IActionResult> OrderComplete(int id)
        {
            Order order = await _apiCall.GetOrderByID(id);
            if(order==null)
            {
                //in real life we need to display an error page here
                throw new Exception("No order found");
            }
            //we can use DTO here like automapper for simplicity we skip it
            OrderViewModel vm = new OrderViewModel()
            {
                DeliveryAddress = order.DeliveryAddress,
                EmailAddress = order.EmailAddress,
                Name = order.Name,
                Items = order.Cart.Items
            };

            //dont forget to empty the shopping cart :)
            _shoppingCart.Clear();

            return View(vm);

        }
    }
}
