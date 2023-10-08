using PokeRestaurant.Data.Entity;

namespace PokeRestaurant.UnitTests
{
    [TestClass]
    public class ShoppingCartTests
    {
        [TestMethod]
        public void ShoppingCart_Should_Add_CartLine()
        {
            ShoppingCart cart = new ShoppingCart();
            Assert.IsTrue(cart.Items.Count == 0,"Cart should have 0 elements at first");
            ShoppingCartLine line1 = new ShoppingCartLine()
            { BaseItemName = "Chicken", BaseItemPrice = 7.95m, ProteinToppings = "Beef, Chicken", BaseToppings = "corn, apple, orange" };

            cart.AddItem(line1);

            Assert.IsTrue(cart.Items.Count == 1,"Cart should have 1 item after adding 1 item only");
        }

        [TestMethod]
        public void ShoppingCart_Should_Add_Remove_CartLine()
        {
            ShoppingCart cart = new ShoppingCart();
            Assert.IsTrue(cart.Items.Count == 0, "Cart should have 0 elements at first");
            
            ShoppingCartLine line1 = new ShoppingCartLine()
            { BaseItemName = "Chicken", BaseItemPrice = 7.95m, ProteinToppings = "Beef, Chicken",
                ID= 1, BaseToppings = "corn, apple, orange" };

            ShoppingCartLine line2 = new ShoppingCartLine()
            {
                BaseItemName = "Beef",
                BaseItemPrice = 9.95m,
                ProteinToppings = "Beef, Chicken",
                ID = 2,
                BaseToppings = "corn, apple, orange"
            };

            cart.AddItem(line1);
            cart.AddItem(line2);
            Assert.IsTrue(cart.Items.Count == 2, "Cart should have 2 items after adding 2 items");
            cart.RemoveItem(line1);
            Assert.IsTrue(cart.Items.Count == 1, "Cart should have 1 item after after removing  1 item");
        }

        [TestMethod]
        public void ShoppingCart_Should_Add_Calculate_Total()
        {
            ShoppingCart cart = new ShoppingCart();
          
            ShoppingCartLine line1 = new ShoppingCartLine()
            {
                BaseItemName = "Chicken",
                BaseItemPrice = 7.95m,
                ProteinToppings = "Beef, Chicken",
                ID = 1,
                BaseToppings = "corn, apple, orange"
            };

            ShoppingCartLine line2 = new ShoppingCartLine()
            {
                BaseItemName = "Beef",
                BaseItemPrice = 9.95m,
                ProteinToppings = "Beef, Chicken",
                ID = 2,
                BaseToppings = "corn, apple, orange"
            };

            cart.AddItem(line1);
            cart.AddItem(line2);

            Assert.AreEqual(cart.ComputeTotalValue() , (line1.BaseItemPrice + line2.BaseItemPrice));
        }

        [TestMethod]
        public void ShoppingCart_Should_Empty_After_Clear()
        {
            ShoppingCart cart = new ShoppingCart();
            Assert.IsTrue(cart.Items.Count == 0, "Cart should have 0 elements at first");

            ShoppingCartLine line1 = new ShoppingCartLine()
            {
                BaseItemName = "Chicken",
                BaseItemPrice = 7.95m,
                ProteinToppings = "Beef, Chicken",
                ID = 1,
                BaseToppings = "corn, apple, orange"
            };

            ShoppingCartLine line2 = new ShoppingCartLine()
            {
                BaseItemName = "Beef",
                BaseItemPrice = 9.95m,
                ProteinToppings = "Beef, Chicken",
                ID = 2,
                BaseToppings = "corn, apple, orange"
            };

            cart.AddItem(line1);
            cart.AddItem(line2);
            Assert.IsTrue(cart.Items.Count == 2, "Cart should have 2 items after adding 2 items");
            cart.Clear();
            Assert.IsTrue(cart.Items.Count == 0, "Cart should have 0 item after after Clear");
        }

        [TestMethod]
        public void ShoppingCartLine_Should_Parse_Proteins_ToList()
        {
            ShoppingCart cart = new ShoppingCart();
            Assert.IsTrue(cart.Items.Count == 0, "Cart should have 0 elements at first");

            ShoppingCartLine line1 = new ShoppingCartLine()
            {
                BaseItemName = "Chicken",
                BaseItemPrice = 7.95m,
                ProteinToppings = "Beef, Chicken",
                ID = 1,
                BaseToppings = "corn, apple, orange"
            };

            ShoppingCartLine line2 = new ShoppingCartLine()
            {
                BaseItemName = "Beef",
                BaseItemPrice = 9.95m,
                ProteinToppings = "Beef",
                ID = 2,
                BaseToppings = "corn, apple, orange"
            };

            Assert.IsTrue(line1.Proteins.Count == 2);
            Assert.IsTrue(line2.Proteins.Count == 1);
        }

        [TestMethod]
        public void ShoppingCartLine_Should_Parse_Toppings_ToList()
        {
            ShoppingCart cart = new ShoppingCart();
            Assert.IsTrue(cart.Items.Count == 0, "Cart should have 0 elements at first");

            ShoppingCartLine line1 = new ShoppingCartLine()
            {
                BaseItemName = "Chicken",
                BaseItemPrice = 7.95m,
                ProteinToppings = "Beef, Chicken",
                ID = 1,
                BaseToppings = "corn, apple, orange"
            };

            ShoppingCartLine line2 = new ShoppingCartLine()
            {
                BaseItemName = "Beef",
                BaseItemPrice = 9.95m,
                ProteinToppings = "Beef",
                ID = 2,
                BaseToppings = "1,2,3,4,5,6,7,8"
            };

            Assert.IsTrue(line1.Toppings.Count == 3);
            Assert.IsTrue(line2.Toppings.Count == 8);
        }
    }


}