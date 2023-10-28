using Newtonsoft.Json.Linq;

namespace VooltTest.Domain.Extensions
{
    public static class JObjectExtensions
    {
        public static bool ContainsKeyIgnoreCase(this JObject jObject, string key)
        {
            return jObject.Properties().Any(p => string.Equals(p.Name, key, StringComparison.OrdinalIgnoreCase));
        }
    }
}
