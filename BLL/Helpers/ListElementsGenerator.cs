namespace BLL.Helpers;
public static class ListElementsGenerator
{
    public static IEnumerable<double> GetZeros(uint count)
    {
        for (int i = 0; i < count; i++)
        {
            yield return 0;
        }
    }
}
