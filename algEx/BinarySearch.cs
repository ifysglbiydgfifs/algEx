namespace algEx;
public class BinarySearch
{
    // Метод для выполнения бинарного поиска
    public int Run(int[] array, int target)
    {
        int left = 0;
        int right = array.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;  // Избегаем переполнения для больших индексов


            // Если элемент найден
            if (array[mid] == target)
            {
                Console.WriteLine($"Элемент {target} найден на индексе {mid}");
                return mid;
            }

            // Если целевое значение больше среднего элемента
            if (array[mid] < target) left = mid + 1;
            // Если целевое значение меньше среднего элемента
            else right = mid - 1;
        }

        // Элемент не найден
        Console.WriteLine($"Элемент {target} не найден в массиве.");
        return -1;
    }
}