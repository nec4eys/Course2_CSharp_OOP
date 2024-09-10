using System.Collections;
using System.Text;

namespace HashTableTask;

public class HashTable<T> : ICollection<T>
{
    private readonly List<T>[] _lists;

    private int modCount;

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

    private int GetItemIndex(T item)
    {
        if (Equals(item, null))
        {
            return 0;
        }

        return Math.Abs(item.GetHashCode() % _lists.Length);
    }

    public void Add(T item)
    {
        int index = GetItemIndex(item);

        if (Equals(_lists[index], null))
        {
            _lists[index] = new List<T>();
        }

        _lists[index].Add(item);

        Count++;
        modCount++;
    }

    public void Clear()
    {
        for (int i = 0; i < _lists.Length; i++)
        {
            _lists[i].Clear();
        }

        Count = 0;
        modCount++;
    }

    public bool Contains(T item)
    {
        int index = GetItemIndex(item);

        return _lists[index].Contains(item);
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

        int index = arrayIndex;

        foreach (List<T> list in _lists)
        {
            list.CopyTo(array, index);
            index += list.Count;
        }
    }

    public bool Remove(T item)
    {
        int index = GetItemIndex(item);

        Count--;
        modCount++;

        return _lists[index].Remove(item);
    }

    public IEnumerator<T> GetEnumerator()
    {
        int fixedModCount = modCount;

        foreach (List<T> list in _lists)
        {
            foreach (T item in list)
            {
                if (fixedModCount != modCount)
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
        StringBuilder stringBuilder = new StringBuilder("{");

        for (int i = 0; i < _lists.Length; i++)
        {
            if (!Equals(_lists[i], null))
            {
                _lists[i].ForEach(item => stringBuilder.Append(Equals(item, null) ? "null" : item).Append(", "));
            }
        }

        return stringBuilder.Remove(stringBuilder.Length - 2, 2).Append('}').ToString();
    }
}
