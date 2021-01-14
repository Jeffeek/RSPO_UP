using System.Linq;

namespace RSPO.Library._8
{
    public class ArrayTasks
    {
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
