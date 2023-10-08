using PokeRestaurant.Data.Entity;

namespace PokeRestaurant.Web.ViewModels
{
    public class OrderViewModel
    {
        public List<ShoppingCartLine>? Items {  get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string DeliveryAddress { get; set; }
        
    }
}
