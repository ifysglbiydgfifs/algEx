namespace algEx;
public class TreeSort
{
    // Определение узла бинарного дерева
    public class Node
    {
        public int Data;
        public Node Left, Right;

        public Node(int item)
        {
            Data = item;
            Left = Right = null;
        }
    }

    public Node root;

    // Конструктор для создания пустого дерева
    public TreeSort()
    {
        root = null;
    }

    // Вставка нового элемента в дерево
    public void Insert(int data)
    {
        root = InsertRec(root, data);
    }

    // Рекурсивный метод для вставки элемента
    private Node InsertRec(Node root, int data)
    {
        // Если дерево пусто, создаем новый узел
        if (root == null)
        {
            root = new Node(data);
            return root;
        }

        // Вставляем элемент в левое или правое поддерево
        if (data < root.Data)
            root.Left = InsertRec(root.Left, data);
        else if (data > root.Data)
            root.Right = InsertRec(root.Right, data);

        return root;
    }

    // Метод для обхода дерева (in-order) и сортировки массива
    public void InOrder(Node root, int[] sortedArray, ref int index)
    {
        if (root != null)
        {
            InOrder(root.Left, sortedArray, ref index);
            sortedArray[index++] = root.Data;
            InOrder(root.Right, sortedArray, ref index);
        }
    }

    // Основной метод сортировки
    public void Run(int[] array)
    {
        // Вставляем элементы массива в бинарное дерево поиска
        foreach (var item in array)
        {
            Insert(item);
        }

        // Обходим дерево in-order и записываем элементы в исходный массив
        int index = 0;
        InOrder(root, array, ref index);
    }
}