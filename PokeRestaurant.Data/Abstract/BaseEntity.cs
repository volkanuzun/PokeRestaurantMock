///<summary>
/// <Author>Volkan Uzun</Author>
/// <Date>10/04/2023</Date>
///</summary>
namespace PokeRestaurant.Data.Abstract
{
    /// <summary>
    /// BaseEntity for Entity objects   
    /// Any object that goes into DB has an ID, date added (in UTC), IsActive field (for soft delete)
    /// </summary>
    /// 

    public class BaseEntity
    {
        public int ID { get; set; }
        public DateTime DateAddedUTC { get; set; }
        public bool IsActive { get; set; }

        public BaseEntity()
        {
            DateAddedUTC = DateTime.UtcNow;
            IsActive = true;
        }

    }
}
