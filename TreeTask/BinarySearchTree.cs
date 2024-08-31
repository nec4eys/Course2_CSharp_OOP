namespace TreeTask;

public class BinarySearchTree<T>
{
    private TreeNode<T>? _root;

    public void Insert(T data)
    {
        _root = InsertRec(_root, data);
    }

    private static TreeNode<T>? InsertRec(TreeNode<T>? node, T data)
    {
        if (node == null)
        { 
            return new TreeNode<T>(data); 
        }

        int comparison = Comparer<T>.Default.Compare(data, node.Data);

        if (comparison < 0)
        { 
            node.LeftChild = InsertRec(node.LeftChild, data); 
        }
        else if (comparison > 0)
        { 
            node.RightChild = InsertRec(node.RightChild, data); 
        }

        return node;
    }

    public TreeNode<T>? Search(T data)
    {
        return SearchRec(_root, data);
    }

    private static TreeNode<T>? SearchRec(TreeNode<T>? node, T data)
    {
        if (node == null || node.Data.Equals(data))
        { 
            return node; 
        }

        return Comparer<T>.Default.Compare(data, node.Data) < 0 ? SearchRec(node.LeftChild, data) : SearchRec(node.RightChild, data);
    }

    public void Delete(T data)
    {
        _root = DeleteRec(_root, data);
    }

    private static TreeNode<T>? DeleteRec(TreeNode<T>? node, T data)
    {
        if (node == null) 
        { 
            return node; 
        }

        int comparison = Comparer<T>.Default.Compare(data, node.Data);

        if (comparison < 0)
        { 
            node.LeftChild = DeleteRec(node.LeftChild, data); 
        }
        else if (comparison > 0)
        { 
            node.RightChild = DeleteRec(node.RightChild, data); 
        }
        else
        {
            if (node.LeftChild == null) 
            { 
                return node.RightChild; 
            }
            else if (node.RightChild == null) 
            { 
                return node.LeftChild; 
            }

            node.Data = MinData(node.RightChild);
            node.RightChild = DeleteRec(node.RightChild, node.Data);
        }

        return node;
    }

    private static T MinData(TreeNode<T> node)
    {
        T minVData = node.Data;

        while (node.LeftChild != null)
        {
            minVData = node.LeftChild.Data;
            node = node.LeftChild;
        }

        return minVData;
    }

    public int Count()
    {
        return CountRec(_root);
    }

    private static int CountRec(TreeNode<T>? node)
    {
        if (node == null) 
        { 
            return 0; 
        }

        return CountRec(node.LeftChild) + CountRec(node.RightChild) + 1;
    }

    public void DepthFirstSearch()
    {
        DepthFirstSearchRec(_root);
    }

    private static void DepthFirstSearchRec(TreeNode<T>? node)
    {
        if (node != null)
        {
            BinarySearchTree<T>.DepthFirstSearchRec(node.LeftChild);

            Console.Write(node.Data + " ");

            BinarySearchTree<T>.DepthFirstSearchRec(node.RightChild);
        }
    }

    public void DepthFirstSearchNonRec()
    {
        Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();
        TreeNode<T>? current = _root;

        while (current != null || stack.Count > 0)
        {
            while (current != null)
            {
                stack.Push(current);
                current = current.LeftChild;
            }

            current = stack.Pop();

            Console.Write(current.Data + " ");

            current = current.RightChild;
        }
    }

    public void BreadthFirstSearch()
    {
        if (_root == null) 
        { 
            return; 
        }

        Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();
        queue.Enqueue(_root);

        while (queue.Count > 0)
        {
            TreeNode<T> node = queue.Dequeue();

            Console.Write(node.Data + " ");

            if (node.LeftChild != null)
            { 
                queue.Enqueue(node.LeftChild); 
            }

            if (node.RightChild != null) 
            { 
                queue.Enqueue(node.RightChild); 
            }
        }
    }
}
