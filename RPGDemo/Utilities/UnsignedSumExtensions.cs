namespace RPG.Test.Utilities;

internal static class UnsignedSumExtensions
{
    public static uint Sum(this IEnumerable<uint> parts) 
        => parts.Aggregate(0U, (current, part) => current + part);
}