namespace algEx;

public class CocktailSort
{
    public void Run(int[] array)
    {
        bool swapped;
        int start = 0;
        int end = array.Length - 1;

        do
        {
            swapped = false;
                                
            for (int i = start; i < end; i++) // Проход слева направо
            {
                if (array[i] > array[i + 1])
                {                        
                    int temp = array[i];
                    array[i] = array[i + 1];
                    array[i + 1] = temp;
                    swapped = true;
                }
            }                
            if (!swapped) //если !swapped, значит массив отсортирован
                break;
                                
            swapped = false; // Сбрасываем флаг swapped для следующего прохода
                                
            end--; // Уменьшаем конец, тк старший элемент уже на своем месте
                                
            for (int i = end; i > start; i--) // Проход справа налево
            {
                if (array[i] < array[i - 1])
                {                        
                    int temp = array[i];
                    array[i] = array[i - 1];
                    array[i - 1] = temp;
                    swapped = true;
                }
            }
                                
            start++; // Увеличиваем начало, тк младший элемент уже на своем месте

        } while (swapped); // Продолжаем пока происходят обмены
    }
}