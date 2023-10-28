namespace VooltTest.Domain.Entities;

public sealed class ServiceCard
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Image { get; set; }
    public CTAButton? CTA { get; set; }
}
