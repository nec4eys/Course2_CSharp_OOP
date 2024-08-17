namespace ListTask;

public class ListItem<T>
{
    public T? Data { get; set; }

    public ListItem<T>? Next { get; set; }

    public ListItem(T data)
    {
        Data = data;
    }

    public ListItem(T data, ListItem<T> next)
    {
        Data = data;
        Next = next;
    }

    public override string? ToString()
    {
        if (Data == null)
        {
            return string.Empty;
        }

        return Data.ToString();
    }
}
