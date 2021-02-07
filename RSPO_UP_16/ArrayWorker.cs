using System;
using System.Linq;

namespace RSPO_UP_16
{
    public class ArrayWorker
    {
        //удаление n первых элементов
        public int[] RemoveRangeAtStart(int[] array, int N)
        {
            if (ReferenceEquals(array, null)) throw new ArgumentNullException(nameof(array));
            if (array.Length < N) throw new ArgumentException(nameof(N));
            var newArray = new int[array.Length - N];
            if (array.Length - N == 0) return Array.Empty<int>();
            Array.Copy(array, N, newArray, 0, array.Length - N);
            return newArray;
        }

        //изменение всех элементов путем целочисленного деления на n
        public int[] ChangeByDivOn(int[] array, int N)
        {
            if (ReferenceEquals(array, null)) throw new ArgumentNullException(nameof(array));
            return array.Select(x => x / N).ToArray();
        }

        //поменять местами максимальный и nй элемент массива
        public int[] SwapMaxAndElementAt(int[] array, int N)
        {
            if (ReferenceEquals(array, null)) throw new ArgumentNullException(nameof(array));
            if (N <= 0) throw new ArgumentException(nameof(N));
            var index = N - 1;
            if (index >= array.Length - 1) throw new ArgumentException(nameof(index));
            var indexOfMax = Array.FindIndex(array, x => x == array.Max());
            var temp = array[indexOfMax];
            array[indexOfMax] = array[index];
            array[index] = temp;
            return array;
        }
    }
}
