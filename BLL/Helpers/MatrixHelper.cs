using System.Globalization;

namespace BLL.Helpers;
public static class MatrixHelper
{
    public static IEnumerable<T> MatrixToVector<T>(T[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
		{
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                yield return matrix[i, j];
            }
		}
    }

    public static double[,] VectorToMatrix(double[] vector, int rowsCount, int colsCount)
    {
        if (vector.Length != rowsCount * colsCount)
        {
            throw new ArgumentException($"Wrong size of vector. Could be {rowsCount * colsCount}, " +
                $"but was {vector.Length}");
        }

        double[,] matrix = new double[rowsCount, colsCount];
        for (int i = 0; i < rowsCount; i++)
        {
            for (int j = 0; j < colsCount; j++)
            {
                matrix[i, j] = vector[j + colsCount * i];
            }
        }

        return matrix;
    }
}
