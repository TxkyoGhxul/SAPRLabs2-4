using BLL.Exceptions;
using BLL.Helpers;
using BLL.RecognitionAlgorithms.Base;
using Microsoft.Win32.SafeHandles;

namespace BLL.RecognitionAlgorithms;
public class PerceptionAlgorithm : IRecognitionAlgorithm
{
    private readonly byte[] _yTrain;

    private bool _isTrained;
    private List<double> _weigths;

    public PerceptionAlgorithm(byte[] yTrain) => (_yTrain, _isTrained) = (yTrain, false);

    public double Predict(double[] dataToPredict)
    {
        if (!_isTrained)
        {
            throw new ModelNotTrainedException();
        }

        double decisionFunc = _weigths[0];
        for (int i = 0; i < dataToPredict.Length; i++)
        {
            decisionFunc += dataToPredict[i] * _weigths[i + 1];
        }

        return decisionFunc > 0 ? 0 : 1;
    }

    public void Train(double[,] trainingData)
    {
        var weigths = ListElementsGenerator.GetZeros((uint)trainingData.GetLength(1) + 1).ToList();
        int countRigthDecisions = 0;

        int maxCountRigthDecisions = 3;

        while (countRigthDecisions != trainingData.GetLength(0))
        {
            for (int i = 0; i < trainingData.GetLength(0); i++)
            {
                double decisionFunc = weigths[0];
                for (int j = 0; j < trainingData.GetLength(1); j++)
                {
                    decisionFunc += trainingData[i, j] * weigths[j + 1];
                }

                double predict = 2;

                if (decisionFunc > 0) predict = 0;

                if (decisionFunc < 0) predict = 1;

                if (_yTrain[i] == predict)
                {
                    countRigthDecisions++;

                    if (countRigthDecisions > maxCountRigthDecisions)
                    {
                        maxCountRigthDecisions = countRigthDecisions;
                    }

                    if (countRigthDecisions == trainingData.GetLength(0))
                    {
                        _weigths = weigths;
                        break;
                    }

                    continue;
                }

                if (predict == 2)
                {
                    weigths[0]++;
                    countRigthDecisions = 0;
                    for (int j = 0; j < trainingData.GetLength(1); j++)
                    {
                        weigths[j + 1] += trainingData[i, j];
                    }
                    continue;
                }

                if (predict == 1)
                {
                    weigths[0]++;
                    countRigthDecisions = 0;
                    for (int j = 0; j < trainingData.GetLength(1); j++)
                    {
                        weigths[j + 1] += trainingData[i, j];
                    }
                    continue;
                }

                if (predict == 0)
                {
                    weigths[0]--;
                    countRigthDecisions = 0;
                    for (int j = 0; j < trainingData.GetLength(1); j++)
                    {
                        weigths[j + 1] -= trainingData[i, j];
                    }
                    continue;
                }
            }
        }

        _isTrained = true;
    }
}
