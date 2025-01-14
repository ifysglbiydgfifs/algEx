using System;
using System.Collections.Generic;

namespace DFSAlgorithmWithLogging
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

        // Вспомогательный метод для выполнения DFS
        private void DFSUtil(int vertex, bool[] visited)
        {
            // Помечаем текущую вершину как посещённую
            visited[vertex] = true;
            Console.WriteLine($"Посещена вершина: {vertex}");

            // Рекурсивно посещаем все соседние вершины
            foreach (int neighbor in adjacencyList[vertex])
            {
                if (!visited[neighbor])
                {
                    Console.WriteLine($"Переходим по рёбру от вершины {vertex} к вершине {neighbor}.");
                    DFSUtil(neighbor, visited); // Рекурсивно продолжаем обход
                }
                else
                {
                    Console.WriteLine($"Вершина {neighbor} уже посещена. Возвращаемся назад.");
                }
            }
        }

        // Основной метод для выполнения DFS
        public void DFS(int startVertex)
        {
            Console.WriteLine($"Начинаем обход в глубину с вершины {startVertex}.\n");

            // Массив для отслеживания посещённых вершин
            bool[] visited = new bool[VerticesCount];

            // Вызываем вспомогательную функцию для DFS
            DFSUtil(startVertex, visited);

            Console.WriteLine("\nОбход в глубину завершён: все вершины, до которых можно добраться, посещены.");
        }
    }

    public class DFSRUN
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

            Console.WriteLine("Обход графа в глубину с подробным логгированием:\n");
            graph.DFS(0); // Начинаем обход с вершины 0
        }
    }
}
