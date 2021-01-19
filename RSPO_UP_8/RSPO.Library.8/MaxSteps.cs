using System;
using System.Collections.Generic;
using System.Text;

namespace RSPO.Library._8
{
    public class MaxSteps
    {
	    public static int _stepsCount = 0;

        public void StepsCount(int[,] matrix,
                               int rowIndex,
                               int columnIndex, 
                               int currentSum, 
                               int currentStepsCount)
        {
	        if(currentSum <= 0 && currentStepsCount > _stepsCount)
	        {
		        _stepsCount = currentStepsCount;
	        }
	        else
	        {
		        if (rowIndex - 1 >= 0)
			        StepsCount(matrix,
			                   rowIndex - 1,
			                   columnIndex, 
			                   currentSum - matrix[rowIndex - 1, columnIndex],
			                   currentStepsCount + 1);
		        else if (columnIndex - 1 >= 0)
			        StepsCount(matrix,
			                   rowIndex,
			                   columnIndex - 1,
			                   currentSum - matrix[rowIndex, columnIndex - 1],
			                   currentStepsCount + 1);
		        else if (rowIndex + 1 < matrix.GetLength(0))
			        StepsCount(matrix,
			                   rowIndex + 1,
			                   columnIndex,
			                   currentSum - matrix[rowIndex + 1, columnIndex],
			                   currentStepsCount + 1);
		        else if (columnIndex + 1 < matrix.GetLength(1))
			        StepsCount(matrix, 
			                   rowIndex,
			                   columnIndex + 1,
			                   currentSum - matrix[rowIndex, columnIndex + 1],
			                   currentStepsCount + 1);
	        }
        }
    }
}
