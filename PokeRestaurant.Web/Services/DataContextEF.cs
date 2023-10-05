using Microsoft.EntityFrameworkCore;

namespace PokeRestaurant.Web.Services
{
    public class DataContextEF:DbContext
    {
        private string _connectionString;

        public DataContextEF(string connectionString)
        {
            this._connectionString = connectionString;
        }
    }
}
