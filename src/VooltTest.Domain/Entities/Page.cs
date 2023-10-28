namespace VooltTest.Domain.Entities;

public sealed class Page
{
    public List<HeaderBlock>? Headers { get; set; }
    public List<HeroBlock>? Heroes { get; set; }
    public List<ServicesBlock>? Services { get; set; }

    public static Page CreateDefault()
    {
        return new Page
        {
            Headers = new List<HeaderBlock> { new HeaderBlock(1, 1) },
            Heroes = new List<HeroBlock> { new HeroBlock(2, 1) },
            Services = new List<ServicesBlock> { new ServicesBlock(3, 1) },
        };
    }

    public void DeleteBlock(int sectionID)
    {
        if (Headers != null && Headers.Any(x => x.ID == sectionID))
        {
            Headers.RemoveAll(x => x.ID == sectionID);
        }
        else if (Heroes != null && Heroes.Any(x => x.ID == sectionID))
        {
            Heroes.RemoveAll(x => x.ID == sectionID);
        }
        else if (Services != null && Services.Any(x => x.ID == sectionID))
        {
            Services.RemoveAll(x => x.ID == sectionID);
        }
    }

    public bool UpdateHeader(int sectionID, HeaderBlock? header)
    {
        var existingBlockIndex = Headers!.FindIndex(x => x.ID == sectionID);

        if (existingBlockIndex == -1)
        {
            return false;
        }

        header!.ID = sectionID;
        Headers[existingBlockIndex] = header!;
        return true;
    }

    public bool UpdateHero(int sectionID, HeroBlock? hero)
    {
        var existingBlockIndex = Heroes!.FindIndex(x => x.ID == sectionID);

        if (existingBlockIndex == -1)
        {
            return false;
        }

        hero!.ID = sectionID;
        Heroes[existingBlockIndex] = hero!;
        return true;
    }

    public bool UpdateServices(int sectionID, ServicesBlock? services)
    {
        var existingBlockIndex = Services!.FindIndex(x => x.ID == sectionID);

        if (existingBlockIndex == -1)
        {
            return false;
        }

        services!.ID = sectionID;
        Services[existingBlockIndex] = services!;
        return true;
    }
}
