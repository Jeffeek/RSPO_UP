using System;
using System.Collections.Generic;
using System.Text;

namespace RSPO_UP_16
{
	public delegate int[] ArrayWorkerDelegate(int[] array, int N);
	public delegate void ArrayEvent(int[] array, bool flag);
    public class ConsoleMenu
    {
	    private ArrayWorkerDelegate _arrayWorker;
		private event ArrayEvent _ele
	    private int[] _initialArray;
	    public ConsoleMenu()
	    {
		    var worker = new ArrayWorker();
		    _arrayWorker += worker.RemoveRangeAtStart;
		    _arrayWorker += worker.ChangeByDivOn;
		    _arrayWorker += worker.SwapMaxAndElementAt;
	    }

		public void Start()
		{

		}


		private int SetStrategy()
		{

		}
    }
}
