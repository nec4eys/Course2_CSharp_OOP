﻿using System.Collections;
using System.Text;

namespace ArrayListTask;

public class CustomList<T> : IList<T>
{
    private T[] _items;

    private int modCount;

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

        private set
        {
            if (value < Count)
            {
                throw new ArgumentOutOfRangeException(nameof(value), $"The new capacity should not be less than the count of items. Specified capacity: {value}, Current capacity: {_items.Length}");
            }

            Array.Resize(ref _items, value);

            modCount++;
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
    }

    public bool Contains(T item)
    {
        return IndexOf(item) >= 0;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        if (Equals(array, null))
        {
            throw new ArgumentNullException(nameof(array));
        }

        if (arrayIndex < 0 || arrayIndex >= array.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(arrayIndex), $"Index is out of range [0, {array.Length - 1}]. Specified {nameof(arrayIndex)}: {arrayIndex}");
        }

        if (array.Rank != 1)
        {
            throw new ArgumentException("The array is not one-dimensional", nameof(array));
        }

        if (Count > array.Length - arrayIndex)
        {
            throw new ArgumentException("There is not enough space in the array to copy", nameof(array));
        }

        Array.Copy(_items, 0, array, arrayIndex, Count);
    }

    public int IndexOf(T item)
    {
        for (int i = 0; i < Count; i++)
        {
            if (Equals(_items[i], item))
            {
                return i;
            }
        }

        return -1;
    }

    public void Insert(int index, T item)
    {
        if (index < 0 || index > Count)
        {
            throw new IndexOutOfRangeException($"Index is out of range [0, {Count}]. Specified {nameof(index)}: {index}");
        }

        if (_items.Length == 0)
        {
            _items = new T[1];
        }

        if (Count == _items.Length)
        {
            Array.Resize(ref _items, _items.Length * 2);
        }

        if (index != Count)
        {
            Array.Copy(_items, index, _items, index + 1, Count - index);
        }

        _items[index] = item;
        Count++;
        modCount++;
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

        if (index < Count)
        {
            Array.Copy(_items, index + 1, _items, index, Count - index);
        }

        _items[Count] = default!;

        Count--;
        modCount++;
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
        int fixedModCount = modCount;

        for (int i = 0; i < Count; i++)
        {
            if (fixedModCount != modCount)
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
        StringBuilder stringBuilder = new StringBuilder("{");

        foreach (T item in _items)
        {
            stringBuilder.Append(item).Append(", ");
        }

        return stringBuilder.Remove(stringBuilder.Length - 2, 2).Append('}').ToString();
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(obj, this))
        {
            return true;
        }

        if (ReferenceEquals(obj, null) || obj.GetType() != GetType())
        {
            return false;
        }

        CustomList<T> list = (CustomList<T>)obj;

        if (Count != list.Count)
        {
            return false;
        }

        // Стоит ли делать так же проверку вместимостей?

        for (int i = 0; i < Count; i++)
        {
            if (Equals(_items[i], null))
            {
                if (!Equals(list._items[i], null))
                {
                    return false;
                }
            }
            else
            {
                if (Equals(list._items[i], null) || !_items[i]!.Equals(list._items[i]))
                {
                    return false;
                }
            }
        }

        return true;
    }

    public override int GetHashCode()
    {
        const int prime = 17;
        int hash = 1;

        foreach (T item in _items)
        {
            hash = prime * hash + (Equals(item, null) ? 0 : item.GetHashCode());
        }

        return hash;
    }
}
