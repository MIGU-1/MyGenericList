using System;
using System.Collections;
using System.Collections.Generic;

namespace MyGenericList
{
    internal class ListEnumerator<T> : IEnumerator<T>
    {
        private Node<T> _head;
        private int _pos;

        public ListEnumerator(Node<T> head)
        {
            _head = head;
            _pos = -1;
        }

        public T Current => (_pos == -1) ? throw new NullReferenceException(nameof(_head)) : _head.Data;
        object IEnumerator.Current => (_pos == -1) ? throw new NullReferenceException(nameof(_head)) : _head.Data;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (_pos == -1 && _head != null)
            {
                _pos = 0;
            }
            else
            {
                if (_head != null && _head.Next != null)
                {
                    _pos++;
                    _head = _head.Next;
                }
                else
                {
                    _pos = -1;
                }
            }

            return _pos != -1;
        }

        public void Reset()
        {
            _pos = -1;
        }
    }
}