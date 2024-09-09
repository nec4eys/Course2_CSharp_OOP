using System.Text;

namespace ListTask;

public class SinglyLinkedList<T>
{
    private ListItem<T>? _head;

    public int Count { get; private set; }

    public T this[int index]
    {
        get
        {
            CheckIndex(index);

            return GetItemByIndex(index).Data;
        }

        set
        {
            CheckIndex(index);

            GetItemByIndex(index).Data = value;
        }
    }

    private void CheckIndex(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new IndexOutOfRangeException($"Index is out of range [0, {Count - 1}]. Specified {nameof(index)}: {index}");
        }
    }

    private ListItem<T> GetItemByIndex(int index)
    {
        ListItem<T> item = _head!;

        for (int i = 1; i <= index; i++)
        {
            item = item.Next!;
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

    public T SetWithReturningOldData(int index, T data)
    {
        CheckIndex(index);

        ListItem<T> item = GetItemByIndex(index);

        T oldData = item.Data;
        item.Data = data;

        return oldData;
    }

    public void Add(T data)
    {
        Insert(Count, data);
    }

    public void Insert(int index, T data)
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

        ListItem<T> previousItem = GetItemByIndex(index - 1);
        previousItem.Next = new ListItem<T>(data, previousItem.Next);
        Count++;
    }

    public void InsertFirst(T data)
    {
        _head = new ListItem<T>(data, _head);
        Count++;
    }

    public T Remove(int index)
    {
        CheckIndex(index);

        if (index == 0)
        {
            return RemoveFirst();
        }

        ListItem<T> previousItem = GetItemByIndex(index - 1);
        ListItem<T> currentItem = previousItem.Next!;

        T removedData = currentItem.Data;
        previousItem.Next = currentItem.Next;

        Count--;

        return removedData;
    }

    public bool RemoveByData(T data)
    {
        for (ListItem<T>? currentItem = _head, previousItem = null; currentItem != null; previousItem = currentItem, currentItem = currentItem.Next)
        {
            if ((Equals(data, null) && Equals(currentItem.Data, null)) || (!Equals(data, null) && data.Equals(currentItem.Data)))
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

        T removedData = _head.Data;
        _head = _head.Next;

        Count--;

        return removedData;
    }

    public void Reverse()
    {
        ListItem<T>? previousItem = null;

        for (ListItem<T>? currentItem = _head, nextItem = null; currentItem != null; previousItem = currentItem, currentItem = nextItem)
        {
            nextItem = currentItem.Next;
            currentItem.Next = previousItem;
        }

        _head = previousItem;
    }

    public SinglyLinkedList<T> Copy()
    {
        if (_head == null)
        {
            return new SinglyLinkedList<T>();
        }

        SinglyLinkedList<T> singlyLinkedList = new SinglyLinkedList<T>();

        ListItem<T> nextItem = new ListItem<T>(_head.Data);
        ListItem<T> previousItem = nextItem;

        singlyLinkedList._head = nextItem;
       
        for (ListItem<T>? item = _head.Next; item != null; item = item.Next)
        {
            nextItem = new ListItem<T>(item.Data);
            previousItem.Next = nextItem;
            previousItem = nextItem;
        }

        return singlyLinkedList;
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder("[");

        for (ListItem<T>? item = _head; item != null; item = item.Next)
        {
            stringBuilder.Append(item.Data).Append(", ");
        }

        return stringBuilder.Remove(stringBuilder.Length - 2, 2).Append(']').ToString();
    }
}
