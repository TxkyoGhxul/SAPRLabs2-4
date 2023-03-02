using BLL.Helpers;
using BLL.NeuralNetworks;
using SAPRLab4Console;

#region Task
var p = TestData.GetP();
var pVector = MatrixHelper.MatrixToVector(p).ToArray();

var o = TestData.GetO();
var oVector = MatrixHelper.MatrixToVector(o).ToArray();

var m = TestData.GetM();
var mVector = MatrixHelper.MatrixToVector(m).ToArray();



var testP = TestData.GetP();

Console.WriteLine("Original matrix: ");
PrintHelper.PrintMatrix(testP, ' ');

NoiseMatrixHelper.Noise(testP, 0.5);
var testPVector = MatrixHelper.MatrixToVector(testP).ToArray();

Console.WriteLine("\n\n\n\nNoised matrix: ");
PrintHelper.PrintMatrix(testP, ' ');

var trainData = new double[3, pVector.Length];
for (int i = 0; i < trainData.GetLength(1); i++)
{
    trainData[0, i] = pVector[i];
    trainData[1, i] = oVector[i];
    trainData[2, i] = mVector[i];
}

var hopfield = new HopfieldNN(trainData);
var predict = hopfield.Predict(testPVector);
var outputMatrix = MatrixHelper.VectorToMatrix(predict, testP.GetLength(0), testP.GetLength(1));

Console.WriteLine("\n\n\n\nOutput matrix: ");
PrintHelper.PrintMatrix(outputMatrix, ' ');
#endregion

//var trainData = new double[,]
//{
//    {1, -1, 1},
//    {1, 1, -1},
//    {1, -1, 1}
//};

//var hopfield = new HopfieldNN(trainData);

//PrintHelper.PrintMatrix(hopfield.Weigths, ' ');