/*This problem was asked by Facebook.

Given the mapping a = 1, b = 2, ... z = 26, and an encoded message, count the number of ways it can be decoded.

For example, the message '111' would give 3, since it could be decoded as 'aaa', 'ka', and 'ak'.

You can assume that the messages are decodable. For example, '001' is not allowed.*/


using System;
using System.Collections.Generic;

namespace CodingQuestion6
{
    public unsafe class Program
    {
        public unsafe static void Main()
        {
            Console.WriteLine("Hello World!");

            //string we want to find all the possible number of ways it can be decoded
            string input = "111";

            //letters available
            List<string> inputString = new List<string>();
            inputString.Add("a");
            inputString.Add("b");
            inputString.Add("c");
            inputString.Add("d");
            inputString.Add("e");
            inputString.Add("f");
            inputString.Add("g");
            inputString.Add("h");
            inputString.Add("i");
            inputString.Add("j");
            inputString.Add("k");
            inputString.Add("l");
            inputString.Add("m");

            // inputString[10] = "m"   =:   inputNumber[10] =11
            List<int> inputNumber = new List<int>();
            inputNumber.Add(1);
            inputNumber.Add(2);
            inputNumber.Add(3);
            inputNumber.Add(4);
            inputNumber.Add(5);
            inputNumber.Add(6);
            inputNumber.Add(7);
            inputNumber.Add(8);
            inputNumber.Add(9);
            inputNumber.Add(10);
            inputNumber.Add(11);
            inputNumber.Add(12);
            inputNumber.Add(13);

            int countComb = 0;
            //input.Length because 111 corresponds to aaa for example and so we have to find almost all the possible string with length equal to 3
            for (var i = 1; i <= input.Length; i++) 
            {
                string[] res = new string[i];
                allCombinations(0, inputString, inputNumber, res, &countComb, input);
            }
            Console.WriteLine("Combinations number: " + countComb);

            //POWERSET
            //int[] isTaken = new int[inputString.Count]; // 0 == not taken, 1 == taken
            //f(0, inputString, inputNumber, isTaken);

        }

        static unsafe void allCombinations(int currentInd, List<string> inputL, List<int> inputN, string[] res, int *countComb, string input)
        {
            if (currentInd >= res.Length)
            {
                Console.Write("Result: ");
                foreach (var tmpChar in res)
                    Console.Write(tmpChar);
                Console.Write("    ->     ");

                string newString = "";  //It contains numbers corresponding to the letters res[i]
                for (var i  = 0; i < res.Length; i++)
                {
                    for (var j = 0; j < inputL.Count; j++)
                    {
                        if (inputL[j] == res[i])
                        {
                            newString = newString + inputN[j];
                            break;
                        }
                    }
                }
                foreach (var tmpChar in newString)
                    Console.Write(tmpChar);
                Console.Write("        ");
                if (newString == input)
                {
                    Console.Write("     ->       " + newString);
                    (*countComb)++;
                }

                Console.WriteLine();
                return;
            }

            for (var j = 0; j < inputL.Count; j++)
            {
                res[currentInd] = inputL[j];
                allCombinations(currentInd + 1, inputL, inputN, res, countComb, input);
            }

        }


        //Function for POWERSET
        static void f(int currentInd, List<string> inputL, List<int> inputN, int[] isTaken)
        {
            if (currentInd >= inputL.Count)
            {
                string res = "";
                int elementsTaken = 0;
                for (var j = 0; j < isTaken.Length; j++)
                {
                    if (isTaken[j] == 1)
                    {
                        elementsTaken++;
                        res = res + inputL[j];
                    }
                }
                Console.WriteLine("Result: " + res + ". Elements taken: " + elementsTaken);
                if (res.Length >= 1 && res[res.Length - 1] == 'a')
                    Console.WriteLine("***********");
                return;
            }

            for (var j = 0; j < 2; j++) // < 2 -> because I set 2 times the cell with 0 and then  1
            {
                isTaken[currentInd] = j;
                f(currentInd + 1, inputL, inputN, isTaken);
            }
        }
    }
}
