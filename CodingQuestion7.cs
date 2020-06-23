using System;

namespace CodingQuestion7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int[] val = {2, 4, 6, 2, 5};

            Console.WriteLine("Result: " + function(val));
        }

        static int function(int[] val)
        {
            int maxSum = int.MinValue;

            for(var i = 0; i < val.Length - 1; i++)
            {
                for(var j = 2;  i + j < val.Length; j++)
                {
                    int tmpSum = val[i];
                    for(var z = i + j; z < val.Length; z += j)
                    {
                        tmpSum += val[z];
                    }

                    if (tmpSum > maxSum)
                    {
                        //Console.WriteLine("TmpSum: " + tmpSum);
                        maxSum = tmpSum;
                    }
                }
            }

            return maxSum;
        }

    }
}
