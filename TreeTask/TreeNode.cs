namespace TreeTask;

public class TreeNode<T>
{
    public T Data { get; set; }

    public TreeNode<T>? LeftChild { get; set; }

    public TreeNode<T>? RightChild { get; set; }

    public TreeNode(T data)
    {
        Data = data;
    }
}
