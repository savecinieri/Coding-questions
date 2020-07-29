using System;
using System.Net.Http.Headers;

namespace CodingQuestion12n50
{

    /*This problem was asked by Microsoft.

    Suppose an arithmetic expression is given as a binary tree.Each leaf is an integer and each internal node is one of '+', '−', '∗', or '/'.

    Given the root to such a tree, write a function to evaluate it*/


    // 

    public class Program
    {
        public class Node
        {

            public Node left;
            public Node right;
            public string val; 
        }

        static unsafe void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //  (1 + 2) * (4 + 5)

            Node firstNode = new Node();
            firstNode.val = "*";

            Node secondNode = new Node();
            secondNode.val = "+";

            Node thirdNode = new Node();
            thirdNode.val = "+";

            firstNode.left = secondNode;
            firstNode.right = thirdNode;



            Node fourthNode = new Node();
            fourthNode.left = null;
            fourthNode.right = null;
            fourthNode.val = "1";

            Node fifthNode = new Node();
            fifthNode.left = null;
            fifthNode.right = null;
            fifthNode.val = "2";

            secondNode.left = fourthNode;
            secondNode.right = fifthNode;



            Node sixthNode = new Node();
            sixthNode.left = null;
            sixthNode.right = null;
            sixthNode.val = "4";

            Node seventhNode = new Node();
            seventhNode.left = null;
            seventhNode.right = null;
            seventhNode.val = "5";

            thirdNode.left = sixthNode;
            thirdNode.right = seventhNode;


            string result = scanTree(firstNode);

            Console.WriteLine("Final result: " + result);
        }

        static string scanTree(Node nodePointer)
        {
            if (nodePointer.left == null && nodePointer.right == null)
            {
                return nodePointer.val;
            }

            string n1 = scanTree(nodePointer.left);
            string n2 = scanTree(nodePointer.right);

            int N1 = int.Parse(n1);
            int N2 = int.Parse(n2);
            int res = 0;

            switch (nodePointer.val)
            {
                case "*":
                    res = N1 * N2;
                    break;
                case "-":
                    res = N1 - N2;
                    break;
                case "+":
                    res = N1 + N2;
                    break;
                case "/":
                    res = N1 / N2;
                    break;
            }

            return res.ToString();
            
        }
    }
}
