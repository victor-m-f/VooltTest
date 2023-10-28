using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VooltTest.Domain.Extensions;

namespace VooltTest.Domain.Entities;

public sealed class HeaderBlock : Block
{
    public string? BusinessName { get; set; }
    public bool LogoDisplayed { get; set; }
    public NavigationMenu? Menu { get; set; }
    public CTAButton? CTA { get; set; }


    public HeaderBlock(int id, int blockOrder)
        : base(id, blockOrder)
    {
    }

    public static bool Parse(string updatedBlock, out HeaderBlock? block)
    {
        var jObject = JObject.Parse(updatedBlock);

        if (!jObject.ContainsKeyIgnoreCase(nameof(BusinessName)) || !jObject.ContainsKeyIgnoreCase(nameof(LogoDisplayed)))
        {
            block = null;
            return false;
        }

        block = JsonConvert.DeserializeObject<HeaderBlock>(updatedBlock);
        return true;
    }
}
