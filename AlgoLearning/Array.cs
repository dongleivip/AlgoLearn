using System;

namespace AlgoLearning
{
    public class Array<T> where T : IComparable<T>
    {
        private T[] _data;
        private readonly int _capacity;
        private int _length;

        public Array(int capacity)
        {
            _data = new T[capacity];
            _capacity = capacity;
            _length = 0;
        }

        // length of list
        public int Length => _length;

        public void Insert(int index, T newElem)
        {
            if (_length == _capacity)
            {
                throw new OutOfMemoryException("List has no more space");
            }

            if (index < 0 || index > _length + 1)
            {
                throw new IndexOutOfRangeException("Index was outside the bounds.");
            }

            // to loop arry from end untill finding the target index
            for (int k = _length; k > index; k--)
            {
                _data[k] = _data[k - 1];
            }

            _data[index] = newElem;

            _length++;
        }

        // get an element base on index
        public T Find(int index)
        {
            if (index < 0 || index > _length - 1)
            {
                throw new IndexOutOfRangeException("Index was outside the boulds of the list");
            }

            return _data[index];
        }

        public int IndexOf(T val)
        {
            if (_length == 0)
            {
                return -1;
            }

            if (_data[0].Equals(val))
            {
                return 0;
            }

            if (_data[_length - 1].CompareTo(val) == 0)
            {
                return _length - 1;
            }

            int start = 1;
            while (start < _length - 1)
            {
                if (_data[start].CompareTo(val) == 0)
                {
                    return start;
                }
                start++;
            }

            return -1;
        }

        // delete an element which is on the specified index
        public bool Delete(int index)
        {
            if (index < 0 || index > _length - 1)
            {
                throw new IndexOutOfRangeException("Index outside the bounds of the list");
            }

            T deletedElm = _data[index];

            if (index < _length - 1)
            {
                for (int k = index; k < _length; k++)
                {
                    _data[k] = _data[k + 1];
                }
            }

            _length--;

            return true;
        }

        public bool Delete(T val)
        {
            int index;
            for (index = 0; index < _length; index++)
            {
                if (_data[index].CompareTo(val) == 0)
                {
                    break;
                }

                if (index >= _length)
                {
                    return false;
                }
            }

            return Delete(index);
        }

        public void Clear()
        {
            _data = new T[_capacity];
            _length = 0;
        }
    }
}