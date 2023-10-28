namespace VooltTest.Domain.Entities;

public sealed class NavigationMenu
{
    public Link? Link { get; set; }
    public List<Link> SubMenus { get; set; }

    public NavigationMenu()
    {
        SubMenus = new List<Link>();
    }
}
