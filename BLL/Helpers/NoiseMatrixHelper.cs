namespace BLL.Helpers;
public static class NoiseMatrixHelper
{
    /// <summary>
    /// Method to noise the datas
    /// </summary>
    /// <param name="matrixToNoise">Matrix to noise</param>
    /// <param name="percentage">Percentage to noise</param>
    /// <returns></returns>
    public static void Noise(double[,] matrixToNoise, double percentage)
    {
        if (percentage < 0 || percentage > 1)
        {
            throw new ArgumentOutOfRangeException($"Percentage could be from 0 to 1, but was {percentage}");
        }

        int countNoisesPerRow = (int)Math.Round(percentage * matrixToNoise.GetLength(0));
        for (int i = 0; i < matrixToNoise.GetLength(0); i++)
        {
            var indexesToNoise = new List<int>();
            while (indexesToNoise.Count != countNoisesPerRow)
            {
                var index = Random.Shared.Next(0, matrixToNoise.GetLength(0));
                if (!indexesToNoise.Contains(index))
                {
                    indexesToNoise.Add(index);
                }
            }

            for (int j = 0; j < countNoisesPerRow; j++)
            {
                matrixToNoise[i, indexesToNoise[j]] = matrixToNoise[i, indexesToNoise[j]] == 1 ? -1 : 1;
            }
        }
    }

    //public static void Noise(byte[,] matrixToNoise, double percentage)
    //{
    //    if (percentage < 0 || percentage > 1)
    //    {
    //        throw new ArgumentOutOfRangeException($"Percentage could be from 0 to 1, but was {percentage}");
    //    }

    //    int countNoisesPerRow = (int)Math.Round(percentage * matrixToNoise.GetLength(0));
    //    for (int i = 0; i < matrixToNoise.GetLength(0); i++)
    //    {
    //        var indexesToNoise = new List<int>();
    //        while (indexesToNoise.Count != countNoisesPerRow)
    //        {
    //            var index = Random.Shared.Next(0, matrixToNoise.GetLength(0));
    //            if (!indexesToNoise.Contains(index))
    //            {
    //                indexesToNoise.Add(index);
    //            }
    //        }

    //        for (int j = 0; j < countNoisesPerRow; j++)
    //        {
    //            matrixToNoise[i, indexesToNoise[j]] = matrixToNoise[i, indexesToNoise[j]] == 0 ? (byte)1 : (byte)0;
    //        }
    //    }
    //}

    public static void ReverseAllBytes(byte[,] matrixToNoise)
    {
        for (int i = 0; i < matrixToNoise.GetLength(0); i++)
        {
            for (int j = 0; j < matrixToNoise.GetLength(1); j++)
            {
                matrixToNoise[i, j] = matrixToNoise[i, j] == 0 ? (byte)1 : (byte)0;
            }
        }
    }
}
