using System;
using System.Linq;

namespace DeveloperSample.Algorithms
{
    public static class Algorithms
    {
        public static int GetFactorial(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("n must be non-negative");
            }

            int factorial = 1;
            for (int i = 2; i <= n; i++)
            {
                factorial *= i;
            }

            return factorial;
        }

        public static string FormatSeparators(params string[] items)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            if (items.Length == 0)
            {
                return string.Empty;
            }

            if (items.Length == 1)
            {
                return items[0];
            }

            if (items.Length == 2)
            {
                return $"{items[0]} and {items[1]}";
            }

            return $"{string.Join(", ", items.Take(items.Length - 1))}, and {items.Last()}";
        }
    }
}