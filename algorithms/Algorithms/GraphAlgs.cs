namespace Algorithms;
using System.Linq;
public static class GraphAlgs
{
    public static List<Edge<string>> PrimAlgorithm(Graph<string> graph)
    {
        var list = new List<Edge<string>>();
        var notUsedEdges = new List<Edge<string>>(graph.Edges);
        var passedNodes = new List<MyNode<string>>();
        var notUsedNodes = new List<MyNode<string>>(graph.Nodes);
        var rndNode = graph[0];
        passedNodes.Add(rndNode);
        notUsedNodes.Remove(rndNode);
        for (var i = 0; i < graph.Length-1; i++)
        {
            var minEdge = notUsedEdges.First();
            foreach (var edge in notUsedEdges)
            {
                if (minEdge.Value > edge.Value && (passedNodes.Contains(edge.To) && notUsedNodes.Contains(edge.From)||
                    passedNodes.Contains(edge.From) && notUsedNodes.Contains(edge.To)))
                {
                    minEdge = edge;
                }
            }
            list.Add(minEdge);
            if (passedNodes.Contains(minEdge.To))
            {
                passedNodes.Add(minEdge.From);
                notUsedNodes.Remove(minEdge.From);
            }
            else
            {
                passedNodes.Add(minEdge.To);
                notUsedNodes.Remove(minEdge.To);
            }
        }
        return list;
    }
    public static IEnumerable<MyNode<string>> DepthSearch(Graph<string> graph)
    {
        var visited = new List<MyNode<string>>();
        var stack = new Stack<MyNode<string>>();
        stack.Push(graph[0]);
        while (stack.Count != 0)
        {
            var node = stack.Pop();
            if (visited.Contains(node)) continue;
            visited.Add(node);
            yield return node;
            foreach (var incidentNode in node.IncedentNode)
                stack.Push(incidentNode);
        }
    }

    public static IEnumerable<MyNode<string>> BreadthSearch(Graph<string> graph)
    {
        var visited = new List<MyNode<string>>();
        var queue = new Queue<MyNode<string>>();
        queue.Enqueue(graph[0]);
        while (queue.Count != 0)
        {
            var node = queue.Dequeue();
            if (visited.Contains(node)) continue;
            visited.Add(node);
            yield return node;
            foreach (var incidentNode in node.IncedentNode)
                queue.Enqueue(incidentNode);
        }
    }
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