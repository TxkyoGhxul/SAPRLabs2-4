﻿namespace SAPRLab4Console;
public static class TestData
{
    public static double[,] GetP()
    {
        return new double[,]
        {
            { 1, 1,  1,  1,  1,  1,  1,  1, 1, 1 },
            { 1, 1,  1,  1,  1,  1,  1,  1, 1, 1 },
            { 1, 1, -1, -1, -1, -1, -1, -1, 1, 1 },
            { 1, 1, -1, -1, -1, -1, -1, -1, 1, 1 },
            { 1, 1, -1, -1, -1, -1, -1, -1, 1, 1 },
            { 1, 1, -1, -1, -1, -1, -1, -1, 1, 1 },
            { 1, 1, -1, -1, -1, -1, -1, -1, 1, 1 },
            { 1, 1, -1, -1, -1, -1, -1, -1, 1, 1 },
            { 1, 1, -1, -1, -1, -1, -1, -1, 1, 1 },
            { 1, 1, -1, -1, -1, -1, -1, -1, 1, 1 }
        };
    }

    public static double[,] GetO()
    {
        return new double[,]
        {
            { 1, 1,  1,  1,  1,  1,  1,  1, 1, 1 },
            { 1, 1,  1,  1,  1,  1,  1,  1, 1, 1 },
            { 1, 1, -1, -1, -1, -1, -1, -1, 1, 1 },
            { 1, 1, -1, -1, -1, -1, -1, -1, 1, 1 },
            { 1, 1, -1, -1, -1, -1, -1, -1, 1, 1 },
            { 1, 1, -1, -1, -1, -1, -1, -1, 1, 1 },
            { 1, 1, -1, -1, -1, -1, -1, -1, 1, 1 },
            { 1, 1, -1, -1, -1, -1, -1, -1, 1, 1 },
            { 1, 1,  1,  1,  1,  1,  1,  1, 1, 1 },
            { 1, 1,  1,  1,  1,  1,  1,  1, 1, 1 }
        };
    }

    public static double[,] GetM()
    {
        return new double[,]
        {
            { 1, 1,  1, -1, -1, -1, -1,  1, 1, 1 },
            { 1, 1,  1, -1, -1, -1, -1,  1, 1, 1 },
            { 1, 1,  1,  1, -1, -1,  1,  1, 1, 1 },
            { 1, 1,  1,  1,  1,  1,  1,  1, 1, 1 },
            { 1, 1, -1,  1,  1,  1,  1, -1, 1, 1 },
            { 1, 1, -1, -1,  1,  1, -1, -1, 1, 1 },
            { 1, 1, -1, -1, -1, -1, -1, -1, 1, 1 },
            { 1, 1, -1, -1, -1, -1, -1, -1, 1, 1 },
            { 1, 1, -1, -1, -1, -1, -1, -1, 1, 1 },
            { 1, 1, -1, -1, -1, -1, -1, -1, 1, 1 }
        };
    }

    //public static byte[,] GetP()
    //{
    //    return new byte[,]
    //    {
    //        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
    //        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
    //        { 1, 1, 0, 0, 0, 0, 0, 0, 1, 1 },
    //        { 1, 1, 0, 0, 0, 0, 0, 0, 1, 1 },
    //        { 1, 1, 0, 0, 0, 0, 0, 0, 1, 1 },
    //        { 1, 1, 0, 0, 0, 0, 0, 0, 1, 1 },
    //        { 1, 1, 0, 0, 0, 0, 0, 0, 1, 1 },
    //        { 1, 1, 0, 0, 0, 0, 0, 0, 1, 1 },
    //        { 1, 1, 0, 0, 0, 0, 0, 0, 1, 1 },
    //        { 1, 1, 0, 0, 0, 0, 0, 0, 1, 1 }
    //    };
    //}

    //public static byte[,] GetO()
    //{
    //    return new byte[,]
    //    {
    //        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
    //        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
    //        { 1, 1, 0, 0, 0, 0, 0, 0, 1, 1 },
    //        { 1, 1, 0, 0, 0, 0, 0, 0, 1, 1 },
    //        { 1, 1, 0, 0, 0, 0, 0, 0, 1, 1 },
    //        { 1, 1, 0, 0, 0, 0, 0, 0, 1, 1 },
    //        { 1, 1, 0, 0, 0, 0, 0, 0, 1, 1 },
    //        { 1, 1, 0, 0, 0, 0, 0, 0, 1, 1 },
    //        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
    //        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
    //    };
    //}

    //public static byte[,] GetM()
    //{
    //    return new byte[,]
    //    {
    //        { 1, 1, 1, 0, 0, 0, 0, 1, 1, 1 },
    //        { 1, 1, 1, 0, 0, 0, 0, 1, 1, 1 },
    //        { 1, 1, 1, 1, 0, 0, 1, 1, 1, 1 },
    //        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
    //        { 1, 1, 0, 1, 1, 1, 1, 0, 1, 1 },
    //        { 1, 1, 0, 0, 1, 1, 0, 0, 1, 1 },
    //        { 1, 1, 0, 0, 0, 0, 0, 0, 1, 1 },
    //        { 1, 1, 0, 0, 0, 0, 0, 0, 1, 1 },
    //        { 1, 1, 0, 0, 0, 0, 0, 0, 1, 1 },
    //        { 1, 1, 0, 0, 0, 0, 0, 0, 1, 1 }
    //    };
    //}

    public static double[] GetTestValue()
    {
        return new double[] { 1.8, 3, 120 };
    }

    public static double[] GetTestValue2()
    {
        return new double[] { 5.5, 17, 554 };
    }
}
