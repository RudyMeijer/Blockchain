class Transaction
{
    readonly string from;
    readonly string to;
    public double amount;

    public Transaction(string from, string to, double amount)
    {
        this.from = from;
        this.to = to;
        this.amount = amount;
    }
    public override string ToString() => $"From {from} to {to} amount {amount}";
}