namespace BLL.Helpers;
public static class Normalizer
{
    public static IEnumerable<double> NormalizeList(IEnumerable<double> listToNormalize) =>
        listToNormalize.Select(x => x / listToNormalize.Max());

    public static IEnumerable<double> NormalizeList(IEnumerable<double> listToNormalize,
        IEnumerable<double> maxValues)
    {
        if (listToNormalize.Count() != maxValues.Count())
        {
            throw new InvalidDataException("Lists must be the same sized");
        }

        foreach (var tuple in listToNormalize.Zip(maxValues, Tuple.Create))
        {
            yield return tuple.Item1 / tuple.Item2;
        }
    }

    public static double[,] NormalizeMatrixFrom0To1(double[,] dataToNormalize)
    {
        for (int i = 0; i < dataToNormalize.GetLength(1); i++)
        {
            //Getting max value of the column
            double maxColumnValue = dataToNormalize[0, i];
            for (int j = 1; j < dataToNormalize.GetLength(0); j++)
            {
                if (dataToNormalize[j, i] > maxColumnValue)
                {
                    maxColumnValue = dataToNormalize[j, i];
                }
            }

            //Devising all column elements by maxColumnValue
            for (int j = 0; j < dataToNormalize.GetLength(0); j++)
            {
                dataToNormalize[j, i] = Math.Round(dataToNormalize[j, i] / maxColumnValue, 2);
            }
        }

        return dataToNormalize;
    }

    public static double[,] NormalizeMatrixFromMinusToPlusDot5(double[,] dataToNormalize)
    {
        for (int i = 0; i < dataToNormalize.GetLength(1); i++)
        {
            //Getting max value of the column
            double maxColumnValue = dataToNormalize[0, i];
            for (int j = 1; j < dataToNormalize.GetLength(0); j++)
            {
                if (dataToNormalize[j, i] > maxColumnValue)
                {
                    maxColumnValue = dataToNormalize[j, i];
                }
            }

            //Devising all column elements by maxColumnValue
            for (int j = 0; j < dataToNormalize.GetLength(0); j++)
            {
                dataToNormalize[j, i] = Math.Round(dataToNormalize[j, i] / maxColumnValue - 0.5, 2);
            }
        }

        return dataToNormalize;
    }
}
