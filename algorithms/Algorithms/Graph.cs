namespace Algorithms;
using System.Linq;
public class Graph<TKey>
{
    private List<MyNode<TKey>> nodes = new List<MyNode<TKey>>();

    public Graph()
    {
        
    }

    public int Length { get { return nodes.Count; } }

    public MyNode<TKey> this[int index] { get { return nodes[index]; } }

    public IEnumerable<MyNode<TKey>> Nodes
    {
        get
        {
            foreach (var node in nodes) yield return node;
        }
    }

    public void AddNode(TKey name)
    {
        nodes.Add(new MyNode<TKey>(name));
    }

    public Edge<TKey> Connect(int index1, int index2,TKey name,int value)
    {
        return nodes[index1].Connect(nodes[index2],name,value);
    }

    public void Delete(Edge<TKey> edge)
    {
        MyNode<TKey>.Disconnect(edge);
    }

    public IEnumerable<Edge<TKey>> Edges
    {
        get
        {
            return nodes.SelectMany(z => z.IncedentEdge).Distinct();
        }
    }
    
}

public class MyNode<TKey>
{
    readonly List<Edge<TKey>> edges = new List<Edge<TKey>>();
    public readonly TKey Name;
    public MyNode(TKey name)
    {
        Name = name;
    }
    
    public IEnumerable<MyNode<TKey>> IncedentNode => edges.Select(z => z.OtherNode(this));
    public IEnumerable<Edge<TKey>> IncedentEdge => edges.Select(x=>x);
    
    public Edge<TKey> Connect(MyNode<TKey> nextNode,TKey name,int value)
    {
        var edge = new Edge<TKey>(name, nextNode, this,value);
        edges.Add(edge);
        nextNode.edges.Add(edge);
        return edge;
    }
    public static void Disconnect(Edge<TKey> edge)
    {
        edge.From.edges.Remove(edge);
        edge.To.edges.Remove(edge);
    }
}

public class Edge<TKey>
{
    public readonly int Value;
    public readonly TKey Name;
    public Edge(TKey name,MyNode<TKey> to,MyNode<TKey> from,int value)
    {
        Value = value;
        To = to;
        From = from;
        Name = name;
    }
    public MyNode<TKey> To { get; private set; }
    public MyNode<TKey> From { get; private set; }
    public bool IsIncident(MyNode<TKey> node)
    {
        return From == node || To == node;
    }
    public MyNode<TKey> OtherNode(MyNode<TKey> node)
    {
        if (!IsIncident(node)) throw new ArgumentException();
        if (From == node) return To;
        return From;
    }

}