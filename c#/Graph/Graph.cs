using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Graph
    {
        private Dictionary<int, Dictionary<int, int>> val = new Dictionary<int, Dictionary<int, int>>();
        private Dictionary<int, int> costs;

        public void AddEdge(int node1, int node2, int cost)
        {
            if (!val.ContainsKey(node1))
            {
                val.Add(node1, new Dictionary<int, int>());
            }
            if (!val.ContainsKey(node2))
            {
                val.Add(node2, new Dictionary<int, int>());
            }
            
            if (val[node1].ContainsKey(node2))
            {
                if (val[node1][node2] > cost)
                {
                    val[node1][node2] = cost;
                    val[node2][node1] = cost;
                }
            }
            else
            {
                val[node1].Add(node2, cost);
                val[node2].Add(node1, cost);
            }
        }
        
        public int Shortest(int start, int end)
        {
            if (start == end)
            {
                return 0;
            }

            costs = new Dictionary<int, int>();

            ShortestRec(start, 0);

            return costs[end];
        }

        private void ShortestRec(int node, int cost)
        {
            if (!costs.ContainsKey(node) || costs[node] > cost)
            {
                if (costs.ContainsKey(node))
                {
                    costs[node] = cost;
                }
                else
                {
                    costs.Add(node, cost);
                }
                foreach (var pair in val[node])
                {
                    ShortestRec(pair.Key, pair.Value + cost);
                }
            }
        }
    }
}
