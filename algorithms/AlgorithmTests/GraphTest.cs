using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AlgorithmTests;
using Algorithms;
public class GraphTest
{
    private Graph<string> graph= new Graph<string>();

    public GraphTest()
    {
        graph.AddNode("1");
        graph.AddNode("2");
        graph.AddNode("3");
        graph.AddNode("4");
        graph.AddNode("5");
        graph.AddNode("6");
    }
    [Fact]
    public void PrimTest()
    {
        var eadge1 = graph.Connect(0,1,"1",6);
        var eadge2 =graph.Connect(0,2,"2",1);
        var eadge3 =graph.Connect(1,2,"3",5);
        var eadge4 =graph.Connect(0,3,"4",5);
        var eadge5 =graph.Connect(2,3,"5",5);
        var eadge6 =graph.Connect(1,4,"6",3);
        var eadge7 =graph.Connect(2,4,"7",6);
        var eadge8 =graph.Connect(3,5,"8",2);
        var eadge9 =graph.Connect(2, 5, "9", 4);
        var list =  GraphAlgs.PrimAlgorithm(graph);
        var res = new List<Edge<string>>();
        res.Add(eadge2);
        res.Add(eadge9);
        res.Add(eadge8);
        res.Add(eadge3);
        res.Add(eadge6);
        Assert.Equal(list,res);
    }
    [Fact]
    public void DejkstraTest()
    {
        graph.Connect(0,1,"1",6);
        graph.Connect(0,2,"2",1);
        graph.Connect(1,2,"3",5);
        graph.Connect(0,3,"4",5);
        graph.Connect(2,3,"5",5);
        graph.Connect(1,4,"6",3);
        graph.Connect(2,4,"7",6);
        graph.Connect(3,5,"8",2);
        graph.Connect(2, 5, "9", 4);
        var res = GraphAlgs.Dijkstra(graph, graph[0], graph[5]);
        var path = res.Select(x => x.Name);
        var result = new []{"1", "3", "6"};
        Assert.Equal(path,result);
    }
    
}