namespace Pis3
{
    public class LengthNull
    {
        public int CounterZeros(string input, char symbol)
        {
            int maxCounter = 0;
            int currentCounter = 0;
            foreach (char c in input)
            {
                if (c == symbol && input.Length > 0)
                {
                    currentCounter++;
                    if (currentCounter > maxCounter)
                    {
                        maxCounter = currentCounter;
                    }
                }
                else
                {
                    currentCounter = 0;
                }
            }
            return maxCounter;
        }
    }
}
