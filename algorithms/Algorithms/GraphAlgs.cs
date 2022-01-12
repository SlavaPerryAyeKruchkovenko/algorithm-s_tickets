namespace Algorithms;

public static class GraphAlgs
{
    public static List<Edge<string>> PrimAlgorithm(Graph<string> graph)
    {
        var list = new List<Edge<string>>();
        //неиспользованные ребра
        var notPassedEdges = new List<Edge<string>>(graph.Edges);
        //использованные вершины
        var passedNodes = new List<MyNode<string>>();
        //неиспользованные вершины
        var notPassedNodes = new List<MyNode<string>>(graph.Nodes);
        //выбираем случайную начальную вершину
        var bestEdge = graph.Edges.Where(x=>x.Value==graph.Edges.Min(x=>x.Value)).First();
        passedNodes.Add(bestEdge.From);
        notPassedNodes.Remove(bestEdge.From);
        while (notPassedNodes.Count > 0)
        {
            var minEdgeIndex = -1; //номер наименьшего ребра
            //поиск наименьшего ребра
            for (var i = 0; i < notPassedEdges.Count; i++)
            {
                var edge = notPassedEdges[i];
                if (passedNodes.IndexOf(edge.To) != -1 && notPassedNodes.IndexOf(edge.From) != -1 ||
                    passedNodes.IndexOf(edge.From) != -1 && notPassedNodes.IndexOf(edge.To) != -1)
                {
                    if (minEdgeIndex != -1)
                    {
                        if (notPassedEdges[i].Value < notPassedEdges[minEdgeIndex].Value)
                            minEdgeIndex = i;
                    }
                    else
                        minEdgeIndex = i;
                }
            }
            //заносим новую вершину в список использованных и удаляем ее из списка неиспользованных
            var minEdge = notPassedEdges[minEdgeIndex];
            if (passedNodes.IndexOf(notPassedEdges[minEdgeIndex].To) != -1)
            {
                passedNodes.Add(notPassedEdges[minEdgeIndex].From);
                notPassedNodes.Remove(notPassedEdges[minEdgeIndex].From);
            }
            else
            {
                passedNodes.Add(notPassedEdges[minEdgeIndex].To);
                notPassedNodes.Remove(notPassedEdges[minEdgeIndex].To);
            }
            //заносим новое ребро в дерево и удаляем его из списка неиспользованных
            list.Add(notPassedEdges[minEdgeIndex]);
            notPassedEdges.RemoveAt(minEdgeIndex);
        }

        return list;
    }
}