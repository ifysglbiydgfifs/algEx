using System.Runtime.CompilerServices;
using algEx;
using algEx.dsi;
using BFSAlgorithmWithLogging;
using DFSAlgorithmWithLogging;
using DijkstraAlgorithm;
using HashTables;
using KruskalAlgorithm;
using PrimAlgorithm;
using Graph = KruskalAlgorithm.Graph;

class Program
{
    static void Main(string[] args)
    {
        var testArray = new int[10]{3,6,12,53,2,34,7,23,19,8};
        
        BubleSort bubleSort = new BubleSort();
        InsertionSort insertionSort = new InsertionSort();
        SelectionSort selectionSort = new SelectionSort();
        CocktailSort cocktailSort = new CocktailSort();
        ShellSort shellSort = new ShellSort();
        QuickSort quickSort = new QuickSort();
        TreeSort treeSort = new TreeSort();
        BinarySearch binarySearch = new BinarySearch();
        
        treeSort.Run(testArray);
        PrintArray(testArray);
        
        binarySearch.Run(testArray, 7);

        DirectMergeSort directMergeSort = new DirectMergeSort();
        //string filePath = "C:\\C# project\\algEx\\inputs\\countries.xlsx";
        //directMergeSort.Run(filePath, 3);

        RadixSort radixSort = new RadixSort();
        var words = new string[10]{"apple", "banana", "aaple", "cherry", "date", "cherry", "banana", "adple", "cherry", "date"};
        radixSort.Run(words);
        PrintArray(words);
        Console.WriteLine();
        
        /*HashTable hashTable = new HashTable();
        hashTable.Insert("fruit", "apple");
        hashTable.Insert("vegetable", "carrot");
        hashTable.Insert("berryy", "watermelon");
        Console.WriteLine();
        PrintHashTable(hashTable);
        hashTable.Remove("vegetable");
        Console.WriteLine();
        PrintHashTable(hashTable);
        Console.WriteLine(hashTable.Search("fruit"));*/


        var customStack = new CustomStack<int>();

        customStack.Push(10);
        customStack.Push(20);
        customStack.Push(30);

        Console.WriteLine("Stack after Push operations:");
        customStack.Print();

        Console.WriteLine("Peek: " + customStack.Peek());

        Console.WriteLine("Pop: " + customStack.Pop());
        customStack.Print();

        
        var queue = new CustomQueue<int>();

        queue.Push(10);
        queue.Push(20);
        queue.Push(30);

        Console.WriteLine("\nQueue after Enqueue operations:");
        queue.Print();

        Console.WriteLine("Peek: " + queue.Peek());

        Console.WriteLine("Dequeue: " + queue.Pop());
        queue.Print();
        
        
        Kruskal.Run();
        
        Prim.Run();
        
        DFSRUN.Run();
        
        BFSRUN.Run();
        
        DeikstraRun.Run();
    }

    private static void PrintHashTable(HashTable hashTable)
    {
        if (hashTable == null)
        {
            throw new NullReferenceException(nameof(hashTable));
        }
        foreach (var item in hashTable.Items)
        {
            Console.Write(item.Key);
            foreach (var value in item.Value)
            {
                Console.WriteLine($" {value.Key}-{value.Value}");
            }
        }
    }
    public static void PrintArray(int[] array)
    {
        foreach (var item in array)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
    
    public static void PrintArray(string[] array)
    {
        foreach (var item in array)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}