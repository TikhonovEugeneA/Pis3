using System;
using System.Linq;

namespace Pis3
{
    public static class TestClass
    {
        public static int CountZeroes(string input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input), "Строка не может быть пустой");
            return input.Count(c => c == '0');
        }
    }
}
