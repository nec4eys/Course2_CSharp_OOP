using System.Text;

namespace ListTask;

public class SinglyLinkedList<T>
{
    private ListItem<T>? _head;

    public int Count { get; private set; }

    public T this[int index]
    {
        get { return GetItemByIndex(index).Data; }
        set { GetItemByIndex(index).Data = value; }
    }

    private ListItem<T> GetItemByIndex(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new IndexOutOfRangeException($"Index is out of range [0, {Count - 1}]. Specified {nameof(index)}: {index}");
        }

        ListItem<T>? item = _head;

        for (int i = 1; i <= index; i++)
        {
            item = item.Next;
        }

        return item;
    }

    public T GetFirstData()
    {
        if (_head == null)
        {
            throw new InvalidOperationException("The List is empty!");
        }

        return _head.Data;
    }

    public T SetWithReturningPreviousData(int index, T data)
    {
        ListItem<T>? item = GetItemByIndex(index);

        T previousData = item.Data;
        item.Data = data;

        return previousData;
    }

    public void Add(T data)
    {
        Insert(data, Count);
    }

    public void Insert(T data, int index)
    {
        if (index < 0 || index > Count)
        {
            throw new IndexOutOfRangeException($"Index is out of range [0, {Count}]. Specified {nameof(index)}: {index}");
        }

        if (index == 0)
        {
            InsertFirst(data);
            return;
        }

        ListItem<T>? previousItem = GetItemByIndex(index - 1);
        ListItem<T> newItem = new ListItem<T>(data, previousItem);
        previousItem.Next = newItem;
        Count++;
    }

    public void InsertFirst(T data)
    {
        ListItem<T> newItem = new ListItem<T>(data, _head);
        _head = newItem;
        Count++;
    }

    public T Remove(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new IndexOutOfRangeException($"Index is out of range [0, {Count - 1}]. Specified {nameof(index)}: {index}");
        }

        if (index == 0)
        {
            return RemoveFirst();
        }

        ListItem<T>? previousItem = GetItemByIndex(index - 1);
        ListItem<T>? currentItem = previousItem.Next;

        T deletedData = currentItem.Data;
        previousItem.Next = currentItem.Next;

        Count--;

        return deletedData;
    }

    public bool RemoveByValue(T value)
    {
        for (ListItem<T>? currentItem = _head, previousItem = null; currentItem != null; previousItem = currentItem, currentItem = currentItem.Next)
        {
            if (value.Equals(currentItem.Data))
            {
                if (previousItem == null)
                {
                    _head = currentItem.Next;
                }
                else
                {
                    previousItem.Next = currentItem.Next;
                }

                Count--;

                return true;
            }
        }

        return false;
    }

    public T RemoveFirst()
    {
        if (_head == null)
        {
            throw new InvalidOperationException("The List is empty!");
        }

        T deletedData = _head.Data;
        _head = _head.Next;

        Count--;

        return deletedData;
    }

    public void Reverse()
    {
        ListItem<T>? nextItem = null, previousItem = null;

        for (ListItem<T>? currentItem = _head; currentItem != null; previousItem = currentItem, currentItem = nextItem)
        {
            nextItem = currentItem.Next;
            currentItem.Next = previousItem;
        }

        _head = previousItem;
    }

    public SinglyLinkedList<T> Copy()
    {
        SinglyLinkedList<T> singlyLinkedList = new SinglyLinkedList<T>();

        for (ListItem<T>? item = _head; item != null; item = item.Next)
        {
            singlyLinkedList.Add(item.Data);
        }

        return singlyLinkedList;
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.Append('[');

        for (ListItem<T>? item = _head; item != null; item = item.Next)
        {
            stringBuilder.Append(item).Append(", ");
        }

        return stringBuilder.Append(']').ToString();
    }
}
