///<summary>
/// <Author>Volkan Uzun</Author>
/// <Date>10/04/2023</Date>
///</summary>
using PokeRestaurant.Data.Abstract;
using System.ComponentModel.DataAnnotations;

namespace PokeRestaurant.Data.Entity
{
    /// <summary>
    /// Order POCO Object; this will keep the Orders in the database    
    /// </summary>
    /// <remarks>
    /// We can use localization here; but for simplicity I am skipping it 
    /// (For Display names and error message, we can move to localization files)
    /// </remarks>
    public class Order : BaseEntity
    {
        public ShoppingCart Cart { get; set; }
        public int ShoppingCartID { get; set; }

        [Required(AllowEmptyStrings =false,ErrorMessage ="Name is required!")]
        [DataType(DataType.Text)]
        [MaxLength(100, ErrorMessage = "Maximum length for Name is 100 characters!")]
        [Display(Name = "Name", Description = "Customer first name and last name for the order")]
        [UIHint("Customer first name last name for the order; maximum 100 characters")]
        public required string Name { get; set; }

        [Required(AllowEmptyStrings =false, ErrorMessage ="Email address is required!")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address", Description = "Email address for the customer")]
        [MaxLength(100, ErrorMessage = "Maximum length for Email address is 100 characters")]
        [UIHint("Customer Email address, maximum 100 characters")]
        public required string EmailAddress { get; set; }

        [Required(ErrorMessage ="Delivery Address is required!")]
        [DataType(DataType.Text)]
        [Display(Name="Delivery Address",Description ="Delivery address for the order")]
        [MaxLength(200,ErrorMessage ="Maximum length for the delivery address is 200!")]
        [UIHint("Delivery address for the order, maximum 200 characters")]
        public required string DeliveryAddress{get;set;}

        public bool IsShipped { get; set; }
        public required decimal TotalCost { get; set; }

        public Order()
        {
          
        }
    }
}
