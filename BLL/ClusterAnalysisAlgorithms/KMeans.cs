using BLL.ClusterAnalysisAlgorithms.Base;
using BLL.Exceptions;

namespace BLL.ClusterAnalysisAlgorithms;
public class KMeans : IClusteringAlgorism
{
    private readonly int _countClusters;
    private readonly double[,] _trainingData;
    private readonly int _countFeatures;
    private readonly double[,] _prototypes;

    private bool _isTrained;

    public KMeans(int countClusters, double[,] trainingData)
    {
        if (countClusters < 2) throw new ArgumentException("Count of clusters can't be less than 2");

        _countClusters = countClusters;
        _trainingData = trainingData;
        _countFeatures = _trainingData.GetLength(1);
        _prototypes = new double[_countClusters, _countFeatures];
        _isTrained = false;
    }

    public double[,] GetPrototypes() => _prototypes;

    public double Predict(double[] objToPredict)
    {
        if (!_isTrained)
        {
            throw new ModelNotTrainedException();
        }

        var distancesToEachCluster = new List<double>();
        for (int i = 0; i < _countClusters; i++)
        {
            double distance = 0;
            for (int j = 0; j < _countFeatures; j++)
            {
                distance += Math.Abs(_prototypes[i, j] - objToPredict[j]);
            }
            distance = Math.Round(Math.Sqrt(distance), 2);
            distancesToEachCluster.Add(distance);
        }
        return distancesToEachCluster.IndexOf(distancesToEachCluster.Min());
    }

    public void Train()
    {
        double[] yPredicted = new double[_trainingData.GetLength(0)];

        //Getting prototypes
        for (int i = 0; i < _countClusters; i++)
        {
            for (int j = 0; j < _countFeatures; j++)
            {
                if (i % 2 == 0)
                {
                    _prototypes[i, j] = _trainingData[i, j];
                }
                else
                {
                    _prototypes[i, j] = _trainingData[_trainingData.GetLength(0) - i, j];
                }
            }
        }

        int iterationNumber = 1;
        int countRewrites = 0;
        while (countRewrites != 0)
        {
            //Getting prediction
            for (int i = 0; i < _trainingData.GetLength(0); i++)
            {
                var distancesToEachCluster = new List<double>();
                for (int j = 0; j < _countClusters; j++)
                {
                    double distance = 0;
                    for (int k = 0; k < _countFeatures; k++)
                    {
                        distance += Math.Abs(_prototypes[j, k] - _trainingData[i, k]);
                    }
                    distance = Math.Round(Math.Sqrt(distance), 2);
                    distancesToEachCluster.Add(distance);
                }
                yPredicted[i] = distancesToEachCluster.IndexOf(distancesToEachCluster.Min());
            }

            //Getting new prototypes
            for (int i = 0; i < _countClusters; i++)
            {
                int countSameClusters = yPredicted.Count(x => x == i);
                //Getting mean values
                double[] meanValues = new double[_countFeatures];
                for (int j = 0; j < _trainingData.GetLength(0); j++)
                {
                    if (yPredicted[j] != i) continue;

                    for (int k = 0; k < _countFeatures; k++)
                    {
                        meanValues[k] += _trainingData[j, k] / countSameClusters;
                    }
                }

                //Rewriting new prototypes values
                countRewrites = 0;
                for (int j = 0; j < _prototypes.GetLength(0); j++)
                {
                    if (_prototypes[i, j] != Math.Round(meanValues[j], 2))
                    {
                        _prototypes[i, j] = Math.Round(meanValues[j], 2);
                        countRewrites++;
                    }
                }

                if (countRewrites == 0) break;
            }
            iterationNumber++;
        }

        _isTrained = true;
    }
}
