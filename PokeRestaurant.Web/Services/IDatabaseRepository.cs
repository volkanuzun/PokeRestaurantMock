///<summary>
/// <Author>Volkan Uzun</Author>
/// <Date>10/04/2023</Date>
///</summary>
namespace PokeRestaurant.Web.Services
{
    public interface IDatabaseRepository
    {
        public IQueryable<PokeRestaurant.Data.Entity.MenuItem> GetMenuItems();

    }
}
