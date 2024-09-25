using System.Collections;
using System.Text;

namespace ArrayListTask;

public class CustomList<T> : IList<T>
{
    private T[] _items;

    private int _modCount;

    public CustomList(int capacity)
    {
        if (capacity < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(capacity), $"Capacity must be a non-negative number. Specified {nameof(capacity)}: {capacity}");
        }

        _items = new T[capacity];
    }

    public CustomList() : this(4) { }

    public int Capacity
    {
        get => _items.Length;

        set
        {
            if (value < Count)
            {
                throw new ArgumentOutOfRangeException(nameof(value), $"The new capacity should not be less than the count of items in list. Specified capacity: {value}, Current items count: {Count}");
            }

            Array.Resize(ref _items, value);
        }
    }

    public int Count { get; private set; }

    public bool IsReadOnly => false;

    public T this[int index]
    {
        get
        {
            CheckIndex(index);

            return _items[index];
        }

        set
        {
            CheckIndex(index);

            _items[index] = value;
        }
    }

    private void CheckIndex(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), $"Index is out of range [0, {Count - 1}]. Specified {nameof(index)}: {index}");
        }
    }

    public void Add(T item)
    {
        Insert(Count, item);
    }

    public void Clear()
    {
        if (Count == 0)
        {
            return;
        }

        Array.Clear(_items, 0, Count);
        Count = 0;
        _modCount++;
    }

    public bool Contains(T item)
    {
        return IndexOf(item) >= 0;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        if (array is null)
        {
            throw new ArgumentNullException(nameof(array));
        }

        if (arrayIndex < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(arrayIndex), $"Index must be greater than or equal to zero. Specified {nameof(arrayIndex)}: {arrayIndex}");
        }

        if (Count > array.Length - arrayIndex)
        {
            throw new ArgumentException("There is not enough space in the array to copy", nameof(array));
        }

        Array.Copy(_items, 0, array, arrayIndex, Count);
    }

    public int IndexOf(T item)
    {
        return Array.IndexOf(_items, item);
    }

    public void Insert(int index, T item)
    {
        if (index < 0 || index > Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), $"Index is out of range [0, {Count}]. Specified {nameof(index)}: {index}");
        }

        if (Count == _items.Length)
        {
            if (_items.Length == 0)
            {
                _items = new T[1];
            }
            else
            {
                Array.Resize(ref _items, _items.Length * 2);
            }
        }

        if (index != Count)
        {
            Array.Copy(_items, index, _items, index + 1, Count - index);
        }

        _items[index] = item;
        Count++;
        _modCount++;
    }

    public bool Remove(T item)
    {
        int index = IndexOf(item);

        if (index < 0)
        {
            return false;
        }

        RemoveAt(index);

        return true;
    }

    public void RemoveAt(int index)
    {
        CheckIndex(index);

        if (index < Count - 1)
        {
            Array.Copy(_items, index + 1, _items, index, Count - index - 1);
        }

        _items[Count - 1] = default!;

        Count--;
        _modCount++;
    }

    public void TrimExcess()
    {
        if (Count < (int)(_items.Length * 0.9))
        {
            Capacity = Count;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        int initialModCount = _modCount;

        for (int i = 0; i < Count; i++)
        {
            if (initialModCount != _modCount)
            {
                throw new InvalidOperationException("The List has been changed");
            }

            yield return _items[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public override string ToString()
    {
        if (Count == 0)
        {
            return "{}";
        }

        StringBuilder stringBuilder = new StringBuilder("{");

        for (int i = 0; i < Count; i++)
        {
            stringBuilder.Append(_items[i]).Append(", ");
        }

        return stringBuilder.Remove(stringBuilder.Length - 2, 2).Append('}').ToString();
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(obj, this))
        {
            return true;
        }

        if (obj is null || obj.GetType() != GetType())
        {
            return false;
        }

        CustomList<T> list = (CustomList<T>)obj;

        if (Count != list.Count)
        {
            return false;
        }

        for (int i = 0; i < Count; i++)
        {
            if (!Equals(_items[i], list._items[i]))
            {
                return false;
            }
        }

        return true;
    }

    public override int GetHashCode()
    {
        const int prime = 17;
        int hash = 1;

        for (int i = 0; i < Count; i++)
        {
            hash = prime * hash + (_items[i] is null ? 0 : _items[i]!.GetHashCode());
        }

        return hash;
    }
}
