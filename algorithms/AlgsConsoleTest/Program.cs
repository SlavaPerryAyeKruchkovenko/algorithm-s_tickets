// See https://aka.ms/new-console-template for more information

using Algorithms;

var graph = new Graph<string>();

graph.AddNode("1");
graph.AddNode("2");
graph.AddNode("3");
graph.AddNode("4");
graph.AddNode("5");
graph.AddNode("6");

graph.Connect(0,1,"1",6);
graph.Connect(0,2,"2",1);
graph.Connect(1,2,"3",5);
graph.Connect(0,3,"4",5);
graph.Connect(2,3,"5",5);
graph.Connect(1,4,"6",3);
graph.Connect(2,4,"7",6);
graph.Connect(3,5,"8",2);
graph.Connect(2,5,"9",4);

var list =  GraphAlgs.Dijkstra(graph,graph[0],graph[5]);
foreach (var node in list)
{
    Console.WriteLine($"{node.Name}");
}