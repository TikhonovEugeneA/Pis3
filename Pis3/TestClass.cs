using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Pis3
{
    public class TestClass
    {
        public static int CountZeroes(string input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input),"Строка не может быть пустой");
            return input.Count(c=>c=='0');
        }
    }
}
