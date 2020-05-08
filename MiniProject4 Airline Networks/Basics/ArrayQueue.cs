using System.Collections;
using System.Collections.Generic;
using MiniProject4_Airline_Networks.Utils;

namespace MiniProject4_Airline_Networks.Basics
{
    public class ArrayQueue<T> : IQueue<T>
    {
        private readonly T[] _items;
        private int _start = 0;
        private int _end = 0;

        public ArrayQueue(int capacity) {
            _items = new T[capacity];
        }

        
        public int GetSize() { return _end - _start; }

        public void Enqueue(T item) {
            _items[_end++] = item;
            _end = _end%_items.Length;
        }

        public T Dequeue() {
            T item = _items[_start++];
            _start = _start%_items.Length;
            return item;
        }

        public T Peek() { return _items[_start]; }

        public IEnumerator<T> GetEnumerator() {
            return new ArrayEnumerator<T>(_items, _start, _end);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}