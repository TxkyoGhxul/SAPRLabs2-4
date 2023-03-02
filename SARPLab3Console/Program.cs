using BLL.ClusterAnalysisAlgorithms;
using BLL.Helpers;
using SARPLab3Console;

var data = TestData.GetData();
var dataMaxValues = ColumnMaxValues.GetColumnMaxValues(data).ToList();
var normalizedData = Normalizer.NormalizeMatrixFrom0To1(data);
var dataToPred1 = TestData.GetTestValue();
var dataToPredNormalized1 = Normalizer.NormalizeList(dataToPred1, dataMaxValues).ToArray();
var dataToPred2 = TestData.GetTestValue2();
var dataToPredNormalized2 = Normalizer.NormalizeList(dataToPred2, dataMaxValues).ToArray();

#region KMeans
var kMeans = new KMeans(2, normalizedData);
kMeans.Train();

var prediction1 = kMeans.Predict(dataToPredNormalized1);
Console.WriteLine(prediction1);

var prediction2 = kMeans.Predict(dataToPredNormalized2);
Console.WriteLine(prediction2);
#endregion

#region Maximine
var maximine = new Maximine(normalizedData);
maximine.Train();

var prediction3 = maximine.Predict(dataToPredNormalized1);
Console.WriteLine(prediction3);

var prediction4 = maximine.Predict(dataToPredNormalized2);
Console.WriteLine(prediction4);

Console.WriteLine($"Count clusters: {maximine}");
#endregion

PrintHelper.PrintMatrix(kMeans.GetPrototypes(), '\t');