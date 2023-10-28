using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VooltTest.Domain.Extensions;

namespace VooltTest.Domain.Entities;

public sealed class ServicesBlock : Block
{
    public string? HeadlineText { get; set; }
    public List<ServiceCard> ServiceCards { get; set; }

    public ServicesBlock(int id, int blockOrder)
        : base(id, blockOrder)
    {
        ServiceCards = new List<ServiceCard>();
    }

    public static bool Parse(string updatedBlock, out ServicesBlock? block)
    {
        var jObject = JObject.Parse(updatedBlock);

        if (!jObject.ContainsKeyIgnoreCase(nameof(HeadlineText)) ||
            jObject.ContainsKeyIgnoreCase(nameof(HeroBlock.DescriptionText)))
        {
            block = null;
            return false;
        }

        block = JsonConvert.DeserializeObject<ServicesBlock>(updatedBlock);
        return true;
    }
}
