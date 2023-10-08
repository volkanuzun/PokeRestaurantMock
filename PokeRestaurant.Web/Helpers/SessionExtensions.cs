///<summary>
/// <Author>Volkan Uzun</Author>
/// <Date>10/07/2023</Date>
///</summary>
using System.Text.Json;

namespace PokeRestaurant.Web.Helpers
{
    public static  class SessionExtensions
    {
        public static void SetJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }
        public static T GetJson<T>(this ISession session, string key)
        {
            var sessionData = session.GetString(key);
            
            return sessionData == null? default(T) : JsonSerializer.Deserialize<T>(sessionData);
        }
    }
}
