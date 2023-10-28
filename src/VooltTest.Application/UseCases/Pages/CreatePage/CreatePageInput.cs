using VooltTest.Application.UseCases.Base;

namespace VooltTest.Application.UseCases.Pages.CreatePage;

public sealed class CreatePageInput : InputBase<CreatePageOutput>
{
    public string Key { get; }

    public CreatePageInput(string key)
    {
        Key = key;
    }
}
