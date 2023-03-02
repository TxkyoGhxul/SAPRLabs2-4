namespace BLL.RecognitionAlgorithms.Base;
public interface IRecognitionAlgorithm
{
    void Train(double[,] trainingData);

    double Predict(double[] dataToPredict);
}
