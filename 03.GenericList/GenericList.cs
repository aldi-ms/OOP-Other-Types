using System;
using System.Text;
using System.Linq;
using _04.VersionAttribute;

namespace _03.GenericList
{
    [_04.VersionAttribute.Version(0, 1)]
    public class GenericList<T>
        where T : IComparable<T>
    {
        private const int DEFAULT_CAPACITY = 16;
        private T[] array;
        private int count;

        public GenericList(int capacity)
        {
            this.array = new T[capacity];
            this.count = 0;
        }

        public GenericList()
            : this(DEFAULT_CAPACITY)
        { }

        public T this[int index]
        {
            get 
            {
                if (index > this.count)
                {
                    throw new ArgumentOutOfRangeException("index", "Index out of bounds!");
                }

                return this.array[index]; 
            }

            private set 
            {
                if (index > this.count)
                {
                    throw new ArgumentOutOfRangeException("index", "Index out of bounds!");
                }

                this.array[index] = value; 
            }
        }

        public int Count
        {
            get { return this.count; }
        }

        public void Add(params T[] elements)
        {
            // Resize the array to fit all new elements if needed
            while (this.count + elements.Length > this.array.Length)
            {
                DoubleArrayCapacity();
            }

            foreach (T element in elements)
            {
                this[this.count] = element;
                this.count++;
            }
        }

        public void Remove(int index)
        {
            this[index] = default(T);
            this.count--;

            for (int i = index; i < this.count; i++)
            {
                this[i] = this[i + 1];
            }
        }

        public T GetElement(int index)
        {
            return this[index];
        }

        public void Insert(int index, T element)
        {
            if (index > this.count)
            {
                throw new ArgumentOutOfRangeException("index", "Index out of bounds!");
            }

            T[] newArray = new T[this.array.Length + 1];
            this.array.Take(index).ToArray<T>().CopyTo(newArray, 0);
            newArray[index] = element;
            this.count++;
            this.array.Skip(index).ToArray<T>().CopyTo(newArray, index + 1);

            this.array = newArray;
        }

        public int Find(T element)
        {
            for (int i = 0; i < this.count; i++)
            {
                if (this[i].Equals(element))
                {
                    return i;
                }
            }
            return -1;
        }

        public T Min()
        {
            T minElement = this[0];

            for (int i = 1; i < this.count; i++)
            {
                if (minElement.CompareTo(this[i]) > 0)
                {
                    minElement = this[i];
                }
            }

            return minElement;
        }

        public T Max()
        {
            T maxElement = this[0];

            for (int i = 0; i < this.count; i++)
            {
                if (maxElement.CompareTo(this[i]) < 0)
                {
                    maxElement = this[i];
                }
            }

            return maxElement;
        }

        private void DoubleArrayCapacity()
        {
            T[] resultArray = new T[this.array.Length * 2];
            this.array.CopyTo(resultArray, 0);

            this.array = resultArray;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("( ");

            for (int i = 0; i < this.count; i++)
            {
                sb.AppendFormat("{0} ", this[i]);
            }
            sb.Append(")");

            return sb.ToString();
        }
    }
}
