///<summary>
/// <Author>Volkan Uzun</Author>
/// <Date>10/04/2023</Date>
///</summary>
using PokeRestaurant.Data.Abstract;
using System.ComponentModel.DataAnnotations;

namespace PokeRestaurant.Data.Entity
{
    /// <summary>
    /// MenuItem POCO Object; this will keep the MenuItems in the database    
    /// </summary>
    /// <remarks>
    /// We can use localization here; but for simplicity I am skipping it 
    /// (For Display names and error message, we can move to localization files)
    /// </remarks>
    public class MenuItem : BaseEntity
    {
        [Required(ErrorMessage ="Menu name is a required field!")]
        [DataType(DataType.Text)]
        [MaxLength(100,ErrorMessage ="Maximum length for Name is 100 characters!")]
        [Display(Name="Item Name")]
        [UIHint("Menu Item Name")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Description  is a required field!")]
        [DataType(DataType.Text)]
        [MaxLength(100, ErrorMessage = "Maximum length for Description is 100 characters!")]
        [Display(Name = "Item Description")]
        [UIHint("Menu Item Description")]
        public required string Description { get; set; }

        [Required(ErrorMessage = "Image name is a required field!")]
        [DataType(DataType.Text)]
        [MaxLength(100, ErrorMessage = "Maximum length for Image name is 100 characters!")]        
        public required string ImageName { get; set; }

        [Required(ErrorMessage = "Item Price is a required field!")]
        [DataType(DataType.Currency)]
        [Display(Name = "Item Price")]
        [UIHint("Menu Item Price")]
        public required decimal Price { get; set; }
        public bool IsInStock { get; set; }
        public MenuItemType MenuItemType { get; set; }

        public MenuItem()
        {
            this.MenuItemType = MenuItemType.Base;
            this.IsInStock = true;
        }

    }
}
