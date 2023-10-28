using VooltTest.Application.UseCases.Base;

namespace VooltTest.Application.UseCases.Pages.GetPage;

public sealed class GetPageInput : InputBase<GetPageOutput>
{
    public string Key { get; }

    public GetPageInput(string key)
    {
        Key = key;
    }
}
