using System;
using System.Collections.Generic;

namespace PrimAlgorithm
{
    public class Edge
    {
        public int Source { get; private set; }
        public int Destination { get; private set; }
        public int Weight { get; private set; }

        public Edge(int source, int destination, int weight)
        {
            Source = source;
            Destination = destination;
            Weight = weight;
        }
    }

    public class Graph
    {
        private int VerticesCount;
        private List<Edge>[] adjacencyList;

        public Graph(int verticesCount)
        {
            VerticesCount = verticesCount;
            adjacencyList = new List<Edge>[verticesCount];

            for (int i = 0; i < verticesCount; i++)
            {
                adjacencyList[i] = new List<Edge>();
            }
        }

        // Добавление ребра в граф
        public void AddEdge(int source, int destination, int weight)
        {
            Edge edge1 = new Edge(source, destination, weight);
            Edge edge2 = new Edge(destination, source, weight);
            adjacencyList[source].Add(edge1);
            adjacencyList[destination].Add(edge2); // Так как граф неориентированный
        }

        // Алгоритм Прима для нахождения минимального остовного дерева
        public void PrimMST()
        {
            // Массив для отслеживания минимального веса для каждой вершины
            int[] key = new int[VerticesCount];
            // Массив для отслеживания включения вершины в минимальное остовное дерево
            bool[] mstSet = new bool[VerticesCount];
            // Массив для хранения родителя каждой вершины
            int[] parent = new int[VerticesCount];

            // Инициализация всех ключей максимальным значением
            for (int i = 0; i < VerticesCount; i++)
            {
                key[i] = int.MaxValue;
                mstSet[i] = false;
            }

            // Начинаем с первой вершины, ее ключ = 0
            key[0] = 0;
            parent[0] = -1; // Первая вершина — корень остовного дерева

            for (int count = 0; count < VerticesCount - 1; count++)
            {
                // Выбираем вершину с минимальным ключом, которая ещё не включена в MST
                int u = MinKey(key, mstSet);

                // Добавляем вершину в MST
                mstSet[u] = true;

                // Обновляем значения ключей для соседей выбранной вершины
                foreach (var edge in adjacencyList[u])
                {
                    int v = edge.Destination;
                    int weight = edge.Weight;

                    // Если вершина v ещё не включена в MST и вес ребра (u, v) меньше текущего ключа для v
                    if (!mstSet[v] && weight < key[v])
                    {
                        parent[v] = u;
                        key[v] = weight;
                    }
                }
            }

            // Вывод минимального остовного дерева
            PrintMST(parent);
        }

        // Функция для нахождения вершины с минимальным ключом, которая ещё не включена в MST
        private int MinKey(int[] key, bool[] mstSet)
        {
            int min = int.MaxValue, minIndex = -1;

            for (int v = 0; v < VerticesCount; v++)
            {
                if (!mstSet[v] && key[v] < min)
                {
                    min = key[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }

        // Функция для вывода минимального остовного дерева
        private void PrintMST(int[] parent)
        {
            Console.WriteLine("Ребра минимального остовного дерева:");
            for (int i = 1; i < VerticesCount; i++)
            {
                Console.WriteLine($"{parent[i]} - {i}");
            }
        }
    }

    public class Prim
    {
        public static void Run()
        {
            int vertices = 6;
            Graph graph = new Graph(vertices);

            // Добавляем рёбра в граф
            graph.AddEdge(0, 1, 4);
            graph.AddEdge(0, 2, 4);
            graph.AddEdge(1, 2, 2);
            graph.AddEdge(1, 3, 6);
            graph.AddEdge(2, 3, 8);
            graph.AddEdge(2, 4, 9);
            graph.AddEdge(3, 4, 5);
            graph.AddEdge(3, 5, 11);
            graph.AddEdge(4, 5, 7);

            // Выполняем алгоритм Прима
            graph.PrimMST();
        }
    }
}
