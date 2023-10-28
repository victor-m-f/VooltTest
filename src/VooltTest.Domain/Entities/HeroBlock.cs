using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VooltTest.Domain.Extensions;

namespace VooltTest.Domain.Entities;

public sealed class HeroBlock : Block
{
    public string? HeadlineText { get; set; }
    public string? DescriptionText { get; set; }
    public CTAButton? CTA { get; set; }
    public string? HeroImage { get; set; }
    public string? ImageAlignment { get; set; }
    public string? ContentAlignment { get; set; }

    public HeroBlock(int id, int blockOrder)
        : base(id, blockOrder)
    {
    }

    public static bool Parse(string updatedBlock, out HeroBlock? block)
    {
        var jObject = JObject.Parse(updatedBlock);

        if (!jObject.ContainsKeyIgnoreCase(nameof(HeadlineText)) ||
            !jObject.ContainsKeyIgnoreCase(nameof(DescriptionText)) ||
            !jObject.ContainsKeyIgnoreCase(nameof(HeroImage)) ||
            !jObject.ContainsKeyIgnoreCase(nameof(ImageAlignment)) ||
            !jObject.ContainsKeyIgnoreCase(nameof(ContentAlignment)))
        {
            block = null;
            return false;
        }

        block = JsonConvert.DeserializeObject<HeroBlock>(updatedBlock);
        return true;
    }
}
