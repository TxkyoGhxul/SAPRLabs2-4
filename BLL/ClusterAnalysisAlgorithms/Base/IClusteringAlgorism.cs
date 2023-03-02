namespace BLL.ClusterAnalysisAlgorithms.Base;
public interface IClusteringAlgorism
{
    void Train();

    double Predict(double[] dataToPredict);
}
