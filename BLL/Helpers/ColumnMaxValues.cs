namespace BLL.Helpers;
public static class ColumnMaxValues
{
    public static IEnumerable<double> GetColumnMaxValues(double[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            double max = matrix[0, i];
            for (int j = 1; j < matrix.GetLength(0); j++)
            {
                if (matrix[j, i] > max)
                {
                    max = matrix[j, i];
                }
            }
            yield return max;
        }
    }
}
