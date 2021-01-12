namespace RSPO.dotNet
{
    /// <summary>
    /// An integer N (> 0) is given.
    /// Find the largest integer K whose square does not exceed N: K2 <= N.
    /// </summary>
    public static class LargestIntegerKSquareNotExceedN
    {
        /// <summary>
        /// Calculates the result
        /// </summary>
        /// <param name="N">Bound for function</param>
        /// <returns>The largest integer K whose square does not exceed N</returns>
        public static int Calculate(uint N)
        {
            int k = 1;
            while (k * k <= N) k++;
            return k - 1;
        }
    }
}
