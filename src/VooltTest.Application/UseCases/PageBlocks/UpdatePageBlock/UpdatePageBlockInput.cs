using VooltTest.Application.UseCases.Base;

namespace VooltTest.Application.UseCases.PageBlocks.UpdatePageBlock;

public sealed class UpdatePageBlockInput : InputBase<UpdatePageBlockOutput>
{
    public string Key { get; }
    public int SectionID { get; }
    public string UpdatedBlock { get; }

    public UpdatePageBlockInput(string key, int sectionID, string updatedBlock)
    {
        Key = key;
        SectionID = sectionID;
        UpdatedBlock = updatedBlock;
    }
}
