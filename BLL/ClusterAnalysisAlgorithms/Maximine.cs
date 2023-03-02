using BLL.ClusterAnalysisAlgorithms.Base;
using BLL.Exceptions;

namespace BLL.ClusterAnalysisAlgorithms;
public class Maximine : IClusteringAlgorism
{
    private readonly double[,] _trainingData;
    private readonly int _countFeatures;
    private readonly List<List<double>> _prototypes;
    private int _countClusters => _prototypes.Count;

    private bool _isTrained;

    public Maximine(double[,] trainingData)
    {
        _trainingData = trainingData;
        _countFeatures = _trainingData.GetLength(1);
        _isTrained = false;
        _prototypes = new List<List<double>>();

        _prototypes.Add(new List<double>());
        for (int i = 0; i < trainingData.GetLength(1); i++)
        {
            _prototypes[0].Add(trainingData[0, i]);
        }
    }

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
                distance += Math.Abs(_prototypes[i][j] - objToPredict[j]);
            }
            distance = Math.Round(Math.Sqrt(distance), 2);
            distancesToEachCluster.Add(distance);
        }
        return distancesToEachCluster.IndexOf(distancesToEachCluster.Min());
    }

    public void Train()
    {
        //2
        var distancesToEachCluster = new List<double>();
        for (int i = 1; i < _trainingData.GetLength(0); i++)
        {
            double distance = 0;
            for (int j = 0; j < _trainingData.GetLength(1); j++)
            {
                distance += Math.Abs(_prototypes[0][j] - _trainingData[i, j]);
            }
            distance = Math.Round(Math.Sqrt(distance), 2);
            distancesToEachCluster.Add(distance);
        }

        int indexOfMaxDistance = distancesToEachCluster.IndexOf(distancesToEachCluster.Max());
        _prototypes.Add(new List<double>());
        for (int i = 0; i < _trainingData.GetLength(1); i++)
        {
            _prototypes[^1].Add(_trainingData[indexOfMaxDistance, i]);
        }

        //3
        double thresholdDistance = (_prototypes[0].Sum() + _prototypes[1].Sum()) / 2;

        while (true)
        {
            //4
            var yPredicted = new List<int>();
            var distancesToPrototypes = new List<double>();
            for (int i = 0; i < _trainingData.GetLength(0); i++)
            {
                var distances = new List<double>();
                for (int j = 0; j < _countClusters; j++)
                {
                    double distance = 0;
                    for (int k = 0; k < _countFeatures; k++)
                    {
                        distance += Math.Abs(_prototypes[j][k] - _trainingData[i, k]);
                    }
                    distance = Math.Round(Math.Sqrt(distance), 2);
                    distances.Add(distance);
                }
                yPredicted.Add(distances.IndexOf(distances.Min()));
                distancesToPrototypes.Add(distances.Min());
            }

            //5
            var mostFarFromClusters = new List<double>();
            var mostFarFromClustersIndxs = new List<int>();
            for (int clusterIndx = 0; clusterIndx < _countClusters; clusterIndx++)
            {
                double maxDistance = 0;
                int indxOfMaxDist = 0;
                for (int i = 0; i < yPredicted.Count; i++)
                {
                    if (yPredicted[i] == clusterIndx)
                    {
                        if (maxDistance < distancesToPrototypes[i])
                        {
                            maxDistance = distancesToPrototypes[i];
                            indxOfMaxDist = i;
                        }
                    }
                }
                mostFarFromClusters.Add(maxDistance);
                mostFarFromClustersIndxs.Add(indxOfMaxDist);
            }

            //6
            bool isClusterised = mostFarFromClusters
                .Select(x => x >= thresholdDistance)
                .Count(x => x == true) == 0;

            if (isClusterised) break;

            for (int i = 0; i < mostFarFromClusters.Count; i++)
            {
                if (mostFarFromClusters[i] >= thresholdDistance)
                {
                    _prototypes.Add(new List<double>());
                    for (int j = 0; j < _trainingData.GetLength(1); j++)
                    {
                        _prototypes[^1].Add(_trainingData[mostFarFromClustersIndxs[i], j]);
                    }
                }
            }

            //7
            thresholdDistance = 0;
            for (int i = 1; i < _countClusters; i++)
            {
                for (int j = i + 1; j < _countClusters + 1; j++)
                {
                    double distance = 0;
                    for (int k = 0; k < _countFeatures; k++)
                    {
                        distance += Math.Abs(_prototypes[i][k] - _prototypes[j][k]);
                    }
                    distance = Math.Round(Math.Sqrt(distance), 2);
                    thresholdDistance += distance;
                }
            }
            thresholdDistance /= _countClusters * (_countClusters - 1);
        }

        _isTrained = true;
    }

    public override string ToString()
    {
        return $"[{_countClusters}]";
    }
}
