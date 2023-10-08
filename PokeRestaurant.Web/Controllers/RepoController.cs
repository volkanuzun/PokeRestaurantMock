///<summary>
/// <Author>Volkan Uzun</Author>
/// <Date>10/04/2023</Date>
///</summary>
using Microsoft.AspNetCore.Mvc;
using PokeRestaurant.Data.Entity;
using PokeRestaurant.Web.Services;
using System.Text.Json;


namespace PokeRestaurant.Web.Controllers
{
    //this controller should be ideally secured as it does CRUD in the database
    //we should use UN/PWD , IP Restriction, Key authentication etc
    [Route("api/[controller]")]
    [ApiController]
    public class RepoController : ControllerBase
    {
        IDatabaseRepository _databaseRepository;

        public RepoController(IDatabaseRepository databaseRepository)
        {
            this._databaseRepository = databaseRepository;
        }
        // GET: api/<MenuController>
        [HttpGet]
        [ApiVersion("1.0")]
        [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 2400)]
        [Route("Menu")]
        [ProducesResponseType(typeof(IEnumerable<MenuItem>),200)]
        public IEnumerable<MenuItem> Get()
        {
            var items = _databaseRepository.GetMenuItems();
            return items;
        }

        [HttpPost]
        [ApiVersion("1.0")]
        [Route("Checkout")]
        [ProducesResponseType(typeof(int), 200)]
        ///<summary>Returns 0 for no new records; or primary key of the new record</summary>
        public async Task<int> SaveOrder(Order newOrder)
        {

            var result = await _databaseRepository.AddOrder(newOrder);
            return result > 0 ? newOrder.ID : 0;
        }

        [HttpGet]
        [ApiVersion("1.0")]
        [Route("Order")]
        [ProducesResponseType(typeof(Order), 200)]
        public Order OrderByID(int orderID)
        {
            Order order = _databaseRepository.GetOrderByID(orderID);
            return order;
        }
    }
}
