using System.Security.Cryptography;
using System.Text;

class Block
{
    #region FIELDS
    public DateTime _timestamp;
    public List<Transaction> _transactions;
    public string _previousHash;
    public string _hash;
    public int _noune;
    #endregion
    
    #region CONSTRUCTORS
    public Block()
    {
        _timestamp = DateTime.UtcNow;
        _transactions = new();
        _previousHash = "";
        _hash = "";
    }

    public Block(List<Transaction> transactions) : this() => _transactions = new(transactions);
    #endregion

    public void Mine(int difficulty)
    {
        var leadingZeros = new string('0', difficulty);
        _hash = this.CreateHash();
        while (leadingZeros != _hash[..difficulty])
        {
            _noune++;
            _hash = CreateHash();
            Console.WriteLine(_hash);
        }
    }

    public string CreateHash()
    {
        byte[] bytes = Encoding.UTF8.GetBytes($"{_timestamp} {Sum(_transactions)} {_previousHash} {_noune}");
        using SHA256 sha = SHA256.Create();
        byte[] hash = sha.ComputeHash(bytes);
        return Convert.ToBase64String(hash);
    }

    private static string Sum(List<Transaction> transactions)
    {
        var sum = "";
        foreach (var transaction in transactions) sum += transaction + "\n\r                   ";
        return sum;
    }

    public override string ToString() => $"{_timestamp} {Sum(_transactions)} {_hash} {_noune}";
}
