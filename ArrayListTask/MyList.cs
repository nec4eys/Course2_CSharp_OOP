using System;
using System.Collections;
using System.Reflection;

namespace ArrayListTask;

public class MyList<T> : IList<T>
{
    private T[] _items;

    private int _count;

    public MyList(int capacity = 4)
    {
        if (capacity < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(capacity), $"Capacity must be a non-negative number. Specified {nameof(capacity)}: {capacity}");
        }

        _items = new T[capacity];
    }

    public int Capacity
    {
        get => _items.Length;

        private set
        {
            if (value < _count)
            {
                throw new ArgumentOutOfRangeException(nameof(value), $"New capacity must be greater than the current size. Specified capacity: {value}");
            }

            Array.Resize(ref _items, value);
        }
    }

    public int Count => _count;

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
        if (index < 0 || index >= _count)
        {
            throw new IndexOutOfRangeException($"Index is out of range [0, {_count - 1}]. Specified {nameof(index)}: {index}");
        }
    }

    public void Add(T item)
    {
        Insert(_count, item);
    }

    public void Clear()
    {
        Array.Clear(_items, 0, _count);
        _count = 0;
    }

    public bool Contains(T item)
    {
        for (int i = 0; i < _count; i++)
        {
            if (EqualityComparer<T>.Default.Equals(_items[i], item))
            {
                return true;
            }
        }

        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        if (array == null)
        {
            throw new ArgumentNullException(nameof(array));
        }

        if (arrayIndex < 0 || arrayIndex >= array.Length)
        {
            throw new IndexOutOfRangeException($"Index is out of range [0, {array.Length - 1}]. Specified {nameof(arrayIndex)}: {arrayIndex}");
        }

        Array.Copy(_items, 0, array, arrayIndex, _count);
    }

    public int IndexOf(T item)
    {
        for (int i = 0; i < _count; i++)
        {
            if (EqualityComparer<T>.Default.Equals(_items[i], item))
            {
                return i;
            }
        }

        return -1;
    }

    public void Insert(int index, T item)
    {
        if (index < 0 || index > _count)
        {
            throw new IndexOutOfRangeException($"Index is out of range [0, {_count}]. Specified {nameof(index)}: {index}");
        }

        if (_count == _items.Length)
        {
            Array.Resize(ref _items, _items.Length * 2);
        }

        if (index != _count)
        {
            Array.Copy(_items, index, _items, index + 1, _count - index);
        }

        _items[index] = item;
        _count++;
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

        _count--;

        if (index < _count)
        {
            Array.Copy(_items, index + 1, _items, index, _count - index);
        }

        _items[_count] = default;
    }

    public void TrimExcess()
    {
        if (_count < (int)(_items.Length * 0.9))
        {
            Capacity = _count;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < _count; i++)
        {
            yield return _items[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
