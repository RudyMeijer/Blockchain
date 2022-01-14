class Blockchain
{
    public List<Block> blocks;
    public List<Transaction> pendingTransactions = new();
    
    public Blockchain() => blocks = new() { new GenesisBlock() };
    
    public void Add(Block block)
    {
        block._timestamp = DateTime.UtcNow;
        block._previousHash = blocks.Last()._hash;
        block._hash = block.CreateHash();
        block.Mine(difficulty: 2);
        blocks.Add(block);
    }

    public double GetBalance(string address)
    {
        var balance = 0d;
        foreach (var block in blocks)
        {
            foreach (var transaction in block._transactions)
            {
                if (transaction.from == address) balance -= transaction.amount;
                if (transaction.to   == address) balance += transaction.amount;
            }
        }
        return balance;
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

    public void CreateTransaction(Transaction transaction) => pendingTransactions.Add(transaction);
    
    public void ProcessTransaction(string minerAddress, int reward)
    {
        if (!IsValid()) throw new Exception("Blockchain not valid!");
        if (pendingTransactions.Count == 0) throw new Exception("No pending transactions.");
        Add(new Block(pendingTransactions));
        pendingTransactions.Clear();
        pendingTransactions.Add(new Transaction("", minerAddress, reward));
    }
}
class GenesisBlock : Block
{
    public GenesisBlock() => _hash = CreateHash();
}