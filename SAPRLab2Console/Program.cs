using BLL.Helpers;
using BLL.RecognitionAlgorithms;
using SAPRLab2Console;

var data = TestData.GetData2();

Console.WriteLine("Input: ");
PrintHelper.PrintMatrix(data, '\t');

var normalizedToMinDisAlg = Normalizer.NormalizeMatrixFrom0To1(data);

Console.WriteLine("Normalized: ");
PrintHelper.PrintMatrix(normalizedToMinDisAlg, '\t');



Console.WriteLine("\n\n\nMinimal distance algorithm:\n");

var minimalDistanceAlg = new MinimalDistanceAlgorithm(2);
minimalDistanceAlg.Train(normalizedToMinDisAlg);

var predMinimalDistanceAlg = minimalDistanceAlg.Predict(TestData.GetTestValue());
Console.WriteLine($"\n\nPred: {predMinimalDistanceAlg}");



Console.WriteLine("\n\n\nPerception algorithm:\n");

var data2 = TestData.GetData2();
Console.WriteLine("Input: ");
PrintHelper.PrintMatrix(data2, '\t');

var normalizedToPercAlg = Normalizer.NormalizeMatrixFrom0To1(data2);
Console.WriteLine("Normalized data perception algorithm: ");
PrintHelper.PrintMatrix(normalizedToPercAlg, '\t');


var perceptionAlgorithm = new PerceptionAlgorithm(TestData.GetYTrain());
perceptionAlgorithm.Train(normalizedToPercAlg);

var predPerceptionAlgorithm = perceptionAlgorithm.Predict(TestData.GetTestValue());
Console.WriteLine($"\n\nPred: {predPerceptionAlgorithm}");
