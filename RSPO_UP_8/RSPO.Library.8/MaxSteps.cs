namespace RSPO.Library._8
{
    public class MaxSteps
    {
	    public int MaxStepsCount = 0;

	    public void CalculateStepsCount(int[,] matrix, int rowIndex, int columnIndex, int currentSum, int currentStepsCount)
	    {
		    while(true)
		    {
			    if(currentSum <= 0 &&
			       currentStepsCount > MaxStepsCount)
			    {
				    MaxStepsCount = currentStepsCount;
			    }
			    else
			    {
				    if(rowIndex - 1 >= 0)
				    {
					    var tempMatrix = matrix;
					    var tempRowIndex = rowIndex;
					    var tempColumnIndex = columnIndex;
					    rowIndex -= 1;
					    currentSum -= tempMatrix[tempRowIndex - 1, tempColumnIndex];
					    currentStepsCount += 1;
					    continue;
				    }

				    if (columnIndex - 1 >= 0)
				    {
					    var tempMatrix = matrix;
					    var tempRowIndex = rowIndex;
					    var tempColumnIndex = columnIndex;
					    columnIndex -= 1;
					    currentSum -= tempMatrix[tempRowIndex, tempColumnIndex - 1];
					    currentStepsCount += 1;
					    continue;
				    }

				    if (rowIndex + 1 < matrix.GetLength(0))
				    {
					    var tempMatrix = matrix;
					    var tempRowIndex = rowIndex;
					    var tempColumnIndex = columnIndex;
					    rowIndex += 1;
					    currentSum -= tempMatrix[tempRowIndex + 1, tempColumnIndex];
					    currentStepsCount += 1;
					    continue;
				    }

				    if (columnIndex + 1 < matrix.GetLength(1))
				    {
					    var tempMatrix = matrix;
					    var tempRowIndex = rowIndex;
					    var tempColumnIndex = columnIndex;
					    columnIndex += 1;
					    currentSum -= tempMatrix[tempRowIndex, tempColumnIndex + 1];
					    currentStepsCount += 1;
					    continue;
				    }
			    }

			    break;
		    }
	    }
    }
}
