namespace PokeRestaurant.Web.Services
{
    public interface IDatabaseRepository
    {
        public IQueryable<PokeRestaurant.Data.Entity.MenuItem> GetMenuItems();

    }
}
