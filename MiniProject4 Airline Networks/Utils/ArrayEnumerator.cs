using System.Collections;
using System.Collections.Generic;

namespace MiniProject4_Airline_Networks.Utils
{
    public class ArrayEnumerator<T> : IEnumerator<T>
    {
        private readonly T[] _items;
        private int _index;
        private readonly int _end;

        public ArrayEnumerator(T[] items, int end, int start = 0) {
            _items = items;
            _index = start;
            _end = end;
        }

        public bool HasNext() { return _index != _end; }

        public T Next() {
            var item = _items[_index++];
            _index %= _items.Length;
            return item;
        }

        // MoveNext together with Current does the same as java hasNext and Next
        public bool MoveNext()
        {
            throw new System.NotImplementedException();
        }

        public void Reset()
        {
            throw new System.NotImplementedException();
        }

        public T Current { get; }

        object? IEnumerator.Current => Current;

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}