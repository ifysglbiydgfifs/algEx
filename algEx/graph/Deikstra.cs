using System;
using System.Collections.Generic;

namespace DijkstraAlgorithm
{
    public class Graph
    {
        private int VerticesCount; // Количество вершин в графе
        private List<Tuple<int, int>>[] adjacencyList; // Список смежности, где Tuple<int, int> - вершина и вес ребра

        // Конструктор для создания графа с указанным количеством вершин
        public Graph(int verticesCount)
        {
            VerticesCount = verticesCount;
            adjacencyList = new List<Tuple<int, int>>[verticesCount];
            for (int i = 0; i < verticesCount; i++)
            {
                adjacencyList[i] = new List<Tuple<int, int>>();
            }
        }

        // Добавляем ребро в граф
        public void AddEdge(int source, int destination, int weight)
        {
            adjacencyList[source].Add(new Tuple<int, int>(destination, weight));
            adjacencyList[destination].Add(new Tuple<int, int>(source, weight)); // Если граф неориентированный
        }

        // Метод для выполнения алгоритма Дейкстры
        public void Dijkstra(int startVertex)
        {
            // Массив для отслеживания минимальных расстояний от стартовой вершины
            int[] distances = new int[VerticesCount];
            bool[] shortestPathSet = new bool[VerticesCount]; // Массив для проверки посещённых вершин

            // Инициализируем все расстояния как бесконечные, кроме стартовой вершины
            for (int i = 0; i < VerticesCount; i++)
            {
                distances[i] = int.MaxValue;
                shortestPathSet[i] = false;
            }
            distances[startVertex] = 0;

            // Проходим по всем вершинам
            for (int count = 0; count < VerticesCount - 1; count++)
            {
                // Выбираем вершину с минимальным расстоянием из множества непосещённых вершин
                int u = GetMinimumDistanceVertex(distances, shortestPathSet);

                // Помечаем вершину как посещённую
                shortestPathSet[u] = true;

                // Обновляем значения расстояний соседей выбранной вершины
                foreach (var neighbor in adjacencyList[u])
                {
                    int vertex = neighbor.Item1;
                    int weight = neighbor.Item2;

                    if (!shortestPathSet[vertex] && distances[u] != int.MaxValue && distances[u] + weight < distances[vertex])
                    {
                        distances[vertex] = distances[u] + weight;
                    }
                }
            }

            // Выводим кратчайшие расстояния от стартовой вершины
            Print(distances);
        }

        // Вспомогательный метод для нахождения вершины с минимальным расстоянием
        private int GetMinimumDistanceVertex(int[] distances, bool[] shortestPathSet)
        {
            int min = int.MaxValue;
            int minIndex = -1;

            for (int v = 0; v < VerticesCount; v++)
            {
                if (!shortestPathSet[v] && distances[v] <= min)
                {
                    min = distances[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }

        // Выводим расстояния до каждой вершины
        private void Print(int[] distances)
        {
            Console.WriteLine("Вершина\t|Минимальное расстояние от стартовой вершины");
            for (int i = 0; i < VerticesCount; i++)
            {
                Console.WriteLine($"{i}\t|\t{distances[i]}");
            }
        }
    }

    public class DeikstraRun
    {
        public static void Run()
        {
            // Создаём граф с 6 вершинами
            Graph graph = new Graph(6);

            // Добавляем рёбра с весами
            graph.AddEdge(0, 1, 4);
            graph.AddEdge(0, 2, 1);
            graph.AddEdge(2, 1, 2);
            graph.AddEdge(2, 3, 5);
            graph.AddEdge(1, 3, 1);
            graph.AddEdge(3, 4, 3);
            graph.AddEdge(4, 5, 2);

            Console.WriteLine("Алгоритм Дейкстры для поиска кратчайшего пути:");
            graph.Dijkstra(0); // Запускаем алгоритм Дейкстры начиная с вершины 0
        }
    }
}
