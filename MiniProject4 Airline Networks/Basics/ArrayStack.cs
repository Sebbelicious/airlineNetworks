#nullable enable
using System.Collections;
using System.Collections.Generic;

namespace MiniProject4_Airline_Networks.Basics
{
    public class ArrayStack<T> : IStack<T>
    {
        private readonly T[] _items;
        private int _top = 0;

        public ArrayStack(int capacity) {
            _items = new T[capacity];
        }

        public void Push(T item) {
            _items[_top++] = item;
        }

        public T Pop() {
            return _items[--_top];
        }

        public T Peek() {
            return _items[_top - 1];
        }

        public int GetSize() {
            return _top;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return null;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}