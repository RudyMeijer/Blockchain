using System.Security.Cryptography;
using System.Text;

internal class Block
{
    public DateTime _timestamp;
    public Transaction _transaction;
    public string _previousHash;
    public string _hash;
    public int _noune;

    public Block()
    {
        _timestamp = DateTime.UtcNow;
        _transaction = null!;
        _previousHash = "";
        _hash = "";
    }

    internal void Mine(int difficulty)
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

    public Block(Transaction transaction) : this() => _transaction = transaction;

    internal void Mine(int difficulty)
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
        byte[] bytes = Encoding.UTF8.GetBytes($"{_timestamp} {_transaction} {_previousHash} {_noune}");
        using SHA256 sha = SHA256.Create();
        byte[] hash = sha.ComputeHash(bytes);
        return Convert.ToBase64String(hash);
    }

    public override string ToString() => $"{_timestamp} {_transaction} {_hash} {_noune}";
}
