using System.Data;

namespace RSPO_UP_5.Model
{
    public class MatrixConverter
    {
        public DataTable ConvertToDataTable(Matrix matrix)
        {
            var table = new DataTable();
            for (int i = 0; i < matrix.ColumnsCount; i++)
                table.Columns.Add();
            for (int i = 0; i < matrix.RowsCount; i++)
                table.Rows.Add();

            for (int i = 0; i < matrix.RowsCount; i++)
            {
                for (int j = 0; j < matrix.ColumnsCount; j++)
                {
                    table.Rows[i][j] = matrix[i, j];
                }
            }

            return table;
        }

        public Matrix ConvertFromDataTable(DataTable table)
        {
            var matrix = new Matrix(table.Rows.Count, table.Columns.Count);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    matrix[i, j] = double.Parse(table.Rows[i][j].ToString());
                }
            }

            return matrix;
        }
    }
}
