using System.Linq;

namespace RSPO.Library._8
{
    public class ArrayTasks
    {
	    /// <summary>
		/// Увеличивает каждый нечетный элемент массива на первый нечетный элемент массива
		/// </summary>
		/// <param name="array"></param>
		/// <returns>Новый массив, который либо остался без изменений, либо изменен по условию</returns>
	    public int[] IncreaseOnFirstOdd(int[] array)
	    {
		    int firstOdd;
		    try
		    {
			    firstOdd = array.First(x => x % 2 != 0);
		    }
		    catch
		    {
			    return array;
		    }

		    return array.Select(x => x % 2 != 0 ? x + firstOdd : x).ToArray();
	    }
    }
}
