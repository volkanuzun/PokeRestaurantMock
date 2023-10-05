///<summary>
/// <Author>Volkan Uzun</Author>
/// <Date>10/04/2023</Date>
///</summary>
using PokeRestaurant.Data.Entity;

namespace PokeRestaurant.Web.ViewModels
{
    public class MenuViewModel
    {
        public static string CacheKeyName = "MenuViewModel";
        private List<MenuItem>? _allItems;
        public List<MenuItem> AllItems { 
            get { return _allItems; } 
            set {
                this._allItems = value;
                BaseItems = _allItems.Where(c => c.MenuItemType == Data.Abstract.MenuItemType.Base).ToList();
                ProteinItems = _allItems.Where(c => c.MenuItemType == Data.Abstract.MenuItemType.Protein).ToList();
                ToppingItems = _allItems.Where(c=>c.MenuItemType== Data.Abstract.MenuItemType.Toppings).ToList();
            }
        }
        public List<MenuItem>? BaseItems { get; set; }
        public List<MenuItem>? ProteinItems { get; set; }
        public List<MenuItem>? ToppingItems { get; set; }
    }
}
