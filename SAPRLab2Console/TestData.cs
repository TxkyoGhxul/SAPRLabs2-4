namespace SAPRLab2Console;
public static class TestData
{
    public static double[,] GetData()
    {
        return new double[,]
        {
            { 1.8, 5, 120, 66, 0.7 },
            { 2.8, 3, 300, 12, 0.5 },
            { 1.3, 6, 440, 34, 0.3 },
            { 1.7, 11, 144, 54, 0.1 },
            { 1.8, 2, 224, 74, 0.5 },
            { 2.1, 5, 123, 54, 0.7 },
            { 2.3, 3, 333, 38, 0.5 },
            { 1.4, 7, 444, 64, 0.3 },
            { 1.6, 12, 144, 26, 0.1 },
            { 1.5, 7, 254, 22, 0.5 }
        };
    }

    public static double[,] GetData2()
    {
        return new double[,]
        {
            { 1.8, 5, 120, 26, 0.3 },
            { 1.8, 3, 100, 22, 0.3 },
            { 1.3, 4, 140, 24, 0.2 },
            { 1.7, 1, 144, 24, 0.1 },
            { 1.8, 2, 124, 24, 0.2 },
            { 5.1, 15, 623, 74, 0.7 },
            { 5.3, 13, 633, 78, 0.5 },
            { 5.4, 17, 644, 74, 0.6 },
            { 5.6, 12, 644, 76, 0.7 },
            { 5.5, 17, 554, 72, 0.9 }
        };
    }

    public static double[,] GetData3()
    {
        return new double[,]
        {
            { 0.13, 0.5 },
            { 0.19, 0.63 },
            { 0.22, 0.38 },
            { 0.44, 0.25 },
            { 0.56, 0.38 },
            { 0.78, 0.44 }
        };
    }

    public static byte[] GetYTrain() => new byte[] { 0, 0, 0, 0, 0, 1, 1, 1, 1, 1 };

    public static byte[] GetYTrain3() => new byte[] { 0, 0, 0, 1, 1, 1 };

    public static double[] GetTestValue() => new double[] { 5.4, 17, 644, 74, 0.3 };
    public static double[] GetTestValue2() => new double[] { 0.3, 0.3 };
}
