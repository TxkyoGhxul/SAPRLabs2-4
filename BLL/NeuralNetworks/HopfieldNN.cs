namespace BLL.NeuralNetworks;
public class HopfieldNN
{
    private readonly double[,] _trainingData;
    private readonly double[,] _weigths;
    private readonly int _countFeatures;

    private bool _isTrained;

    public HopfieldNN(double[,] trainingData)
    {
        _trainingData = trainingData;
        _countFeatures = _trainingData.GetLength(1);
        _isTrained = false;
        _weigths = new double[_countFeatures, _countFeatures];

        FillingWeigths();
        MirroringByMainDiag();

        _isTrained = true;
    }

    private void MirroringByMainDiag()
    {
        for (int i = 0; i < _weigths.GetLength(0); i++)
        {
            for (int j = i + 1; j < _weigths.GetLength(1); j++)
            {
                _weigths[j, i] = _weigths[i, j];
            }
        }
    }

    private void FillingWeigths()
    {
        for (int i = 0; i < _countFeatures; i++)
        {
            for (int j = i + 1; j < _countFeatures; j++)
            {
                double sum = 0;
                for (int k = 0; k < _trainingData.GetLength(0); k++)
                {
                    sum += _trainingData[k, i] * _trainingData[k, j];
                }
                _weigths[i, j] = sum;
            }
        }
    }

    public double[] Predict(double[] matrixToPredict)
    {
        double[] predicted = new double[matrixToPredict.Length];

        for (int i = 0; i < matrixToPredict.Length; i++)
        {
            double tmp = 0;

            for (int j = 0; j < matrixToPredict.Length; j++)
            {
                tmp += matrixToPredict[j] * _weigths[i, j];
            }

            predicted[i] = tmp > 0 ? 1 : -1;
        }

        return predicted;
    }
}
