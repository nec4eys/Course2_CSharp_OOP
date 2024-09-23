using System.Collections;
using System.Text;

namespace HashTableTask;

public class HashTable<T> : ICollection<T>
{
    private readonly List<T>[] _lists;

    private int _modCount;

    public bool IsReadOnly => false;

    public int Count { get; private set; }

    public HashTable(int capacity)
    {
        if (capacity <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(capacity), $"Capacity must be > 0. Specified {nameof(capacity)}: {capacity}");
        }

        _lists = new List<T>[capacity];
    }

    public HashTable() : this(10) { }

    private int GetListIndex(T item)
    {
        if (item is null)
        {
            return 0;
        }

        return Math.Abs(item.GetHashCode() % _lists.Length);
    }

    public void Add(T item)
    {
        int index = GetListIndex(item);

        if (_lists[index] is null)
        {
            _lists[index] = new List<T>();
        }

        _lists[index].Add(item);

        Count++;
        _modCount++;
    }

    public void Clear()
    {
        if (Count == 0)
        {
            return;
        }

        foreach (List<T> list in _lists)
        {
            list?.Clear();
        }

        Count = 0;
        _modCount++;
    }

    public bool Contains(T item)
    {
        int index = GetListIndex(item);

        return _lists[index] is null ? false : _lists[index].Contains(item);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        if (array is null)
        {
            throw new ArgumentNullException(nameof(array));
        }

        if (arrayIndex < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(arrayIndex), $"Index must be greater than zero. Specified {nameof(arrayIndex)}: {arrayIndex}");
        }

        if (Count > array.Length - arrayIndex)
        {
            throw new ArgumentException("There is not enough space in the array to copy", nameof(array));
        }

        int i = arrayIndex;

        foreach (List<T> list in _lists)
        {
            if (list is not null)
            {
                list.CopyTo(array, i);
                i += list.Count;
            }
        }
    }

    public bool Remove(T item)
    {
        int index = GetListIndex(item);

        if (_lists[index] is not null && _lists[index].Remove(item))
        {
            Count--;
            _modCount++;
            return true;
        }

        return false;
    }

    public IEnumerator<T> GetEnumerator()
    {
        int initialModCount = _modCount;

        foreach (List<T> list in _lists)
        {
            if (list is null)
            {
                continue;
            }

            foreach (T item in list)
            {
                if (initialModCount != _modCount)
                {
                    throw new InvalidOperationException("The HashTable has been changed");
                }

                yield return item;
            }
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

        foreach (T item in this)
        {
            stringBuilder.Append(item is null ? "null" : item).Append(", ");
        }

        return stringBuilder.Remove(stringBuilder.Length - 2, 2).Append('}').ToString();
    }
}
