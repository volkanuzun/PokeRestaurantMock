using PokeRestaurant.Data.Entity;
///<summary>
/// <Author>Volkan Uzun</Author>
/// <Date>10/04/2023</Date>
///</summary>
namespace PokeRestaurant.Web.Services
{
    public interface IDatabaseRepository
    {
        public IQueryable<PokeRestaurant.Data.Entity.MenuItem> GetMenuItems();
        public Task<int> AddOrder(Order newOrder);
        public Order GetOrderByID(int orderID);
    }
}
