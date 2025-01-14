namespace algEx.dsi;

public class LinkedList<T>
{
    // Указатель на первый (голову) и последний (хвост) элементы списка
    public Node<T> Head { get; private set; }
    public Node<T> Tail { get; private set; }

    public LinkedList()
    {
        Head = null;
        Tail = null;
    }

    // Вставка в начало списка
    public void Insert(T value)
    {
        var newNode = new Node<T>(value)
        {
            Next = Head
        };

        if (Head != null)
        {
            Head.Prev = newNode;
        }
        Head = newNode;

        // Если список был пуст, новый узел будет и хвостом
        if (Tail == null)
        {
            Tail = newNode;
        }
    }
    
    public void Append(T value)
    {
        var newNode = new Node<T>(value);

        if (Tail != null)
        {
            Tail.Next = newNode;
            newNode.Prev = Tail;
        }
        Tail = newNode;

        // Если список был пуст, новый узел будет и головой
        if (Head == null)
        {
            Head = newNode;
        }
    }

    // Поиск элемента в списке
    public T Search(T value)
    {
        var current = Head;
        while (current != null)
        {
            if (current.Value.Equals(value))
            {
                return current.Value;
            }
            current = current.Next;
        }

        return default(T);
    }

    // Удаление элемента из списка
    public bool Delete(T value)
    {
        if (Head == null) return false;

        // Если удаляем первый элемент
        if (Head.Value.Equals(value))
        {
            Head = Head.Next;
            if (Head != null) Head.Prev = null;
            else Tail = null; // Если список стал пустым, хвост тоже null
            return true;
        }

        var current = Head;
        while (current != null)
        {
            if (current.Value.Equals(value))
            {
                // Если удаляем последний элемент
                if (current.Next == null)
                {
                    Tail = current.Prev;
                    if (Tail != null) Tail.Next = null;
                }
                else
                {
                    current.Prev.Next = current.Next;
                    current.Next.Prev = current.Prev;
                }
                return true;
            }
            current = current.Next;
        }

        return false;
    }

    // Количество элементов в списке
    public int Count
    {
        get
        {
            int count = 0;
            var current = Head;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }
    }

    // Печать всех элементов списка
    public void Print()
    {
        var current = Head;
        while (current != null)
        {
            Console.Write($"[{current.Value}] ");
            current = current.Next;
        }
        Console.WriteLine();
    }

    // Печать всех элементов с конца (обратный обход)
    public void PrintReverse()
    {
        var current = Tail;
        while (current != null)
        {
            Console.Write($"[{current.Value}] ");
            current = current.Prev;
        }
        Console.WriteLine();
    }
}