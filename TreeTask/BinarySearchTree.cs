using System.Text;
using System.Xml.Linq;

namespace TreeTask;

public class BinarySearchTree<T>
{
    private TreeNode<T>? _root;

    private Comparer<T> _comparer;

    public BinarySearchTree()
    {
        _comparer = Comparer<T>.Default;
    }

    public BinarySearchTree(Comparer<T> comparer)
    {
        _comparer = comparer;
    }

    public int Count { get; private set; }

    public delegate void Function(T data);

    public void Insert(T data)
    {
        TreeNode<T>? node = _root;

        Count++;

        while (!Equals(node, null))
        {
            int comparison = _comparer.Compare(data, node.Data);

            if (comparison <= 0)
            {
                if (Equals(node.LeftChild, null))
                {
                    node.LeftChild = new TreeNode<T>(data);
                    return;
                }

                node = node.LeftChild;
            }
            else
            {
                if (Equals(node.RightChild, null))
                {
                    node.RightChild = new TreeNode<T>(data);
                    return;
                }

                node = node.RightChild;
            }
        }

        _root = new TreeNode<T>(data);
    }

    public bool Contains(T data)
    {
        TreeNode<T>? node = _root;

        while (!Equals(node, null))
        {
            int comparison = _comparer.Compare(data, node.Data);

            if (comparison == 0)
            {
                return true;
            }

            if (comparison < 0)
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
        TreeNode<T>? parentNode = _root;
        bool isLeftChild = true;

        while (!Equals(node, null))
        {
            int comparison = _comparer.Compare(data, node.Data);

            if (comparison == 0)
            {
                bool isRootRemove = _comparer.Compare(node.Data, _root!.Data) == 0;

                bool haveLeftChild = !Equals(node.LeftChild, null);
                bool haveRightChild = !Equals(node.RightChild, null);

                if (haveLeftChild && haveRightChild) // Удаление узла с двумя детьми
                {
                    TreeNode<T> leftmostNode = node.RightChild!;
                    TreeNode<T> parentLeftmostNode = node;

                    while (!Equals(leftmostNode.LeftChild, null))
                    {
                        parentLeftmostNode = leftmostNode;
                        leftmostNode = leftmostNode.LeftChild;
                    }

                    if (_comparer.Compare(parentLeftmostNode.Data, node.Data) == 0)
                    {
                        parentLeftmostNode.RightChild = leftmostNode.RightChild;
                    }
                    else
                    {
                        parentLeftmostNode.LeftChild = leftmostNode.RightChild;
                    }

                    leftmostNode.LeftChild = node.LeftChild;
                    leftmostNode.RightChild = node.RightChild;

                    SetNewNode(leftmostNode, parentNode!, isLeftChild, isRootRemove);
                }
                else if (haveLeftChild && !haveRightChild) // Удаление узла с одним ребенком слева
                {
                    SetNewNode(node.LeftChild, parentNode!, isLeftChild, isRootRemove);
                }
                else if (!haveLeftChild && haveRightChild) // Удаление узла с одним ребенком справа
                {
                    SetNewNode(node.RightChild, parentNode!, isLeftChild, isRootRemove);
                }
                else // Удаление листа
                {
                    SetNewNode(null, parentNode!, isLeftChild, isRootRemove);
                }

                Count--;

                return true;
            }

            parentNode = node;

            if (comparison < 0)
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

    private void SetNewNode(TreeNode<T>? newNode, TreeNode<T> parentNode, bool isLeftChild, bool isRootRemove) // rename
    {
        if (isRootRemove)
        {
            _root = newNode;
        }
        else
        {
            if (isLeftChild)
            {
                parentNode.LeftChild = newNode;
            }
            else
            {
                parentNode.RightChild = newNode;
            }
        }
    }

    public void DepthFirstSearch(Function action)
    {
        DepthFirstSearchRecursive(_root, action);
    }

    private static void DepthFirstSearchRecursive(TreeNode<T>? node, Function action)
    {
        if (node != null)
        {
            action(node.Data);

            DepthFirstSearchRecursive(node.LeftChild, action);
            DepthFirstSearchRecursive(node.RightChild, action);
        }
    }

    public void DepthFirstSearchNonRecursive(Function action)
    {
        if (_root == null)
        {
            return;
        }

        Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();
        stack.Push(_root);

        while (stack.Count > 0)
        {
            TreeNode<T> node = stack.Pop();

            action(node.Data);

            if (node.RightChild != null)
            {
                stack.Push(node.RightChild);
            }

            if (node.LeftChild != null)
            {
                stack.Push(node.LeftChild);
            }
        }
    }

    public void BreadthFirstSearch(Function action)
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

            action(node.Data);

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

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder("{");

        if (!Equals(_root, null))
        {
            Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();
            queue.Enqueue(_root);

            while (queue.Count > 0)
            {
                TreeNode<T> node = queue.Dequeue();

                stringBuilder.Append(node.Data).Append(", ");

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

        return stringBuilder.Remove(stringBuilder.Length - 2, 2).Append('}').ToString();
    }
}
