///<summary>
/// <Author>Volkan Uzun</Author>
/// <Date>10/04/2023</Date>
///</summary>
using PokeRestaurant.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace PokeRestaurant.Web.ViewModels
{
    public class Add2CartViewModel
    {

        [Required]
        public int SelectedBaseItemID { get; set; }
        [Required]
        public List<ProteinItemSelectionViewModel>? ProteinItems { get; set; }
        [Required]
        public List<ToppingItemSelectionViewModel>? ToppingItems { get; set; }
        [Required]
        public string SelectedBaseItemName { get; set; }
        [Required]
        public decimal SelectedBaseItemPrice { get; set; }


    }

    public class ProteinItemSelectionViewModel
    {
        [Required]
        public  string Name { get; set; }
        [Required]
        public int ID { get; set; }
        [Required]
         public bool IsChecked { get; set; }
    }

    public class ToppingItemSelectionViewModel
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public bool IsChecked { get; set; }
    }
}
