// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography;
using System.Text;

internal class Transaction
{
    private readonly string from;
    private readonly string to;
    private readonly double amount;

    public Transaction(string from, string to, double amount)
    {
        this.from = from;
        this.to = to;
        this.amount = amount;
    }
    public override string ToString() => $"From {from} to {to} amount {amount}";
}