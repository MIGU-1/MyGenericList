using System;
using System.Collections.Generic;
using System.Text;

namespace MyGenericList
{
    class Node<T>
    {
        public T Data { get; private set; }
        public Node<T> Next { get; set; }

        public Node(T data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            Data = data;
        }
    }
}
