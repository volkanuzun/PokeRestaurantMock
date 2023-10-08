///<summary>
/// <Author>Volkan Uzun</Author>
/// <Date>10/04/2023</Date>
///</summary>
using PokeRestaurant.Data.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeRestaurant.Data.Entity
{
    /// <summary>
    /// Shopping Cart POCO Object; this will keep the Shopping Cart in the database    
    /// </summary>
    /// <remarks>
    /// We can use localization here; but for simplicity I am skipping it 
    /// (For Display names and error message, we can move to localization files)
    /// </remarks>
    public class ShoppingCart: BaseEntity
    {
        public List<ShoppingCartLine> Items { get; set; } = new List<ShoppingCartLine>();

        public virtual void Clear() => Items.Clear();

        public virtual void RemoveItem(ShoppingCartLine item) => Items.RemoveAll(l => l.ID == item.ID);

        public virtual decimal ComputeTotalValue() => Items.Sum(e => e.TotalPrice);

        public virtual void AddItem(ShoppingCartLine line) => Items.Add(line);

        

    }

    public class ShoppingCartLine : BaseEntity
    {
        public Guid LineID { get { return Guid.NewGuid(); } }
        //we dont put references into the database for menu items as changes in the db may update the historical data which is not wanted
        [Required]
        public required string BaseItemName { get; set; }
        [Required]
        public required decimal BaseItemPrice { get; set; }

        [Required]
        [Column]
        public  string BaseToppings { get; set; }


        [Required]
        [Column]
        public string ProteinToppings { get; set; }

        [NotMapped]
        public List<string> Proteins { 
            get
            {
                return ProteinToppings.Split(',').ToList();
            }
            set
            {
                ProteinToppings = String.Join(",", value);
            }
        }

       [NotMapped]
        public List<string> Toppings { 
            get
            {
                return BaseToppings.Split(',').ToList();
            }
            set
            {
                BaseToppings = String.Join(",", value);
            }
        }

        public decimal TotalPrice
        {
            get
            {
                return BaseItemPrice +( (Toppings.Count - 3) * 0.5m);
            }
        }

    }
}
