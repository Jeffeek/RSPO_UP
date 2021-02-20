using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace RSPO_UP_18
{
    public delegate void CSetElementAdded<T>(Cset<T> set, T item) where T : IEquatable<T>;

    public sealed class Cset<T> : ICollection<T>, IEquatable<Cset<T>> where T : IEquatable<T>
    {
        private int _capacity;
        private T[] _innerArray;

        public event CSetElementAdded<T> ItemAdded;

        public Cset() : this(4) { }

        public Cset(int capacity)
        {
            if (capacity <= 0) throw new ArgumentOutOfRangeException(nameof(capacity));

            _capacity = capacity;
            _innerArray = new T[capacity];
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = 0; i < Count; i++) yield return _innerArray[i];
        }

        ~Cset()
        {
            Clear();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public Cset(IEnumerable<T> source)
        {
            var tempArray = source.ToArray();
            var count = tempArray.Length;
            _capacity = count;
            Count = count;
            _innerArray = new T[count];
            for (var i = 0; i < count; i++) 
                _innerArray[i] = tempArray[i];
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count) throw new ArgumentOutOfRangeException(nameof(index));

                return _innerArray[index];
            }
        }

        public void Add(T item)
        {
            if (Contains(item)) return;

            if (Count + 1 > _capacity)
            {
                _capacity *= 2;
                var tempArray = new T[_capacity];
                Array.Copy(_innerArray, tempArray, Count);
                _innerArray = tempArray;
            }

            _innerArray[Count] = item;
            Count++;
            ItemAdded?.Invoke(this, item);
        }

        public void Clear()
        {
            _capacity = 4;
            _innerArray = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            for (var i = 0; i < Count; i++)
                if (_innerArray[i].Equals(item))
                    return true;

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex) => throw new NotImplementedException();

        public bool Remove(T item)
        {
            if (!Contains(item)) return false;

            var list = new List<T>(_innerArray);
            list.Remove(item);
            list.CopyTo(0, _innerArray, 0, list.Count);

            return true;
        }

        public int Count { get; private set; }

        public bool IsReadOnly => true;

        public static bool operator *(Cset<T> first, Cset<T> second)
        {
            if (first.Count != second.Count) return false;

            return !first.Where((t, i) => !t.Equals(second[i])).Any();
        }

        public static Cset<int> operator +(Cset<T> source, int item)
        {
            if (source.GetType().GenericTypeArguments[0].FullName != "System.Int32") throw new ArgumentException(nameof(source));

            if (source.Contains((dynamic)item)) return null;

            source.Add((dynamic)item);

            return (dynamic)source;
        }

        public static bool operator ==(Cset<int> first, Cset<T> second) => first?.Equals(second) ?? second?.Equals(first) ?? true;

        public static bool operator !=(Cset<int> first, Cset<T> second) => !(first == second);

        public bool Equals(Cset<T> other)
        {
            if (Count != other?.Count) return false;

            for (var i = 0; i < Count; i++)
                if (!this[i].Equals(other[i]))
                    return false;

            return true;
        }

        public Cset<T> Difference(Cset<T> other)
        {
            var enumerable = this.Except(other);

            return new Cset<T>(enumerable);
        }

        public override bool Equals(object obj) => ReferenceEquals(this, obj) || obj is Cset<T> other && Equals(other);

        public override int GetHashCode() => HashCode.Combine(_capacity, _innerArray, Count);
    }
}
