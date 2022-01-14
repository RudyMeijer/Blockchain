class Transaction
{
    public readonly string from;
    public readonly string to;
    public readonly double amount;

    public Transaction(string from, string to, double amount)
    {
        this.from = from;
        this.to = to;
        this.amount = amount;
    }
    public override string ToString() => $"From {from} to {to} amount {amount}";
}