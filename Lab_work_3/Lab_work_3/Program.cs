using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Diagnostics;

namespace BellmanFordAlgorithm
{
    class BellmanFordAlgo
    {
        public struct Edge
        {
            public int Source;
            public int Destination;
            public int Weight;
        }

        public struct Graph
        {
            public int VerticesCount;
            public int EdgesCount;
            public Edge[] edge;
        }

        public static Graph CreateGraph(int verticesCount, int edgesCount)
        {
            Graph graph = new Graph();
            graph.VerticesCount = verticesCount;
            graph.EdgesCount = edgesCount;
            graph.edge = new Edge[graph.EdgesCount];

            return graph;
        }

        private static void Print(int[] distance, int count)
        {
            Console.WriteLine("Результат записано в файл output.txt");
            StreamWriter sw = new StreamWriter("../../../../output.txt", false);
            for (int i = 0; i < count; ++i)
                sw.Write( distance[i]+" ");
            sw.Close();
        }

        public static void BellmanFord(Graph graph, int source)
        {
            int verticesCount = graph.VerticesCount;
            int edgesCount = graph.EdgesCount;
            int[] distance = new int[verticesCount];

            

            for (int i = 0; i < verticesCount; i++)
                distance[i] = int.MaxValue;

            distance[source] = 0;

            for (int i = 1; i <= verticesCount - 1; ++i)
            {
                for (int j = 0; j < edgesCount; ++j)
                {
                    int u = graph.edge[j].Source;
                    int v = graph.edge[j].Destination;
                    int weight = graph.edge[j].Weight;

                    if (distance[u] != int.MaxValue && distance[u] + weight < distance[v])
                        distance[v] = distance[u] + weight;
                }
            }

            for (int i = 0; i < edgesCount; ++i)
            {
                int u = graph.edge[i].Source;
                int v = graph.edge[i].Destination;
                int weight = graph.edge[i].Weight;

                if (distance[u] != int.MaxValue && distance[u] + weight < distance[v])
                    Console.WriteLine("Граф містить цикл від'ємної ваги");
            }

           
            Print(distance, verticesCount);
        }

        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("../../../../input.txt");
            string[] strok = File.ReadAllLines("../../../../input.txt");
            List<int> Num = new List<int>();
            if (strok.Length == 0)
            {
                throw new Exception("File is empty");
            }

            
            string numbers = sr.ReadLine();
            foreach (var number in numbers.Split())
            {
                int Varr = Convert.ToInt32(number);
                Num.Add(Varr);
            }
            
            int verticesCount = Num[0];
            int edgesCount = Num[1];
            string line;
            int i = 0;
            Graph graph = CreateGraph(verticesCount, edgesCount);
            while ((line = sr.ReadLine()) != null)
            {
                Num.Clear();
                
                foreach (var number in line.Split())
                {                   
                    int Varr = Convert.ToInt32(number);
                    Num.Add(Varr);
                }
                graph.edge[i].Source = Num[0];
                graph.edge[i].Destination = Num[1];
                graph.edge[i].Weight = Num[2];
                i++;
            }     


            BellmanFord(graph, 0);
            sr.Close();           
            
        }
    }
}