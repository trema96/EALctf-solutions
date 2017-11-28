using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CTF
{
    class Program
    {

        private Dictionary<char, char> translationMap = new Dictionary<char, char>();
        static void Main(string[] args)
        {
            new Program().doIt();
        }

        public void doIt()
        {
            translationMap.Add('a', 'y');
            translationMap.Add('b', 'h');
            translationMap.Add('c', 'e');
            translationMap.Add('d', 's');
            translationMap.Add('e', 'o');
            translationMap.Add('f', 'c');
            translationMap.Add('g', 'v');
            translationMap.Add('h', 'x');
            translationMap.Add('i', 'd');
            translationMap.Add('j', 'u');
            translationMap.Add('k', 'i');
            translationMap.Add('l', 'g');
            translationMap.Add('m', 'l');
            translationMap.Add('n', 'b');
            translationMap.Add('o', 'k');
            translationMap.Add('p', 'r');
            translationMap.Add('r', 't');
            translationMap.Add('s', 'n');
            translationMap.Add('t', 'w');
            translationMap.Add('u', 'j');
            translationMap.Add('v', 'p');
            translationMap.Add('w', 'f');
            translationMap.Add('x', 'm');
            translationMap.Add('y', 'a');
            translationMap.Add('q', 'z');
            translationMap.Add('z', 'q');
            translationMap.Add('!', '!');

            TcpClient tcp = new TcpClient("jlab13.eal.dk", 11103);

            Stream str = tcp.GetStream();

            StreamReader sr = new StreamReader(str);
            StreamWriter sw = new StreamWriter(str);
            sw.AutoFlush = true;

            int c = 0;
            for (int i = 0; i < 1000; i++)
            {
                string line = sr.ReadLine();
                Console.WriteLine(line);

                if (line == "WRONG ANSWER!")
                {
                    break;
                }
                string translated = translate(line);
                sw.WriteLine(translated);
                sw.Flush();
                Console.WriteLine(translated);
                c++;
                Console.WriteLine(c);
            }
            Console.ReadKey();
        }

        private string translate(string s)
        {
            StringBuilder builder = new StringBuilder();
            foreach (char c in s)
            {
                if (c == ' ')
                {
                    builder.Append(' ');
                }
                else if (Char.IsUpper(c))
                {
                    builder.Append(Char.ToUpper(translationMap[Char.ToLower(c)]));
                }
                else
                {
                    //Console.WriteLine(c);
                    builder.Append(translationMap[c]);
                }
            }
            return builder.ToString();
        }
    }
}
