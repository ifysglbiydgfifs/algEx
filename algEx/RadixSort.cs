public class RadixSort
{
    // Метод для получения максимальной длины строки
    private int GetMaxLength(string[] array)
    {
        int maxLength = 0;
        foreach (var str in array)
        {
            if (str.Length > maxLength)
                maxLength = str.Length;
        }
        return maxLength;
    }

    // Метод для сортировки по символам на определенной позиции (по разряду)
    private void CountSort(string[] array, int exp, int maxLength)
    {
        int n = array.Length;
        string[] output = new string[n]; // временный массив для хранения отсортированных строк
        int[] count = new int[256]; // для подсчета количества символов (256 символов в ASCII)

        // Заполняем массив count количеством строк с определенным символом на позиции exp
        for (int i = 0; i < n; i++)
        {
            // Если длина строки меньше текущего разряда, считаем его как 0 (пустой символ)
            int index = exp < array[i].Length ? array[i][array[i].Length - exp - 1] : 0;
            count[index]++;
        }

        // Преобразуем count для нахождения правильных позиций для каждого символа
        for (int i = 1; i < 256; i++)
        {
            count[i] += count[i - 1];
        }

        // Строим отсортированный массив
        for (int i = n - 1; i >= 0; i--)
        {
            int index = exp < array[i].Length ? array[i][array[i].Length - exp - 1] : 0;
            output[count[index] - 1] = array[i];
            count[index]--;
        }

        // Копируем отсортированные строки обратно в исходный массив
        for (int i = 0; i < n; i++)
        {
            array[i] = output[i];
        }
    }

    // Основной метод для выполнения сортировки RadixSort
    public void Run(string[] array)
    {
        // Получаем максимальную длину строки
        int maxLength = GetMaxLength(array);

        // Применяем сортировку по каждому разряду, начиная с младшего
        for (int exp = 0; exp < maxLength; exp++)
        {
            CountSort(array, exp, maxLength);
        }
    }
}