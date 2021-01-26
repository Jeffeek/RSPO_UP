#region Using namespaces

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace RSPO_UP_11
{
	public class Vector : IEnumerable<int>
	{
		private readonly List<int> _internal;

		public Vector() => _internal = new List<int>();

		public int this[int index] => _internal[index];

		public int Count => _internal.Count;

		public static bool operator -(Vector vector, int n) => vector.Count != 0 && vector._internal.Remove(n);

		public static bool operator +(Vector vector, int n)
		{
			if (vector.Count == 0) return false;
			if (vector._internal.Last() == n) throw new ArgumentException(nameof(n));
			vector._internal.Add(n);
			return true;
		}

		public static Vector operator ++(Vector vector)
		{
			if (vector._internal.Count == 0) return vector;
			vector._internal.Add(vector._internal.Last());
			return vector;
		}

		public static Vector operator --(Vector vector)
		{
			if (vector._internal.Count == 0) return vector;
			vector._internal.Remove(vector._internal.Last());
			return vector;
		}

		#region Implementation of IEnumerable

		/// <inheritdoc />
		public IEnumerator<int> GetEnumerator() => _internal.GetEnumerator();

		/// <inheritdoc />
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		#endregion
	}
}