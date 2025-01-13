namespace algEx;

public class SelectionSort
{
    // Метод для сортировки массива
    public void Run(int[] array)
    {
        int n = array.Length;

        for (int i = 0; i < n - 1; i++)
        {
            // Находим индекс минимального элемента в неотсортированной части массива
            int minIndex = i;
            for (int j = i + 1; j < n; j++)
            {
                if (array[j] < array[minIndex])
                {
                    minIndex = j;
                }
            }

            // Обмениваем найденный минимальный элемент с первым элементом неотсортированной части
            if (minIndex != i)
            {
                int temp = array[i];
                array[i] = array[minIndex];
                array[minIndex] = temp;
            }
        }
    }
}
