﻿Console.WriteLine("Test Blockchain.");

Blockchain blockchain = new();
blockchain.Add(new Block(new Transaction(from: "rudy", to: "marga", amount: 101.23)));
blockchain.Add(new Block(new Transaction(from: "Henk", to: "Aniek", amount: -84.45)));
blockchain.Add(new Block(new Transaction(from: "Hari", to: "Zenaa", amount: 345.45)));

foreach (var block in blockchain.blocks) Console.WriteLine(block);

Console.WriteLine($"Blockchain.IsValid = {blockchain.IsValid()}");

var blockTampered = blockchain.blocks[1];
blockTampered._transaction = new Transaction(from: "rudy", to: "marga", amount: 100.23);
Console.WriteLine($"Blockchain.IsValid = {blockchain.IsValid()} (Tampered)");

