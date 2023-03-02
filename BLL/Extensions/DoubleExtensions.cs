namespace BLL.Extensions;
public static class DoubleExtensions
{
    public static bool IsSingle(this double number) => number == Math.Round(number, 0);
}
