namespace RSPO_UP_16
{
    internal delegate int[] ArrayWorkerDelegate(int[] array, int N);

    internal delegate void ArrayEvent(int[] array, bool flag);

    public class ConsoleMenu
    {
        private ArrayWorkerDelegate _arrayWorker;
        private int[] _initialArray;

        public ConsoleMenu()
        {
            var worker = new ArrayWorker();
            _arrayWorker += worker.RemoveRangeAtStart;
            _arrayWorker += worker.ChangeByDivOn;
            _arrayWorker += worker.SwapMaxAndElementAt;
        }

        private event ArrayEvent _ele;

        public void Start() { }

        private int SetStrategy()
        {

        }
    }
}