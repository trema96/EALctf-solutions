using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient tcp = new TcpClient("jlab13.eal.dk", 11102);

            Stream str = tcp.GetStream();

            StreamReader sr = new StreamReader(str);
            StreamWriter sw = new StreamWriter(str);
            sw.AutoFlush = true;


            Graph graph = new Graph();
            while (true)
            {
                string fullRead = sr.ReadLine();
                Console.WriteLine(fullRead);
                string[] read = fullRead.Split(' ');
                if (read.Length == 3)
                {
                    graph.AddEdge(Int32.Parse(read[0]), Int32.Parse(read[1]), Int32.Parse(read[2]));
                }
                else
                {
                    int res = graph.Shortest(Int32.Parse(read[0]), Int32.Parse(read[1]));
                    sw.WriteLine(res + "\n");
                    Console.WriteLine(res);
                }
            }
            Console.ReadKey();
        }
    }
}
