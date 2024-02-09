using System.Collections;

namespace Hilel_Event_Generic;

public class UltraCollection<T> : IEnumerable<T>
{
    private int _capacity;
    
    private int _size;
    
    private T[] _data;

    public event Action<int> OnExpandedEvent;
    
    public UltraCollection()
    {
        _capacity = 4;
        _data = new T[_capacity];
    }
    
    public UltraCollection(int capacity)
    {
        _capacity = capacity;
        _data = new T[_capacity];
    }

    public UltraCollection(IEnumerable<T> seed)
    {
        _data = seed.ToArray();
        _capacity = _data.Length;
        _size = _data.Length;
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= _size)
            {
                throw new IndexOutOfRangeException($"Index {{index}} is out of range.");
            }

            return _data[index];
        }
        set
        {
            if (index < 0 || index >= _size)
            {
                throw new IndexOutOfRangeException($"Index {index} is out of range.");
            }

            _data[index] = value;
        }
    }

    public void Add(T element)
    {
        if (_size == _capacity)
        {
            Resize(_capacity * 2);
        }

        _data[_size] = element; 
        _size++;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (var i = 0; i < _size; i++)
        {
            yield return _data[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    
    private void Resize(int capacity)
    {
        _capacity = capacity;
        Array.Resize(ref _data, _capacity);
        
        OnExpandedEvent?.Invoke(_capacity);
    }
}