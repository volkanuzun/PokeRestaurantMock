///<summary>
/// <Author>Volkan Uzun</Author>
/// <Date>10/04/2023</Date>
///</summary>
using Microsoft.EntityFrameworkCore;
using PokeRestaurant.Data.Entity;

namespace PokeRestaurant.Web.Services
{
    /// <summary>
    /// Simple EF Service that implements the database access contract and do the database operations.
    /// It is easy to put a new service that stores the data in cosmos db, or mysql etc as the whole application
    /// relies on the interface contract and API design for database access; and they are agnostic of database 
    /// infrastructure
    /// </summary>
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

        public async Task<int> AddOrder(Order newOrder)
        {
            _dataContextEF.Orders.Add(newOrder);
            int row=  await _dataContextEF.SaveChangesAsync();
            if (row > 0)
            {
                return newOrder.ID;
            }
            else return 0;
        }

        public Order GetOrderByID(int orderID)
        {
           return _dataContextEF.Orders.Include(c=>c.Cart).Include(c=>c.Cart.Items).
                SingleOrDefault(c => c.ID == orderID);
        }
    }
}
