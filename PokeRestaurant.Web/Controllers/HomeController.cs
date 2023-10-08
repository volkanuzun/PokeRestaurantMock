///<summary>
/// <Author>Volkan Uzun</Author>
/// <Date>10/04/2023</Date>
///</summary>
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using PokeRestaurant.Data.Entity;
using PokeRestaurant.Web.Helpers;
using PokeRestaurant.Web.Models;
using PokeRestaurant.Web.Services;
using PokeRestaurant.Web.ViewModels;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace PokeRestaurant.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IMemoryCache _cache;      
        private ShoppingCart _shoppingCart;
        private APICallHelper _apiCall;
        public HomeController(ILogger<HomeController> logger,IMemoryCache _memoryCache,ShoppingCart cart,APICallHelper apiCall)
        {
            _logger = logger;
            this._cache = _memoryCache;    
            this._shoppingCart = cart;
            _apiCall = apiCall;
        }

        private async Task<List<MenuItem>> GetMenuItems()
        {          
            List<MenuItem> items = new List<MenuItem>();
            //check if it is in the cache?
            if (!this._cache.TryGetValue(MenuViewModel.CacheKeyName, out List<MenuItem> menuItems))
            {
                //call api to get menu items and cache the result
                items = await _apiCall.GetMenuItems();
              
                if (items!=null)
                {
                    menuItems = items;
                    //save it in the cache for 1 hour; we could use more than 1 hour as menus dont update too often
                    //cache is configurable, here is distributed in memory cache; but it could be reddis etc
                    _cache.Set<List<MenuItem>>(MenuViewModel.CacheKeyName, items,TimeSpan.FromHours(1));
                }
            }
           
            return menuItems;
        }


        public  async Task<IActionResult> Index()
        {
            MenuViewModel vm = new MenuViewModel();
            
            //read from cache or database; most of the time it should hit the cache as menu items do not change so often
            vm.AllItems = await GetMenuItems();
                     
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Add2Cart(int ID)
        {
            //almost certain this reads from cache; so no database hits here
            var menuItems = await GetMenuItems();

            //we could have use a DTO converter such as automapper; for simplicity manual dto converter
            Add2CartViewModel vm = new Add2CartViewModel();
            vm.ProteinItems = menuItems.Where(c => c.MenuItemType == Data.Abstract.MenuItemType.Protein).Select(c => new ProteinItemSelectionViewModel { IsChecked = false, Name=c.Name,ID=c.ID }).ToList();
            vm.ToppingItems = menuItems.Where(c => c.MenuItemType == Data.Abstract.MenuItemType.Toppings).Select(c => new ToppingItemSelectionViewModel { IsChecked = false, Name=c.Name, ID=c.ID }).ToList();
            vm.SelectedBaseItemName = menuItems.Where(c => c.ID ==ID).Select(c=>c.Name).Single().ToString();
            vm.SelectedBaseItemPrice = menuItems.Where(c => c.ID == ID).Select(c => c.Price).Single();
            vm.SelectedBaseItemID = ID;

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Add2Cart(Add2CartViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
           //TODO: Volkan => Do we need any business logic here; check if items are in stock etc before we render next page?
           //save the items in the cart, which is saved either in distributed memory cache/reddis or sql server depending on the configuration

           //we could use DTO transformer such as automapper here, but skipping for now for simplicity
           _shoppingCart.AddItem(new ShoppingCartLine()
                            { BaseItemName=vm.SelectedBaseItemName,
                              BaseItemPrice=vm.SelectedBaseItemPrice,
                              Toppings = vm.ToppingItems.Where(c=>c.IsChecked==true).Select(c=>c.Name).ToList(),
                              Proteins = vm.ProteinItems.Where(c=>c.IsChecked==true).Select(c=>c.Name).ToList(),
                            });

            //go to shopping cart page, which ideally should be in another controller
            return RedirectToAction(actionName:"Cart",controllerName:"Home");
        }

        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            List<ShoppingCartLine> shoppingItems = _shoppingCart.Items;

            return View(shoppingItems);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}