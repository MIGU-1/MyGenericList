using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MyGenericList
{
    public class MyList<T> : IList<T>
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


        public void Add(T obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            Insert(Count, obj);
        }
        public void Clear()
        {
            _head = null;
        }
        public bool Contains(T obj)
        {
            return (IndexOf(obj) > -1);
        }
        public void CopyTo(T[] array, int index)
        {
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            Node<T> run = _head;

            if (_head != null)
            {
                int idxCounter = 0;

                if (index > 0)
                {
                    for (int i = 0; i < index && run != null; i++)
                    {
                        idxCounter++;
                        run = run.Next;
                    }
                }

                if (Count - idxCounter <= array.Length)
                {
                    for (int i = 0; run != null; i++)
                    {
                        array.SetValue(run.Data, i);
                        run = run.Next;
                    }
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(_head));
            }
        }
        public int IndexOf(T obj)
        {
            if (obj == null)
                throw new NotImplementedException(nameof(obj));

            Node<T> run = _head;
            int idx = 0;

            while (run != null && !run.Data.Equals(obj))
            {
                idx++;
                run = run.Next;
            }

            return run != null ? idx : -1;
        }
        public void Insert(int index, T obj)
        {
            if (index >= 0 && index <= Count)
            {
                Node<T> newNode = new Node<T>(obj);

                if (index == 0 && _head == null)
                {
                    _head = newNode;
                }
                else if (index == 0 && _head != null)
                {
                    newNode.Next = _head;
                    _head = newNode;
                }
                else
                {
                    Node<T> run = _head;

                    for (int i = index - 1; i > 0; i--)
                    {
                        run = run.Next;
                    }

                    newNode.Next = run.Next;
                    run.Next = newNode;
                }
            }

        }
        public bool Remove(T obj)
        {
            bool removed = false;

            if (Contains(obj))
            {
                RemoveAt(IndexOf(obj));
                removed = true;
            }

            return removed;
        }
        public void RemoveAt(int index)
        {
            if (index == 0 && _head != null)
            {
                _head = _head.Next;
            }
            else if (index > 0 && index < Count)
            {
                Node<T> run = _head;

                for (int i = index - 1; i > 0; i--)
                {
                    run = run.Next;
                }

                if (run.Next != null)
                {
                    run.Next = run.Next.Next;
                }
                else
                {
                    run.Next = null;
                }
            }
        }
        public static void Sort(MyList<T> myList)
        {
            Sort(myList, null);
        }
        public static void Sort(MyList<T> myList, IComparer comparer)
        {
            if (myList._head != null)
            {
                int result;

                for (int i = 0; i < myList.Count; i++)
                {
                    for (int j = 0; j < myList.Count - 1; j++)
                    {
                        IComparable object1 = myList[j] as IComparable;
                        IComparable object2 = myList[j + 1] as IComparable;

                        if (object1 == null)
                            throw new ArgumentNullException(nameof(object1));
                        if (object2 == null)
                            throw new ArgumentNullException(nameof(object2));

                        if (comparer != null)
                        {
                            result = comparer.Compare(object1, object2);
                        }
                        else
                        {
                            result = object1.CompareTo(object2);
                        }

                        if (result == 1)
                        {
                            T tmp = myList[j];
                            myList[j] = myList[j + 1];
                            myList[j + 1] = tmp;
                        }
                    }
                }
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new ListEnumerator<T>(_head);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new ListEnumerator<T>(_head);
        }
    }
}
