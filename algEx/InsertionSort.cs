namespace algEx;
public class InsertionSort
{
    public void Run(int[] array)
    {
        int n = array.Length;
        
        for (int i = 1; i < n; i++)
        {
            int key = array[i];
            int j = i - 1;

            while (j >= 0 && array[j] > key)
            {
                array[j + 1] = array[j];
                j = j - 1;
            }
            array[j + 1] = key;
        }
    }
}