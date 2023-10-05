///<summary>
/// <Author>Volkan Uzun</Author>
/// <Date>10/04/2023</Date>
///</summary>
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using PokeRestaurant.Data.Entity;
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
        private readonly IDatabaseRepository _databaseRepository;
        private IMemoryCache _cache;
        private string menuAPIUrl;
        private string baseUrl;

        public HomeController(ILogger<HomeController> logger,IDatabaseRepository databaseRepository,IMemoryCache _memoryCache)
        {
            _logger = logger;
            this._databaseRepository = databaseRepository;
            this._cache = _memoryCache;     
           
            menuAPIUrl = "/api/menu";
        }

        private async Task<List<MenuItem>> GetMenuItems()
        {
            List<MenuItem> items = new List<MenuItem>();
            //check if it is in the cache?
            if (!this._cache.TryGetValue(MenuViewModel.CacheKeyName, out List<MenuItem> menuItems))
            {
                baseUrl = $"{Request.Scheme}://{Request.Host}";
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync(menuAPIUrl);
                if (response.IsSuccessStatusCode)
                {
                    menuItems = await response.Content.ReadFromJsonAsync<List<MenuItem>>();
                    _cache.Set<List<MenuItem>>(MenuViewModel.CacheKeyName, menuItems,TimeSpan.FromHours(1));
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

        public async Task<IActionResult> Add2ToCart(int itemID)
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}