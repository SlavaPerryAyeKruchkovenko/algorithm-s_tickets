namespace Algorithms;

public static class BinaryTree
{
    public class TreeNode
    {
        public TreeNode(int value)
        {
            Value = value;
        }
        
        private int Value { get; set; }
        
        private TreeNode? Left { get; set; }
        
        private TreeNode? Right { get; set; }
        
        public void Insert(TreeNode node)
        {
            if (node.Value < Value)
            {
                if (Left == null)
                {
                    Left = node;
                }
                else
                {
                    Left.Insert(node);
                }
            }
            else
            {
                if (Right == null)
                {
                    Right = node;
                }
                else
                {
                    Right.Insert(node);
                }
            }
        }
        public int[] Transform(List<int>? elements = null)
        {
            elements ??= new List<int>();

            Left?.Transform(elements);

            elements.Add(Value);

            Right?.Transform(elements);

            return elements.ToArray();
        }
    }
    public static int BinarySearch(int key,int[] arr,int min,int max)
    {
        if (max < min) return -1;
        var middle = (min + max) / 2;
        var value = arr[middle];
        if (value == key)
            return middle;
        else
            return value > key ? BinarySearch(key, arr, min, middle - 1) : BinarySearch(key, arr, middle + 1, max);
    }

    public static int[] BinarySort(int[] arr)
    {
        var treeNode = new TreeNode(arr[0]);
        for (int i = 1; i < arr.Length; i++)
        {
            treeNode.Insert(new TreeNode(arr[i]));
        }

        return treeNode.Transform();
    }
}