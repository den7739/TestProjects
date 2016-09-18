namespace SieveOfEratosthenes
{
    public static class StringExtensions//метод расширения, для циклического сдвига строки
    {
        public static string Shift(this string s, int count)
        {
            return s.Remove(0, count) + s.Substring(0, count);
        }
    }
}