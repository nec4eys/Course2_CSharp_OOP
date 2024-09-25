using System.Text;

namespace TreeTask;

public class BinarySearchTree<T>
{
    private TreeNode<T>? _root;

    private readonly Comparer<T> _comparer;

    public BinarySearchTree()
    {
        _comparer = Comparer<T>.Default;
    }

    public BinarySearchTree(Comparer<T> comparer)
    {
        if (comparer is null)
        {
            _comparer = Comparer<T>.Default;
            return;
        }

        _comparer = comparer;
    }

    public int Count { get; private set; }

    public void Insert(T data)
    {
        if (_root is null)
        {
            _root = new TreeNode<T>(data);
            return;
        }

        TreeNode<T>? node = _root;

        Count++;

        while (node is not null)
        {
            int comparisonResult = _comparer.Compare(data, node.Data);

            if (comparisonResult < 0)
            {
                if (node.LeftChild is null)
                {
                    node.LeftChild = new TreeNode<T>(data);
                    return;
                }

                node = node.LeftChild;
            }
            else
            {
                if (node.RightChild is null)
                {
                    node.RightChild = new TreeNode<T>(data);
                    return;
                }

                node = node.RightChild;
            }
        }
    }

    public bool Contains(T data)
    {
        TreeNode<T>? node = _root;

        while (node is not null)
        {
            int comparisonResult = _comparer.Compare(data, node.Data);

            if (comparisonResult == 0)
            {
                return true;
            }

            if (comparisonResult < 0)
            {
                node = node.LeftChild;
            }
            else
            {
                node = node.RightChild;
            }
        }

        return false;
    }

    public bool Remove(T data)
    {
        TreeNode<T>? node = _root;
        TreeNode<T>? parentNode = null;
        bool isLeftChild = true;

        while (node is not null)
        {
            int comparisonResult = _comparer.Compare(data, node.Data);

            if (comparisonResult == 0)
            {
                bool isRootRemove = parentNode is null;

                bool hasLeftChild = node.LeftChild is not null;
                bool hasRightChild = node.RightChild is not null;

                if (hasLeftChild && hasRightChild) // Удаление узла с двумя детьми
                {
                    TreeNode<T> leftmostNode = node.RightChild!;
                    TreeNode<T> leftmostNodeParent = node;

                    while (leftmostNode.LeftChild is not null)
                    {
                        leftmostNodeParent = leftmostNode;
                        leftmostNode = leftmostNode.LeftChild;
                    }

                    if (!ReferenceEquals(leftmostNodeParent, node))
                    {
                        leftmostNodeParent.LeftChild = leftmostNode.RightChild;
                        leftmostNode.RightChild = node.RightChild;
                    }

                    leftmostNode.LeftChild = node.LeftChild;

                    SetNewNode(leftmostNode, parentNode!, isLeftChild, isRootRemove);
                }
                else
                {
                    SetNewNode(hasLeftChild ? node.LeftChild : node.RightChild, parentNode!, isLeftChild, isRootRemove);
                }

                Count--;

                return true;
            }

            parentNode = node;

            if (comparisonResult < 0)
            {
                isLeftChild = true;
                node = node.LeftChild;
            }
            else
            {
                isLeftChild = false;
                node = node.RightChild;
            }
        }

        return false;
    }

    private void SetNewNode(TreeNode<T>? newNode, TreeNode<T> parentNode, bool isLeftChild, bool isRootRemove)
    {
        if (isRootRemove)
        {
            _root = newNode;
            return;
        }

        if (isLeftChild)
        {
            parentNode.LeftChild = newNode;
        }
        else
        {
            parentNode.RightChild = newNode;
        }
    }

    public void DepthFirstSearchRecursive(Action<T> action)
    {
        DepthFirstSearchRecursive(_root, action);
    }

    private static void DepthFirstSearchRecursive(TreeNode<T>? node, Action<T> action)
    {
        if (node is not null)
        {
            action(node.Data);

            DepthFirstSearchRecursive(node.LeftChild, action);
            DepthFirstSearchRecursive(node.RightChild, action);
        }
    }

    public void DepthFirstSearch(Action<T> action)
    {
        if (_root is null)
        {
            return;
        }

        Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();
        stack.Push(_root);

        while (stack.Count > 0)
        {
            TreeNode<T> node = stack.Pop();

            action(node.Data);

            if (node.RightChild is not null)
            {
                stack.Push(node.RightChild);
            }

            if (node.LeftChild is not null)
            {
                stack.Push(node.LeftChild);
            }
        }
    }

    public void BreadthFirstSearch(Action<T> action)
    {
        if (_root is null)
        {
            return;
        }

        Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();
        queue.Enqueue(_root);

        while (queue.Count > 0)
        {
            TreeNode<T> node = queue.Dequeue();

            action(node.Data);

            if (node.LeftChild is not null)
            {
                queue.Enqueue(node.LeftChild);
            }

            if (node.RightChild is not null)
            {
                queue.Enqueue(node.RightChild);
            }
        }
    }

    public override string ToString()
    {
        if (_root is null)
        {
            return "{}";
        }

        StringBuilder stringBuilder = new StringBuilder("{");

        BreadthFirstSearch(data => stringBuilder.Append(data).Append(", "));

        return stringBuilder.Remove(stringBuilder.Length - 2, 2).Append('}').ToString();
    }
}
