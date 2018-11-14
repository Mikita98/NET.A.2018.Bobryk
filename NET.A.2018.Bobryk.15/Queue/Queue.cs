using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{

    public class Queue<T> : IEnumerable<T>
    {
        private T[] array;

        private const int startCapasity = 4;
        private int head;
        private int tail;
        private int count;
        private int version;

        public int Version
        {
            get { return version; }
            private set { version = value; }
        }

        /// <summary>
        /// Count of elements
        /// </summary>
        public int Count { get { return count; } }

        /// <summary>
        /// Constructor without arguments
        /// </summary>
        public Queue()
        {
            array = new T[startCapasity];
        }

        /// <summary>
        ///Constructor with Enumerable collection
        /// </summary>
        /// <param name="queue"></param>
        public Queue(IEnumerable<T> queue)
        {
            if (queue == null)
            {
                throw new ArgumentNullException(nameof(queue) + "can't be null!");
            }

            array = new T[startCapasity];
            IEnumerator<T> iterator = queue.GetEnumerator();
            while (iterator.MoveNext())
            {
                EnQueue(iterator.Current);
            }
        }

        /// <summary>
        /// Constructor with capacity
        /// </summary>
        /// <param name="capacity"></param>
        public Queue(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentException(nameof(capacity) + "must be more then 0");
            }

            array = new T[capacity];
        }

        public void EnQueue(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data) + "can't be null!");
            }

            if (count >= array.Length)
            {
                T[] newSourceArray = new T[array.Length * 2];
                array.CopyTo(newSourceArray, 0);
                array = newSourceArray;
            }

            array[tail++] = data;
            version++;
            count++;
        }

        /// <summary>
        /// Delete element from queue
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            T resultValue = array[head];
            array[head] = default(T);
            version--;
            head++;
            count--;
            return resultValue;
        }

        public IEnumerator GetEnumerator()
        {
            return new Iterator(this);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new Iterator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        /// <summary>
        /// Get first element
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            return array[head];
        }

        /// <summary>
        /// Return count of members
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Contains(T data)
        {
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;

            for (int i = 0; i < Count; i++)
            {
                if (data == null)
                {
                    if (array[i] == null)
                    {
                        return true;
                    }
                }
                else if (array[i] != null && comparer.Equals(array[i], data))
                {
                    return true;
                }
            }

            return false;
        }

        private struct Iterator : IEnumerator<T>
        {
            int current { get; set; }

            int version { get; set; }

            Queue<T> queue { get; set; }

            public T Current
            {
                get
                {
                    if ((current == -1) || (current == queue.Count))
                    {
                        throw new InvalidOperationException("Queue should contaim elements!");
                    }

                    return queue.array[current];
                }
            }

            object IEnumerator.Current => Current;

            public bool MoveNext()
            {
                if (version != queue.version)
                {
                    throw new InvalidOperationException("Queue was modified");
                }

                return ++current < queue.Count;
            }

            public Iterator(Queue<T> quque)
            {
                this.queue = quque;
                current = -1;
                version = quque.version;
            }

            public void Reset()
            {
                current = -1;
            }

            public void Dispose(){} 
        }
    }
}
