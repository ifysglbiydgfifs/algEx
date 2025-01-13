using System.Runtime.CompilerServices;
using algEx;
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
        BinarySearch binarySearch = new BinarySearch();
        TreeSort treeSort = new TreeSort();
        DirectMergeSort directMergeSort = new DirectMergeSort();

        treeSort.Run(testArray);
        binarySearch.Run(testArray, 7);
        directMergeSort.Run(_filePath, keyIndex);
        
        PrintArray(testArray);
    }
    public static void PrintArray(int[] array)
    {
        foreach (var item in array)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}