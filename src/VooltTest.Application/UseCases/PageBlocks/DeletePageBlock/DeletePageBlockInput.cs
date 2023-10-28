using VooltTest.Application.UseCases.Base;

namespace VooltTest.Application.UseCases.PageBlocks.UpdatePageBlock;

public sealed class DeletePageBlockInput : InputBase<DeletePageBlockOutput>
{
    public string Key { get; }
    public int SectionID { get; }

    public DeletePageBlockInput(string key, int sectionID)
    {
        Key = key;
        SectionID = sectionID;
    }
}
