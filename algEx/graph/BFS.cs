using System;
using System.Collections.Generic;

namespace BFSAlgorithmWithLogging
{
    public class Graph
    {
        private int VerticesCount; // Количество вершин в графе
        private List<int>[] adjacencyList; // Список смежности

        // Конструктор для создания графа с указанным количеством вершин
        public Graph(int verticesCount)
        {
            VerticesCount = verticesCount;
            adjacencyList = new List<int>[verticesCount];
            for (int i = 0; i < verticesCount; i++)
            {
                adjacencyList[i] = new List<int>();
            }
        }

        // Добавляем ребро в граф
        public void AddEdge(int source, int destination)
        {
            adjacencyList[source].Add(destination);
            adjacencyList[destination].Add(source); // Для неориентированного графа
        }

        // Метод для выполнения BFS
        public void BFS(int startVertex)
        {
            Console.WriteLine($"Начинаем обход в ширину с вершины {startVertex}.\n");

            // Массив для отслеживания посещённых вершин
            bool[] visited = new bool[VerticesCount];

            // Очередь для обхода вершин
            Queue<int> queue = new Queue<int>();

            // Помечаем стартовую вершину как посещённую и добавляем её в очередь
            visited[startVertex] = true;
            queue.Enqueue(startVertex);
            Console.WriteLine($"Посещена вершина: {startVertex}");

            while (queue.Count != 0)
            {
                // Извлекаем вершину из очереди
                int currentVertex = queue.Dequeue();

                // Получаем всех соседей этой вершины
                foreach (int neighbor in adjacencyList[currentVertex])
                {
                    if (!visited[neighbor])
                    {
                        // Если вершина ещё не посещена, помечаем её как посещённую и добавляем в очередь
                        visited[neighbor] = true;
                        queue.Enqueue(neighbor);
                        Console.WriteLine($"Переходим по рёбру от вершины {currentVertex} к вершине {neighbor}.");
                        Console.WriteLine($"Посещена вершина: {neighbor}");
                    }
                    else
                    {
                        Console.WriteLine($"Вершина {neighbor} уже посещена. Пропускаем её.");
                    }
                }
            }

            Console.WriteLine("\nОбход в ширину завершён: все вершины, до которых можно добраться, посещены.");
        }
    }

    public class BFSRUN
    {
        public static void Run()
        {
            // Создаём граф с 6 вершинами
            Graph graph = new Graph(6);

            // Добавляем рёбра
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(1, 3);
            graph.AddEdge(1, 4);
            graph.AddEdge(2, 5);

            Console.WriteLine("Обход графа в ширину с подробным логгированием:\n");
            graph.BFS(0); // Начинаем обход с вершины 0
        }
    }
}
