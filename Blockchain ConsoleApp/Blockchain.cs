class Blockchain
{
    public List<Block> blocks;
    public Blockchain() => blocks = new() { new GenesisBlock() };

    public void Add(Block block)
    {
        block._timestamp = DateTime.UtcNow;
        block._previousHash = blocks.Last()._hash;
        block._hash = block.CreateHash();
        blocks.Add(block);
    }
}
class GenesisBlock : Block { }