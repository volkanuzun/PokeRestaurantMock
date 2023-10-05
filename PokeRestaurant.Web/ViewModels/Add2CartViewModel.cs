///<summary>
/// <Author>Volkan Uzun</Author>
/// <Date>10/04/2023</Date>
///</summary>
using PokeRestaurant.Data.Entity;

namespace PokeRestaurant.Web.ViewModels
{
    public class Add2CartViewModel
    {
        
        public MenuItem SelectedBaseItem { get; set; }
        public List<ProteinItemSelectionViewModel>? ProteinItems { get; set; }
        public List<ToppingItemSelectionViewModel>? ToppingItems { get; set; }
        public int SelectedBaseItemID { get; set; }


    }

    public class ProteinItemSelectionViewModel
    {
        public MenuItem ProteinItem { get; set; }
         public bool IsChecked { get; set; }
    }

    public class ToppingItemSelectionViewModel
    {
        public MenuItem ToppingItem { get; set; }
        public bool IsChecked { get; set; }
    }
}
