///<summary>
/// <Author>Volkan Uzun</Author>
/// <Date>10/04/2023</Date>
///</summary>
using Azure.Core;
using Newtonsoft.Json;
using PokeRestaurant.Data.Entity;
using System.Net.Http.Headers;

namespace PokeRestaurant.Web.Helpers
{
    /// <summary>
    /// As all database access from controllers are through api calls
    /// I put a helper function that can call the API to get the data needed
    /// ideally the uri schema etc should be read from configuration
    /// </summary>
    public class APICallHelper
    {
        private string repoApiUrl;
        private string baseUrl;
        public IHttpContextAccessor HttpContextAccessor { get; }

        public APICallHelper(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
            repoApiUrl = "/api/repo/";
            baseUrl = $"{HttpContextAccessor.HttpContext.Request.Scheme}://{HttpContextAccessor.HttpContext.Request.Host}";
            
        }

        public async Task<List<MenuItem>> GetMenuItems()
        {
            string menuAPIUrl = $"{repoApiUrl}Menu";
            List<MenuItem> items = null;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync(menuAPIUrl);

            if (response.IsSuccessStatusCode)
            {
                items = await response.Content.ReadFromJsonAsync<List<MenuItem>>();
            }

            return items;
        }
    
    
        public async Task<int> SaveOrder(Order order)
        {
            string checkoutAPIUrl = $"{repoApiUrl}Checkout";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            string json = JsonConvert.SerializeObject(order);
            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(checkoutAPIUrl, httpContent);

            if (response.IsSuccessStatusCode)
            {
                int orderID = Int32.Parse(await response.Content.ReadAsStringAsync());
                return orderID;
            }
            return 0;
        }
    
        public async Task<Order>GetOrderByID(int orderID)
        {
            Order order = null;

            string orderUrl = $"{repoApiUrl}Order?orderid={orderID}";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(orderUrl);

            if (response.IsSuccessStatusCode)
            {
                order = await response.Content.ReadFromJsonAsync<Order>();
            }

            return order;
        }
    }
}
