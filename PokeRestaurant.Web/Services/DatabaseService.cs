///<summary>
/// <Author>Volkan Uzun</Author>
/// <Date>10/04/2023</Date>
///</summary>
using PokeRestaurant.Data.Entity;

namespace PokeRestaurant.Web.Services
{
    public class DatabaseService : IDatabaseRepository
    {
        private DataContextEF _dataContextEF { get; set; }
        public DatabaseService(DataContextEF dataContextEF)
        { 
            this._dataContextEF = dataContextEF;
        }
        public IQueryable<MenuItem> GetMenuItems()
        {
            return _dataContextEF.MenuItems;
        }
    }
}
