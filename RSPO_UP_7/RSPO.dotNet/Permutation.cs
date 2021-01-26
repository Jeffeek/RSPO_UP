#region Using namespaces

using System.Collections.Generic;
using System.Linq;

#endregion

namespace RSPO.dotNet
{
	/// <summary>
	///     Extension for <see cref="IEnumerable{T}" />
	/// </summary>
	public static class Permutation
	{
		/// <summary>
		///     Returns a new <see cref="IEnumerable{T}"/> collections with all permutations of elements <see>
		///         <cref>{T}</cref>
		///     </see>
		///     >
		/// </summary>
		/// <typeparam name="T">ANY</typeparam>
		/// <param name="list">List of elements</param>
		/// <param name="length">Max length for algorithm</param>
		/// <returns>New <see cref="IEnumerable{T}"/> collection with permutations/></returns>
		public static IEnumerable<IEnumerable<T>> GetPermutations<T>(this IEnumerable<T> list, int length)
		{
			if (length == 1) return list.Select(t => new[] {t});

			var enumerable = list as T[] ?? list.ToArray();
			return GetPermutations(enumerable, length - 1)
				.SelectMany(t => enumerable.Where(e => !t.Contains(e)),
				            (t1, t2) => t1.Concat(new[] {t2}));
		}
	}
}