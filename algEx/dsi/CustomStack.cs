namespace algEx.dsi
{
    public class CustomStack<T>
    {
        private LinkedList<T> list;

        public CustomStack()
        {
            list = new LinkedList<T>();
        }

        // Добавление элемента на стек
        public void Push(T value)
        {
            list.Insert(value);  // Добавляем элемент в начало списка
        }

        // Удаление элемента с вершины стека
        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Стек пуст.");
            }

            T value = list.Head.Value;  // Сохраняем значение верхнего элемента
            list.Delete(value);  // Удаляем верхний элемент
            return value;
        }

        // Получение верхнего элемента без его удаления
        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Стек пуст.");
            }

            return list.Head.Value;  // Возвращаем значение верхнего элемента
        }

        // Проверка, пуст ли стек
        public bool IsEmpty()
        {
            return list.Count == 0;
        }

        // Печать элементов стека
        public void Print()
        {
            list.Print();
        }
    }
}