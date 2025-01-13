namespace algEx;

public class QuickSort
{
    public static void Run(int[] array)
    {
        Sort(array, 0, array.Length - 1);
    }
    static void Sort(int[] array, int low, int high)
    {
        if (low < high)
        {
            // Получаем индекс опорного элемента
            int pivotIndex = Partition(array, low, high);

            // Рекурсивно сортируем элементы до и после опорного элемента
            Sort(array, low, pivotIndex - 1);
            Sort(array, pivotIndex + 1, high);
        }
    }

    // Метод для разделения массива на части (чтобы найти опорный элемент)
    static int Partition(int[] array, int low, int high)
    {
        // Опорный элемент
        int pivot = array[high];

        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (array[j] < pivot)
            {
                i++;
                                        
                Swap(array, i, j);
            }
        }

        // Ставим опорный элемент на правильное место
        Swap(array, i + 1, high);

        return i + 1;
    }

    static void Swap(int[] array, int i, int j)
    {
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }
}