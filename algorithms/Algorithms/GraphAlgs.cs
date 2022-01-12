namespace Algorithms;
using System.Linq;
public static class GraphAlgs
{
    
    private class NodeInformation
    {
        public NodeInformation(MyNode<string> head)
        {
            Head = head;
        }
        public MyNode<string> Head;
        public double value = double.MaxValue;
    }
    public static List<MyNode<string>> Dijkstra(Graph<string> graph, MyNode<string> start, MyNode<string> end)
    {
        var notVisited = new List<MyNode<string>>(graph.Nodes);
        var dictonary = new Dictionary<MyNode<string>, NodeInformation>();

        dictonary.Add(start,new NodeInformation(null){value = 0});
        var nowNode = start;
        while (nowNode != end)
        {
            nowNode = null;
            var minValue = double.MaxValue;
            foreach (var node in notVisited)
            {
                if (dictonary.ContainsKey(node)&&dictonary[node].value<minValue)
                {
                    minValue = dictonary[node].value;
                    nowNode = node;
                }
            }

            if (nowNode == null) throw new Exception("NotCorrect graph");
            foreach (var edge in nowNode.IncedentEdge.Where(z => z.From == nowNode))
            {
                var currentPrice = dictonary[nowNode].value + edge.Value;
                var nextNode = edge.OtherNode(nowNode);
                if (!dictonary.ContainsKey(nextNode) || dictonary[nextNode].value > currentPrice)
                {
                    dictonary[nextNode] = new NodeInformation(nowNode) { value = currentPrice };
                }
            }

            notVisited.Remove(nowNode);
        }
        var path = new List<MyNode<string>>();
        nowNode = end;
        path.Add(nowNode);
        while (nowNode != start)
        {
            nowNode = dictonary[nowNode].Head;
            path.Add(nowNode);
        }

        path.Reverse();
        return path;
    }
}