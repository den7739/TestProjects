namespace SieveOfEratosthenes
{
    public interface IPrimaryNumbersCalculator
    {
        int[] CalculateAllPrimaryNumbers(int size, bool returnOnlyPrimaryNumbers = true);

        int[] CalculateAllCircularPrimaryNumbers(int size);
    }
}