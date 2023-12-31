namespace ConsoleRPG
{
    internal static class Utilities
    {
        public static int Random(Range r)
        {
            return new Random().Next(r.Low, r.Hight);
        }

        public static int Random(int low, int high)
        {
            return new Random().Next(low, high);
        }
    }
}
