namespace algEx;

public class ShellSort
{
    // Метод для сортировки массива
    public void Run(int[] array)
    {
        int n = array.Length;

        // Начальный интервал (gap)
        for (int gap = n / 2; gap > 0; gap /= 2)
        {
            // Сортировка вставками для текущего интервала
            for (int i = gap; i < n; i++)
            {
                int temp = array[i];
                int j;

                // Сравниваем элементы, находящиеся на расстоянии gap друг от друга
                for (j = i; j >= gap && array[j - gap] > temp; j -= gap)
                {
                    array[j] = array[j - gap];
                }

                array[j] = temp;
            }
        }
    }
}
