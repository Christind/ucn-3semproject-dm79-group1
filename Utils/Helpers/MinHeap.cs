﻿using System;
using System.Collections;
using System.Linq;

namespace Utils.Helpers
{
    public struct HeapElement<T>
    {
        public double Fscore { get; set; }
        public T Element { get; set; }
    }

    public class MinHeap<T> : IEnumerable
    {
        private readonly HeapElement<T>[] _collection;
        private int _index;

        public MinHeap(long size)
        {
            _collection = new HeapElement<T>[size];
        }

        public HeapElement<T>? GetParent(int i, out int index)
        {
            double element = i;
            index = (int)Math.Floor((element - 1) / 2);

            if (index < 0)
            {
                return null;
            }

            return _collection[index];
        }

        public HeapElement<T>? GetLeftChild(int i, out int index)
        {
            index = (2 * i) + 1;
            return _collection[index];
        }

        public HeapElement<T>? GetRightChild(int i, out int index)
        {
            index = (2 * i) + 2;
            return _collection[index];
        }

        public void Insert(HeapElement<T> e)
        {
            _collection[_index] = e;

            HeapifyUp(_index);
            _index++;
        }

        public void Insert(T i, double fScore)
        {
            var e = new HeapElement<T> {Element = i, Fscore = fScore};
            _collection[_index] = e;

            HeapifyUp(_index);
            _index++;
        }

        private int _currentIndex;
        private void HeapifyUp(int element)
        {
            int parentIndex;
            HeapElement<T>? parent = GetParent(element, out parentIndex);
            if (parent != null)
            {
                if (_collection[element].Fscore < parent.Value.Fscore)
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

        public void Swap(ref HeapElement<T> a, ref HeapElement<T> b)
        {
            HeapElement<T> temp = a;
            a = b;
            b = temp;
        }

        public int Count
        {
            get { return _index - 1; }
        }

        public HeapElement<T> Minimum
        {
            get { return _collection[0]; }
        }

        public HeapElement<T> RemoveMinimum()
        {
            HeapElement<T> minimum = _collection[0];
            _collection[0] = _collection[--_index];
            //_collection[_index] = ;

            Heapify();

            return minimum;
        }

        public bool Contains(HeapElement<T> i)
        {
            return _collection.Contains(i);
        }

        public bool Contains(T i)
        {
            return _collection.Any(x => x.Element.Equals(i));
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

            HeapElement<T>? leftChild = GetLeftChild(index, out leftChildIndex);
            HeapElement<T>? rightChild = GetRightChild(index, out rightChildIndex);

            if (leftChild == null || rightChild == null)
            {
                return;
            }

            int replacingElement = 0;

            if (leftChild.Value.Fscore < rightChild.Value.Fscore)
            {
                replacingElement = leftChildIndex;
            }
            if (leftChild.Value.Fscore > rightChild.Value.Fscore)
            {
                replacingElement = rightChildIndex;
            }

            if (leftChild.Value.Fscore.Equals(rightChild.Value.Fscore))
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