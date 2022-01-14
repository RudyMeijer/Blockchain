using System.Text.Json;

Console.WriteLine("Test Blockchain.");

Blockchain blockchain = new();
blockchain.CreateTransaction(new Transaction(from: "Marga", to: "Rudy", amount: 101.23));
blockchain.CreateTransaction(new Transaction(from: "Rudy", to: "Henk", amount: 0081.23));
blockchain.CreateTransaction(new Transaction(from: "Hari", to: "Zenaa", amount: 345.45));

blockchain.ProcessTransaction("Rudy", reward: 1);
blockchain.ProcessTransaction("Rudy", reward: 10);

Console.WriteLine(Json(blockchain));
foreach (var block in blockchain.blocks) Console.WriteLine(block);

Console.WriteLine($"Balance Rudy {blockchain.GetBalance("Rudy")}");
Console.WriteLine($"Blockchain.IsValid = {blockchain.IsValid()}");

var blockTampered = blockchain.blocks[1];
blockTampered._transactions.Add(new Transaction(from: "rudy", to: "Tampered", amount: 100.23));
Console.WriteLine($"Blockchain.IsValid = {blockchain.IsValid()} (Tampered)");

static string Json<T>(T obj)
{
    JsonSerializerOptions options = new();
    options.IncludeFields = true;
    options.WriteIndented = true;
    return JsonSerializer.Serialize<T>(obj, options);
}