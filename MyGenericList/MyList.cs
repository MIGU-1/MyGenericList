using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MyGenericList
{
    class MyList<T> : IList<T>
    {
        private Node<T> _head;

        public int Count
        {
            get
            {
                Node<T> run = _head;
                int count = 0;

                while (run != null)
                {
                    count++;
                    run = run.Next;
                }

                return count;
            }
        }
        public bool IsReadOnly { get => false; }
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    throw new ArgumentOutOfRangeException(nameof(index));

                Node<T> run = _head;

                for (int i = 0; i < index && run != null; i++)
                {
                    run = run.Next;
                }

                return run.Data;
            }

            set
            {
                Insert(index, value);

                if (index == 0)
                {
                    RemoveAt(1);
                }
                else
                {
                    RemoveAt(index + 1);
                }
            }
        }


        public void Add(T item)
        {
            throw new NotImplementedException();
        }
        public void Clear()
        {
            throw new NotImplementedException();
        }
        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }
        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }
        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }
        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }
        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
