using System;
using System.Collections;
using System.Linq;

namespace Utils.Helpers
{
    public class HeapElement<T,Y> 
    {
        public decimal Fscore { get; set; }
        public T Element { get; set; }
        public Y Path { get; set; }
    }

    public class MinHeap<T, Y> : IEnumerable
    {
        private readonly HeapElement<T, Y>[] _collection;
        private int _index;

        public MinHeap(long size)
        {
            _collection = new HeapElement<T, Y>[size];
        }

        public HeapElement<T, Y> GetParent(int i, out int index)
        {
            double element = i;
            index = (int)Math.Floor((element - 1) / 2);

            if (index < 0)
            {
                return _collection[0];
            }

            return _collection[index];
        }

        public HeapElement<T, Y> GetLeftChild(int i, out int index)
        {
            index = (2 * i) + 1;
            return _collection[index];
        }

        public HeapElement<T, Y> GetRightChild(int i, out int index)
        {
            index = (2 * i) + 2;
            return _collection[index];
        }

        public void Insert(HeapElement<T, Y> e)
        {
            _collection[_index] = e;

            HeapifyUp(_index);
            _index++;
        }

        public void Insert(T i, Y x, decimal fScore)
        {
            var e = new HeapElement<T, Y> { Element = i, Fscore = fScore, Path = x};
            _collection[_index] = e;

            HeapifyUp(_index);
            _index++;
        }

        private int _currentIndex;
        private void HeapifyUp(int element)
        {
            int parentIndex;
            HeapElement<T, Y> parent = GetParent(element, out parentIndex);
            if (parent != null)
            {
                if (_collection[element].Fscore < parent.Fscore)
                {
                    Swap(ref _collection[parentIndex], ref _collection[element]);
                }
                else
                {
                    return;
                }
            }

            // Swapped, current element is at parentIndex now, and _index is the parent of the element
            HeapifyUp(parentIndex);
        }

        public void Swap(ref HeapElement<T,Y> a, ref HeapElement<T,Y> b)
        {
            HeapElement<T,Y> temp = a;
            a = b;
            b = temp;
        }

        public int Count
        {
            get { return _index; }
        }

        public HeapElement<T,Y> Minimum
        {
            get { return _collection[0]; }
        }

        public HeapElement<T,Y> RemoveMinimum()
        {
            HeapElement<T,Y> minimum = _collection[0];
            _index--;
            _collection[0] = _collection[_index];
            _collection[_index] = null;

            Heapify();

            return minimum;
        }

        public bool Contains(HeapElement<T,Y> i)
        {
            return _collection.Contains(i);
        }

        public bool Contains(T i)
        {
            return _collection.Where(x => x != null && x.Element != null).Any(x => x.Element.Equals(i));
        }

        public void Heapify()
        {
            _currentIndex = 0;
            Heapify(_currentIndex);
        }

        public void Heapify(int index)
        {

            int leftChildIndex;
            int rightChildIndex;

            HeapElement<T,Y> leftChild = GetLeftChild(index, out leftChildIndex);
            HeapElement<T,Y> rightChild = GetRightChild(index, out rightChildIndex);

            if (leftChild == null || rightChild == null)
            {
                return;
            }

            int replacingElement = 0;

            if (leftChild.Fscore < rightChild.Fscore)
            {
                replacingElement = leftChildIndex;
            }
            if (leftChild.Fscore > rightChild.Fscore)
            {
                replacingElement = rightChildIndex;
            }

            if (leftChild.Fscore.Equals(rightChild.Fscore))
            {
                replacingElement = leftChildIndex;
            }

            Swap(ref _collection[index], ref _collection[replacingElement]);


            Heapify(replacingElement);
        }



        #region IEnumerable Members

        public IEnumerator GetEnumerator()
        {
            foreach (var i in _collection)
            {
                yield return i;
            }
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}
