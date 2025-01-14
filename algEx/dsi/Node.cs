namespace algEx.dsi;

public class Node<T>
{
    public T Value { get; set; }
    public Node<T> Next { get; set; }  // Указатель на следующий узел
    public Node<T> Prev { get; set; }  // Указатель на предыдущий узел

    public Node(T value)
    {
        Value = value;
        Next = null;
        Prev = null;
    }
}

