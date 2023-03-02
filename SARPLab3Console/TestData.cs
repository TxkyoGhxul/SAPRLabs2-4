namespace SARPLab3Console;
public static class TestData
{
    public static double[,] GetData()
    {
        return new double[,]
        {
            { 1.8, 5, 120 },
            { 1.8, 3, 100 },
            { 1.3, 4, 140 },
            { 1.7, 1, 144 },
            { 1.8, 2, 124 },
            { 5.1, 15, 623 },
            { 5.3, 13, 633 },
            { 5.4, 17, 644 },
            { 5.6, 12, 644 },
            { 5.5, 17, 554 }
        };
    }

    public static double[] GetTestValue()
    {
        return new double[] { 1.8, 3, 120 };
    }

    public static double[] GetTestValue2()
    {
        return new double[] { 5.5, 17, 554 };
    }
}
