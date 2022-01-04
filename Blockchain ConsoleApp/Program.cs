Console.WriteLine("Test Blockchain!");

Blockchain blockchain = new();
blockchain.Add(new Block(new Transaction(from: "rudy", to: "marga", amount: 101.23)));
blockchain.Add(new Block(new Transaction(from: "Henk", to: "Aniek", amount: -84.45)));

foreach (var block in blockchain) Console.WriteLine(block);
