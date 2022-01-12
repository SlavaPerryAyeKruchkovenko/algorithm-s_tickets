namespace Algorithms;

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
        // Внимание! Перед использованием этого кода, прочитайте следующий слайд «Использование памяти»
        var visited = new HashSet<MyNode<string>>();
        var stack = new Stack<MyNode<string>>();
        stack.Push(graph[0]);
        while (stack.Count != 0)
        {
            var node = stack.Pop();
            if (visited.Contains(node)) continue;
            visited.Add(node);
            yield return node;
            foreach (var incidentNode in node.)
                stack.Push(incidentNode);
        }
    }

    public static IEnumerable<MyNode<string>> BreadthSearch(Graph<string> graph)
    {
        // Внимание! Перед использованием этого кода, прочитайте следующий слайд «Использование памяти»
        var visited = new HashSet<MyNode<string>>();
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
}