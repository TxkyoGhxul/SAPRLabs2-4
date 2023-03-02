namespace SARPLab3Console;
internal static class PrintHelper
{
    public static void PrintCollection<T>(IEnumerable<T> toPrint, char elementsSeparator = ' ')
    {
        foreach (var elem in toPrint)
        {
            Console.Write(elem + elementsSeparator.ToString());
        }
    }

    public static void PrintMatrix<T>(T[,] matrix, char elementsSeparator = ' ')
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + elementsSeparator.ToString());
            }
            Console.Write("\n\n");
        }
    }
}
