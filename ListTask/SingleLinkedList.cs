using System.Text;

namespace ListTask;

public class SingleLinkedList<T>
{
    private ListItem<T>? _head;

    private int count;

    public int Count => count;

    private ListItem<T>? GetItemByIndex(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new IndexOutOfRangeException(nameof(index));
        }

        ListItem<T>? item = _head;

        for (int i = 1; i <= index; i++)
        {
            item = item.Next;
        }

        return item;
    }

    public T? GetHeadData()
    {
        if (_head == null)
        {
            throw new IndexOutOfRangeException("The List is empty!"); // Та ошибка вообще?
        }

        return _head.Data;
    }

    public T? Get(int index)
    {
        return GetItemByIndex(index).Data;
    }

    public T? Set(int index, T data)
    {
        if (data == null)
        {
            throw new ArgumentNullException(nameof(data));
        }

        ListItem<T>? item = GetItemByIndex(index);

        T? oldData = item.Data;
        item.Data = data;

        return oldData;
    }

    public void Add(T? data)
    {
        if (data == null)
        {
            throw new ArgumentNullException(nameof(data));
        }

        ListItem<T> newItem = new ListItem<T>(data);

        if (_head == null)
        {
            _head = newItem;
            count++;
            return;
        }

        GetItemByIndex(count - 1).Next = newItem;
        count++;
    }

    public void Insert(ListItem<T> item, int index)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }


        if (index < 0 || index >= Count)
        {
            throw new IndexOutOfRangeException(nameof(index));
        }

        if (index == 0)
        {
            InsertFirst(item);
            return;
        }

        ListItem<T>? previousItem = GetItemByIndex(index - 1);
        item.Next = previousItem.Next;
        previousItem.Next = item;
        count++;
    }

    public void InsertFirst(ListItem<T> item)
    {
        item.Next = _head;
        _head = item;
        count++;
    }

    public T? Remove(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new IndexOutOfRangeException(nameof(index));
        }

        T? temp;

        if (index == 0)
        {
            temp = _head.Data;
            _head = _head.Next;
            count--;
            return temp;
        }

        ListItem<T>? previousItem = GetItemByIndex(index - 1);
        ListItem<T>? currentItem = previousItem.Next;

        temp = currentItem.Data;
        previousItem.Next = currentItem.Next;

        count--;

        return temp;
    }

    public bool RemoveByValue(T value)
    {
        if (value == null)
        {
            throw new ArgumentNullException(nameof(value));
        }

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

                count--;

                return true;
            }
        }

        return false;
    }

    public T? RemoveFirst()
    {
        if (_head == null)
        {
            throw new NullReferenceException("The array is empty!");
        }

        T? temp = _head.Data;
        _head = _head.Next;

        count--;

        return temp;
    }

    public void Reverse()
    {
        ListItem<T>? tempItem;

        for (ListItem<T>? currentItem = _head, previousItem = null; currentItem != null; previousItem = currentItem, currentItem = tempItem)
        {
            if (currentItem.Next == null)
            {
                _head = currentItem;
            }
            tempItem = currentItem.Next;
            currentItem.Next = previousItem;
        }
    }

    public SingleLinkedList<T> Copy()
    {
        SingleLinkedList<T> singleLinkedList = new SingleLinkedList<T>();

        for (int i = 0; i < count; i++)
        {
            singleLinkedList.Add(Get(i));
        }

        return singleLinkedList;
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();

        for (ListItem<T>? i = _head; i != null; i = i.Next)
        {
            stringBuilder.Append(i.ToString()).Append("; ");
        }

        return stringBuilder.ToString();
    }
}
