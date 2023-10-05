///<summary>
/// <Author>Volkan Uzun</Author>
/// <Date>10/04/2023</Date>
///</summary>
using Microsoft.AspNetCore.Mvc;
using PokeRestaurant.Data.Entity;
using PokeRestaurant.Web.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PokeRestaurant.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        IDatabaseRepository _databaseRepository;

        public MenuController(IDatabaseRepository databaseRepository)
        {
            this._databaseRepository = databaseRepository;
        }
        // GET: api/<MenuController>
        [HttpGet]
        [ApiVersion("1.0")]
        [ResponseCache(Location = ResponseCacheLocation.Any,Duration =2400)]
        public IEnumerable<MenuItem> Get()
        {
            var items = _databaseRepository.GetMenuItems();
            return items;
        }

       
    }
}
