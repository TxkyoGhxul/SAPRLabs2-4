using BLL.Exceptions;
using BLL.Extensions;
using BLL.RecognitionAlgorithms.Base;

namespace BLL.RecognitionAlgorithms;
public class MinimalDistanceAlgorithm : IRecognitionAlgorithm
{
    private readonly uint _countClasses;

    private bool _isTrained;
    private double[,] _averagePerformance;

    public MinimalDistanceAlgorithm(uint countClasses)
    {
        _isTrained = false;
        _countClasses = countClasses;
    }

    public double Predict(double[] elementToPredict)
    {
        if (elementToPredict.Length != _averagePerformance.GetLength(1))
        {
            throw new ArgumentException($"Invalid data to predict! Count features: {elementToPredict.GetLength(1)}, " +
                $"but should be {_averagePerformance.GetLength(1)}");
        }

        if (!_isTrained)
        {
            throw new ModelNotTrainedException();
        }

        var desizionFuncsResults = new List<double>();
        for (int i = 0; i < _averagePerformance.GetLength(0); i++)
        {
            double funcResult = 0;
            for (int j = 0; j < _averagePerformance.GetLength(1); j++)
            {
                funcResult += 2 * _averagePerformance[i, j];
                funcResult -= _averagePerformance[i, j] * _averagePerformance[i, j];
            }
            desizionFuncsResults.Add(Math.Round(funcResult, 2));
        }

        return desizionFuncsResults.IndexOf(desizionFuncsResults.Max());
    }

    public void Train(double[,] trainingData)
    {
        double countSameClassObjs = trainingData.GetLength(0) / _countClasses;

        if (!countSameClassObjs.IsSingle())
        {
            throw new WrongDataToTrainException();
        }

        _averagePerformance = GetAveragePerfomances(trainingData, (int)countSameClassObjs);

        _isTrained = true;
    }

    private double[,] GetAveragePerfomances(double[,] trainingData, int countSameClassObjs)
    {
        double[,] averagePerformance = new double[_countClasses, countSameClassObjs];
        for (int i = 0; i < _countClasses; i++)
        {
            for (int j = 0; j < trainingData.GetLength(1); j++)
            {
                double sum = 0;
                for (int k = countSameClassObjs * i; k < countSameClassObjs * (i + 1); k++)
                {
                    sum += trainingData[k, j];
                }
                averagePerformance[i, j] = Math.Round(sum / countSameClassObjs, 2);
            }
        }

        return averagePerformance;
    }
}
