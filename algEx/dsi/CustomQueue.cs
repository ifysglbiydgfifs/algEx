namespace algEx.dsi
{
    public class CustomQueue<T>
    {
        private LinkedList<T> list;

        public CustomQueue()
        {
            list = new LinkedList<T>();
        }

        // Добавление элемента в очередь
        public void Push(T value)
        {
            list.Append(value);  // Добавляем элемент в конец списка
        }

        // Удаление элемента из очереди
        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Очередь пуста.");
            }

            T value = list.Head.Value;  // Сохраняем значение первого элемента
            list.Delete(value);  // Удаляем первый элемент
            return value;
        }

        // Получение первого элемента без его удаления
        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Очередь пуста.");
            }

            return list.Head.Value;  // Возвращаем значение первого элемента
        }

        // Проверка, пуста ли очередь
        public bool IsEmpty()
        {
            return list.Count == 0;
        }

        // Печать элементов очереди
        public void Print()
        {
            list.Print();
        }
    }
}