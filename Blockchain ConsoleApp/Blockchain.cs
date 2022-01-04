// See https://aka.ms/new-console-template for more information
using System.Collections;

internal class Blockchain:IEnumerable<Block>
{
    readonly List<Block> _blocks;
    public Blockchain() => _blocks = new List<Block>() { new Block() };

    internal void Add(Block block)
    {
        block._previousHash = _blocks.Last()._hash;
        block._timestamp = DateTime.UtcNow;
        block._hash = block.GetHashCode();
        _blocks.Add(block);
    }

    public IEnumerator<Block> GetEnumerator() => ((IEnumerable<Block>)_blocks).GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_blocks).GetEnumerator();
}

internal class Block
{
    public DateTime _timestamp;
    public Transaction _transactions;
    public int _previousHash;
    public int _hash;

    public Block()
    {
        _timestamp = DateTime.UtcNow;
        _transactions = null!;
        _previousHash = 0;
        _hash = GetHashCode();
    }

    public override int GetHashCode() => HashCode.Combine(_timestamp, _previousHash, _transactions?.GetHashCode());

    public Block(Transaction transaction) : this() => _transactions = transaction;

    public override string ToString() => $"{_timestamp} {_transactions} {_previousHash} {_hash}";
}