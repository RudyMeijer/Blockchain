// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography;
using System.Text;

class Transaction
{
    readonly string from;
    readonly string to;
    readonly double amount;

    public Transaction(string from, string to, double amount)
    {
        this.from = from;
        this.to = to;
        this.amount = amount;
    }
    public override string ToString() => $"From {from} to {to} amount {amount}";
}