namespace VooltTest.Domain.Entities;

public abstract class Block
{
    public int ID { get; set; }
    public int BlockOrder { get; }

    public Block()
    {
    }

    protected Block(int id, int blockOrder)
    {
        ID = id;
        BlockOrder = blockOrder;
    }
}
