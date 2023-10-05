using PokeRestaurant.Data.Entity;
///<summary>
/// <Author>Volkan Uzun</Author>
/// <Date>10/04/2023</Date>
///</summary>
using PokeRestaurant.Web.Services;

namespace PokeRestaurant.Web.Helpers
{
    public static class DatabaseInitializer
    {
        public static  void Seed(IApplicationBuilder app)
        {
            DataContextEF context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<DataContextEF>();
            context.Database.EnsureCreated();

            MenuItem existingWhiteRice = context.MenuItems.Where(c => c.Name == "White Rice")
                                                          .FirstOrDefault();
            if (existingWhiteRice != null)
            {
                return;
            }

            MenuItem whiteRice = new MenuItem()
            {
                Name = "White Rice",
                Description = "Freshly fried White Rice",
                MenuItemType = Data.Abstract.MenuItemType.Base,
                Price = 11.95m,
                ImageName = "lobster-bisque.jpg"
            };

            MenuItem saladBase = new MenuItem()
            {
                Name = "Salad",
                Description = "Organic greens, all local",
                MenuItemType = Data.Abstract.MenuItemType.Base,
                Price = 7.95m,
                ImageName = "cake.jpg"
            };

            MenuItem halfAndHalf = new MenuItem()
            {
                Name = "Half and Half",
                Description = "Half Salad, Half White Rice",
                MenuItemType = Data.Abstract.MenuItemType.Base,
                Price = 9.95m,
                ImageName = "tuscan-grilled.jpg"
            };

            MenuItem proteinChicken = new MenuItem()
            {
                Name = "Chicken",
                Description = "All Organic Chicken",
                MenuItemType = Data.Abstract.MenuItemType.Protein,
                Price = 2.95m,
                ImageName = "greek-salad.jpg"
            };

            MenuItem proteinLobster = new MenuItem()
            {
                Name = "Lobster",
                Description = "Plump lobster meat, mayo and crisp lettuce on a toasted bulky roll",
                MenuItemType = Data.Abstract.MenuItemType.Protein,
                Price = 3.95m,
                ImageName = "lobster-roll.jpg"
            };

            MenuItem proteinSalmon = new MenuItem()
            {
                Name = "Salmon",
                Description = "Wild caught Salmon",
                MenuItemType = Data.Abstract.MenuItemType.Protein,
                Price = 3.95m,
                ImageName = "tuscan-grilled.jpg"
            };
            MenuItem proteinOctobus = new MenuItem()
            {
                Name = "Octobus",
                Description = "Wild caught Octobus",
                MenuItemType = Data.Abstract.MenuItemType.Protein,
                Price = 3.95m,
                ImageName = "tuscan-grilled.jpg"
            };
            MenuItem proteinBeef = new MenuItem()
            {
                Name = "Beef",
                Description = "Grass feed Beef",
                MenuItemType = Data.Abstract.MenuItemType.Protein,
                Price = 3.95m,
                ImageName = "tuscan-grilled.jpg"
            };

            MenuItem topMango = new MenuItem()
            {
                Name = "Mango",
                Description = "Fresh  Mango",
                MenuItemType = Data.Abstract.MenuItemType.Toppings,
                Price = 0.50m,
                ImageName = "mozzarella.jpg"
            };
            MenuItem topCorn = new MenuItem()
            {
                Name = "Mango",
                Description = "Fresh  Corn",
                MenuItemType = Data.Abstract.MenuItemType.Toppings,
                Price = 0.50m,
                ImageName = "mozzarella.jpg"
            };
            MenuItem topAvocado = new MenuItem()
            {
                Name = "Avocado",
                Description = "Fresh  Avocado",
                MenuItemType = Data.Abstract.MenuItemType.Toppings,
                Price = 0.50m,
                ImageName = "mozzarella.jpg"
            };
            MenuItem topEdameme = new MenuItem()
            {
                Name = "Edameme",
                Description = "Fresh  Edameme",
                MenuItemType = Data.Abstract.MenuItemType.Toppings,
                Price = 0.50m,
                ImageName = "mozzarella.jpg"
            };
            MenuItem topCucumber = new MenuItem()
            {
                Name = "Cucumber",
                Description = "Fresh  Cucumber",
                MenuItemType = Data.Abstract.MenuItemType.Toppings,
                Price = 0.50m,
                ImageName = "mozzarella.jpg"
            };
            MenuItem topWasabi = new MenuItem()
            {
                Name = "Wasabi",
                Description = "Fresh  Wasabi",
                MenuItemType = Data.Abstract.MenuItemType.Toppings,
                Price = 0.50m,
                ImageName = "mozzarella.jpg"
            };
            MenuItem topRedOnion = new MenuItem()
            {
                Name = "Red Onion",
                Description = "Fresh  Red Onion",
                MenuItemType = Data.Abstract.MenuItemType.Toppings,
                Price = 0.50m,
                ImageName = "mozzarella.jpg"
            };
            MenuItem topSesameSeed = new MenuItem()
            {
                Name = "Sesame Seed",
                Description = "Fresh  Sesame Seed",
                MenuItemType = Data.Abstract.MenuItemType.Toppings,
                Price = 0.50m,
                ImageName = "mozzarella.jpg"
            };
            MenuItem topGinger = new MenuItem()
            {
                Name = "Ginger",
                Description = "Fresh  Ginger",
                MenuItemType = Data.Abstract.MenuItemType.Toppings,
                Price = 0.50m,
                ImageName = "mozzarella.jpg"
            };
            MenuItem topGreenOnion = new MenuItem()
            {
                Name = "Green Onion",
                Description = "Fresh  Green Onion",
                MenuItemType = Data.Abstract.MenuItemType.Toppings,
                Price = 0.50m,
                ImageName = "mozzarella.jpg"
            };


            context.MenuItems.Add(halfAndHalf);
            context.MenuItems.Add(whiteRice);
            context.MenuItems.Add(saladBase);
            context.MenuItems.Add(proteinChicken);
            context.MenuItems.Add(proteinLobster);
            context.MenuItems.Add(proteinSalmon);
            context.MenuItems.Add(proteinOctobus);
            context.MenuItems.Add(proteinBeef);
           
            context.MenuItems.Add(topMango);
            context.MenuItems.Add(topCorn);
            context.MenuItems.Add(topAvocado);
            context.MenuItems.Add(topEdameme);
            context.MenuItems.Add(topCucumber);
            context.MenuItems.Add(topWasabi);
            context.MenuItems.Add(topRedOnion);
            context.MenuItems.Add(topSesameSeed);
            context.MenuItems.Add(topGinger);
            context.MenuItems.Add(topGreenOnion);

            context.SaveChanges();
        }
    }

}