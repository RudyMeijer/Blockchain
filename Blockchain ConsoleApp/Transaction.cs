// See https://aka.ms/new-console-template for more information
internal class Transaction
{
    private string from;
    private string to;
    private double amount;

    public Transaction(string from, string to, double amount)
    {
        this.from = from;
        this.to = to;
        this.amount = amount;
    }
    public override string ToString()
    {
        return $"From {from} to {to} amount {amount}";
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(from,to,amount);
    }
}