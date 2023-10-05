///<summary>
/// <Author>Volkan Uzun</Author>
/// <Date>10/04/2023</Date>
///</summary>
namespace PokeRestaurant.Data.Abstract
{
    public class BaseEntity
    {
        public int ID { get; set; }
        public DateTime DateAddedUTC { get; set; }
        public bool IsActive { get; set; }
        
    }
}
