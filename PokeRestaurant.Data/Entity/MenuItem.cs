///<summary>
/// <Author>Volkan Uzun</Author>
/// <Date>10/04/2023</Date>
///</summary>
using PokeRestaurant.Data.Abstract;

namespace PokeRestaurant.Data.Entity
{

    public class MenuItem : BaseEntity
    {
        public string Name { get; set; }
        public string ImageName { get; set; }
        public decimal Price { get; set; }
        public bool IsInStock { get; set; }
        public MenuItemType MenuItemType { get; set; }

        public MenuItem()
        {
            this.MenuItemType = MenuItemType.Base;
            this.IsInStock = true;
        }

    }
}
