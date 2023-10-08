///<summary>
/// <Author>Volkan Uzun</Author>
/// <Date>10/07/2023</Date>
///</summary>
using PokeRestaurant.Data.Entity;
using PokeRestaurant.Web.Helpers;
using System.Text.Json.Serialization;

namespace PokeRestaurant.Web.Models
{
    /// <summary>
    /// Session cart is a typeof Shopping cart that is stored in session
    /// In the default config; it is stored in distributed mem cache; however it is easy to change the config
    /// in program.cs so that it is stored in sql server, reddis etc
    /// It is per user session
    /// Ideally in production we shouldnt use sessions especially if we have Load Balancers or Proxy
    /// (sticky session cookie may help) but in this mockup project we dont need such configuration
    /// </summary>
    public class SessionCart:ShoppingCart
    {
        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()? .HttpContext.Session;
            SessionCart cart = session?.GetJson<SessionCart>("Cart") ?? new SessionCart();
            cart.Session = session;
            return cart;
        }

        [JsonIgnore]
        public ISession Session { get; set; }

        public override void AddItem(ShoppingCartLine item)
        {
            base.AddItem(item);
            Session.SetJson("Cart", this);
        }

        public override void RemoveItem(ShoppingCartLine item)
        {
            base.RemoveItem(item);
            Session.SetJson("Cart", this);
        }

        public override void Clear()
        {
            base.Clear();
            Session.Remove("Cart");
        }
    }
}
