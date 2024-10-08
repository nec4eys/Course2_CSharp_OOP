﻿namespace HashTableTask;

internal class HashTableMain
{
    static void Main(string[] args)
    {
        HashTable<string> hashTable = new HashTable<string>();

        Console.WriteLine(hashTable);

        hashTable.Add("Q");
        hashTable.Add("W");
        hashTable.Add("E");
        hashTable.Add("R");
        hashTable.Add("T");
        hashTable.Add("Q");
        hashTable.Add("Y");
        hashTable.Add("W");

        Console.WriteLine(hashTable);

        Console.WriteLine(hashTable.Contains(","));
        Console.WriteLine(hashTable.Count);

        Console.WriteLine(hashTable.Remove("Q"));
        Console.WriteLine(hashTable.Contains("Q"));

        hashTable.Clear();
    }
}
