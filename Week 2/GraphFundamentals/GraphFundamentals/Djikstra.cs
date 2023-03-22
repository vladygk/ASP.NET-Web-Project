using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphFundamentals
{
    public class Edge
    {
        public Edge(int from, int to, int time, int price)
        {
            this.Price = price;
            this.From = from;
            this.To = to;
            this.Time = time;
        }
        public int From { get; set; }
        public int To { get; set; }
        public int Price { get; set; }
        public int Time { get; set; }
    }
    public class Djikstra
    {
        public static string CalculatePathTimeCost(
            int pricePerHour,
             int nodes
            , int edges
            , List<string> input
            , int startNode
            , int endNode)
        {
            int hours = 0;
            List<Edge>[] graph = new List<Edge>[nodes + 1];
            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new List<Edge>();
            }

            for (int i = 0; i < edges; i++)
            {
                var edgeData = input[i]
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var from = edgeData[0];
                var to = edgeData[1];
                var time = edgeData[2];
                var price = edgeData[3];
                var edgeFrom = new Edge(from, to, time, price);

                graph[from].Add(edgeFrom);


                var edgeTo = new Edge(to, from, price, time);
                graph[to].Add(edgeTo);
            }



            double[] prices = new double[nodes + 1];
            double[] times = new double[nodes + 1];
            int[] previous = new int[nodes + 1];

            Array.Fill(previous, -1);
            Array.Fill(prices, double.PositiveInfinity);
            Array.Fill(times, double.PositiveInfinity);

            PriorityQueue<int, double> bag = new PriorityQueue<int, double>();

            foreach (Edge edge in graph[startNode])
            {
                prices[edge.To] = edge.Price;
                times[edge.To] = edge.Time;

                bag.Enqueue(edge.To, prices[edge.To]);
            }

            while (bag.Count > 0)
            {
                var minNode = bag.Dequeue();



                if (minNode == startNode)
                {
                    break;
                }


                foreach (var child in graph[minNode])
                {
                    if (double.IsPositiveInfinity(prices[child.To]))
                    {
                        bag.Enqueue(child.To, prices[child.To]);
                    }

                    var newDistance = prices[minNode] + child.Price;
                    var newTime = times[minNode] + child.Time;
                    if (newDistance < prices[child.To])
                    {
                        prices[child.To] = newDistance;
                        previous[child.To] = child.From;
                    }
                    if (newTime < times[child.To])
                    {
                        times[child.To] = newTime;
                    }

                }
            }

            var index = endNode;
            var path = new Stack<int>();
            while (index != -1)
            {
                path.Push(index);
                index = previous[index];

            }
            path.Push(startNode);


            StringBuilder result = new StringBuilder();
            result.Append(String.Join("-> ", path)); //apend path
            result.Append(" ");
            result.Append(times[endNode] + path.Count - 2); //append time
            result.Append(" ");
            result.Append(prices[endNode] + pricePerHour * (path.Count - 2 + times[endNode]) + " "); // append price




            return result.ToString().Trim();
        }
    }





}
