using System;
using System.Collections.Generic;
using System.Linq;

namespace KruskalAlgorithm
{
    public class Edge : IComparable<Edge>
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

        // Сравнение по весу, для сортировки рёбер
        public int CompareTo(Edge other)
        {
            return this.Weight.CompareTo(other.Weight);
        }
    }

    public class Graph
    {
        public int VerticesCount { get; private set; }
        public List<Edge> Edges { get; private set; }

        public Graph(int verticesCount)
        {
            VerticesCount = verticesCount;
            Edges = new List<Edge>();
        }

        // Добавление ребра в граф
        public void AddEdge(int source, int destination, int weight)
        {
            Edges.Add(new Edge(source, destination, weight));
        }

        // Находим корень вершины
        private int Find(int[] parent, int vertex)
        {
            if (parent[vertex] != vertex)
                parent[vertex] = Find(parent, parent[vertex]);
            return parent[vertex];
        }

        // Объединение двух множеств (по весу)
        private void Union(int[] parent, int[] rank, int root1, int root2)
        {
            if (rank[root1] < rank[root2])
            {
                parent[root1] = root2;
            }
            else if (rank[root1] > rank[root2])
            {
                parent[root2] = root1;
            }
            else
            {
                parent[root2] = root1;
                rank[root1]++;
            }
        }

        // Реализация алгоритма Крускала
        public List<Edge> KruskalMST()
        {
            List<Edge> result = new List<Edge>(); // Это будет минимальное остовное дерево
            Edges.Sort(); // Сортируем рёбра по весу

            // Массив для хранения родителя каждой вершины (для объединения)
            int[] parent = new int[VerticesCount];
            int[] rank = new int[VerticesCount]; // Ранг для оптимизации

            // Изначально каждая вершина — отдельное множество (родитель самой себе)
            for (int i = 0; i < VerticesCount; i++)
            {
                parent[i] = i;
                rank[i] = 0;
            }

            foreach (var edge in Edges)
            {
                int root1 = Find(parent, edge.Source);
                int root2 = Find(parent, edge.Destination);

                // Если вершины принадлежат разным множествам, объединяем их
                if (root1 != root2)
                {
                    result.Add(edge); // Добавляем ребро в остовное дерево
                    Union(parent, rank, root1, root2); // Объединяем множества
                }
            }

            return result;
        }
    }

    public class Kruskal
    {
        public static void Run()
        {
            int vertices = 6; // Количество вершин в графе
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

            // Выполняем алгоритм Крускала
            var mst = graph.KruskalMST();

            Console.WriteLine("Минимальное остовное дерево содержит следующие рёбра:");
            foreach (var edge in mst)
            {
                Console.WriteLine($"Источник: {edge.Source}, Назначение: {edge.Destination}, Вес: {edge.Weight}");
            }
        }
    }
}
