using System;
using System.Collections.Generic;

namespace CodingQuestion142
{

    /*
     * This problem was asked by Google.

        You're given a string consisting solely of (, ), and *. * can represent either a (, ), or an empty string. Determine whether the parentheses are balanced.

        For example, (()* and (*) are balanced. )*( is not balanced
     */

    unsafe class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string inputStr = "(*))";

            checkIfBalanced(inputStr);
        }

        static void checkIfBalanced(string inputString)
        {
            int tmpInd = 0, countToWrite = 0, countToLeft = 0, indexAshtag = 0 ;
            bool balanced = true;


            //count parentheses
            foreach(char tmpChar in inputString)
            {
                if (tmpInd == 0 && tmpChar == ')')
                {
                    //the first parentheses will never be closed
                    balanced = false;
                    break;
                }

                if (tmpChar == '*')
                {
                    indexAshtag = tmpInd;
                }

                tmpInd += 1;
            }

            if (balanced == false)
            {
                Console.WriteLine("Parentheses balanced: ", balanced, ". Preliminary test not passed");
                return;
            }

            Console.WriteLine("* at index {0}. Input string is {1}.", indexAshtag, inputString);

            //

 
            bool taskFinished = false;
            List<char> optionsChar = new List<char>();
            optionsChar.Add('(');
            optionsChar.Add(')');
            //optionsChar.Add('');
            int currentChar = 0;
            while (taskFinished == false && currentChar < 3)
            {
                string currentString = "***";
                if (currentChar < 2)
                {
                    Console.WriteLine("Current char for replacing is {0}", optionsChar[currentChar]);
                    currentString = inputString.Replace('*', optionsChar[currentChar]);
                }
                else
                {
                    Console.WriteLine("Current char for replacing is space");
                    if (indexAshtag != 0 && indexAshtag != inputString.Length - 1)
                        currentString = inputString.Substring(0, indexAshtag) + inputString.Substring(indexAshtag + 1, (inputString.Length - 1) - indexAshtag);
                    else if (indexAshtag == 0)
                    {
                        currentString = inputString.Substring(1, inputString.Length - 1);
                    }
                    else if (indexAshtag == inputString.Length - 1)
                    {
                        currentString = inputString.Substring(0, inputString.Length - 1);
                    }
                }
                Console.WriteLine("The current string is \"{0}\"", currentString);


                /*analyze currentString, I need to use countToWrite and CountToLeft*/
                int writePar = 0, leftPar = 0;
                countPar(&writePar, &leftPar, currentString);
                Console.WriteLine("There are {0} and {1}", writePar, leftPar);

                taskFinished = finalCheckBalanced(writePar, leftPar, currentString);

                currentChar++;
            }
            if (taskFinished == true)
                Console.WriteLine("Balanced");
            else
                Console.WriteLine("NOT Balanced");
        }

        static void countPar(int* w, int* l, string cS)
        {
            foreach (char tmpChar in cS)
            {
                if (tmpChar == '(')
                    (*w)++;
                else 
                    (*l)++;
            }
        }

        static bool finalCheckBalanced(int w, int l, string cS)
        {
            bool result = true;
            int offset = 1;
            string tmpString = String.Copy(cS);

            for (int i = tmpString.Length - 1; i >= 0; i--)
            {
                //check if the character is (
                if (tmpString[i] == '(')
                {
                    if ((i + 1) >= tmpString.Length) //the last character is ( and so it is not closed
                    {
                        result = false;
                        break;
                    }
                    else if ((i + 1) < tmpString.Length)
                    {
                        if (tmpString[i + 1] != ')')
                        {
                            result = false;
                            break;
                        }
                        else if (tmpString[i + 1] == ')')
                        {
                            //check if i + 2 is accepted
                            if ((i + 2) < tmpString.Length)
                            {
                                //Console.WriteLine("-> {0} {1} {2}", tmpString.Substring(i + 2, (tmpString.Length - 1) - (i + 2)), i + 2, tmpString.Length - (i + 2));
                                tmpString = tmpString.Substring(0, i) + tmpString.Substring(i + 2, tmpString.Length - (i + 2));
                            }
                            else
                                tmpString = tmpString.Substring(0, i);
                            Console.WriteLine("Reduced string is \"{0}\"", tmpString);
                        }

                    }
                }
            }

            return result;
        }
    }
}
