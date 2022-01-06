using System.Security.Cryptography;
using System.Text;

internal class Block
{
    public DateTime _timestamp;
    public Transaction _transaction;
    public string _previousHash;
    public string _hash;

    public Block()
    {
        _timestamp = DateTime.UtcNow;
        _transaction = null!;
        _previousHash = "";
        _hash = "";
    }
    public Block(Transaction transaction) : this() => _transaction = transaction;

    public string CreateHash()
    {
        byte[] bytes = Encoding.UTF8.GetBytes(ToString());
        using SHA256 sha = SHA256.Create();
        byte[] hash = sha.ComputeHash(bytes);
        return Convert.ToBase64String(hash);
    }

    public override string ToString() => $"{_timestamp} {_transaction} {_hash}";
}
