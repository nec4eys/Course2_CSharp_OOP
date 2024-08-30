using System.Collections;

namespace HashTableTask;

public class HashTable<T> : ICollection<T>
{
    private int _size;

    private List<T>[] _table;

    public bool IsReadOnly => false;

    public int Count
    {
        get
        {
            int count = 0;

            foreach (var list in _table)
            {
                count += list.Count;
            }

            return count;
        }
    }

    public HashTable(int size)
    {
        _size = size;
        _table = new List<T>[size];

        for (int i = 0; i < size; i++)
        {
            _table[i] = new List<T>();
        }
    }

    private int GetHashCode(T item)
    {
        return Math.Abs(item.GetHashCode() % _size);
    }

    public void Add(T item)
    {
        int index = GetHashCode(item);
        _table[index].Add(item);
    }

    public void Clear()
    {
        for (int i = 0; i < _size; i++)
        {
            _table[i].Clear();
        }
    }

    public bool Contains(T item)
    {
        int index = GetHashCode(item);

        return _table[index].Contains(item);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        foreach (var list in _table)
        {
            list.CopyTo(array, arrayIndex);
            arrayIndex += list.Count;
        }
    }

    public bool Remove(T item)
    {
        int index = GetHashCode(item);

        return _table[index].Remove(item);
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (var list in _table)
        {
            foreach (var item in list)
            {
                yield return item;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
