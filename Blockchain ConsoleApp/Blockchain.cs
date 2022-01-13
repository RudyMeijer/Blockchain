class Blockchain
{
    public List<Block> blocks;
    public Blockchain() => blocks = new() { new GenesisBlock() };

    public void Add(Block block)
    {
        block._timestamp = DateTime.UtcNow;
        block._previousHash = blocks.Last()._hash;
        block._hash = block.CreateHash();
        block.Mine(difficulty: 2);
        blocks.Add(block);
    }
    public bool IsValid()
    {
        var previousHash = "";
        foreach (var block in blocks)
        {
            if (previousHash != block._previousHash) return false;
            if (block._hash != block.CreateHash()) return false;
            previousHash = block._hash;
        }
        return true;
    }
}
class GenesisBlock : Block
{
    public GenesisBlock() => _hash = CreateHash();
}