/*This problem was asked by Google.

An XOR linked list is a more memory efficient doubly linked list. Instead of each node holding next and prev fields, it holds
a field named both, which is an XOR of the next node and the previous node. Implement an XOR linked list; it has an add(element)
which adds the element to the end, and a get(index) which returns the node at index.


If using a language that has no pointers (such as Python), you can assume you have access to get_pointer and dereference_pointer
functions that converts between nodes and memory addresses.
*/

using System;

namespace CodingQuestion5
{
    public unsafe class Program
    {
        public unsafe struct Node
        {
            public Node* both;
            public int val;
            //public int b;
        }

        public unsafe static void Main()
        {
            Console.WriteLine("Hello World!");

            Node* headP;

            //both = previous XOR next  => first node previous == 0 & last node next == 0

            //List creation
            Node firstNode = new Node();
            headP = &firstNode;
            headP->val = 11;

            Node secondNode = new Node();
            secondNode.val = 12;
            headP->both = &secondNode;

            Node thirdNode = new Node();
            thirdNode.val = 13;
            secondNode.both = (Node*)((ulong)headP ^ (ulong)&thirdNode); // headP XOR &thirdNode

            Node fourthNode = new Node();
            fourthNode.val = 14;
            thirdNode.both = (Node*)((ulong)&secondNode ^ (ulong)&fourthNode); 
            fourthNode.both = (Node*)((ulong)&thirdNode ^ ((ulong)0));

            Node newNode = new Node();
            newNode.val = 100;

            //test add
            addElement(&newNode, headP);
            
            //the new added element must be showe
            readList(headP);

            //test get
            Console.WriteLine("Result " + get(4, headP).val);
        }

        static void readList(Node* headP)
        {
            int flag = 1;
            int tmpIndexNode = 0;
            Node* tmpNodeP = headP;
            Node* previous = (Node*)((ulong)0);
            Node* next;

            while (flag == 1)
            {

                //increment tmpIndexNode
                //update tmpNodeP, previous and next
                next = (Node*)(((ulong)(tmpNodeP->both)) ^ (ulong)previous); // !both XOR !previous
                Console.WriteLine(tmpIndexNode + " Addresses: " + (ulong)previous + "  " + (ulong)tmpNodeP + "  " + (ulong)next);

                if (previous != (Node*)((ulong)0) && tmpNodeP->both != previous)
                    Console.WriteLine("Current, previous and next Node value: " + tmpNodeP->val + " | " + previous->val + " | " + next->val);
                else if (tmpNodeP->both == previous)  //last node, previous XOR 0 == previous
                {
                    Console.WriteLine("Current and previous Node value: " + tmpNodeP->val + " | " + previous->val + ". This is the last node!");
                    flag = 0;
                }
                else  //first node, 0 XOR next == next
                    Console.WriteLine("Current and next Node value: " + tmpNodeP->val + " | " + next->val);

                previous = tmpNodeP;
                tmpNodeP = next;
                tmpIndexNode++;
            }
        }

        static void addElement(Node* newNodeP, Node* headP) //add in the last position
        {
            int flag = 1;
            int tmpIndexNode = 0;
            Node* tmpNodeP = headP;
            Node* previous = (Node*)((ulong)0);
            Node* next;

            while(flag == 1)
            {
                //increment tmpIndexNode
                //update tmpNodeP, previous and next
                next = (Node*)(((ulong)(tmpNodeP->both)) ^ (ulong)previous); // !both XOR !previous
                
                if (tmpNodeP->both == previous)  //last node, previous XOR 0 == previous
                {
                    tmpNodeP->both = (Node*)((ulong)previous ^ (ulong)newNodeP);
                    newNodeP->both = (Node*)((ulong)tmpNodeP ^ (ulong)0);
                    //Console.WriteLine("We have to display: " + ((ulong)tmpNodeP ^ (ulong)0));
                    
                    flag = 0;
                }

                previous = tmpNodeP;
                tmpNodeP = next;
                tmpIndexNode++;
            }
        }

        static Node get(int index, Node* headP)
        {
            int flag = 1;
            int tmpIndexNode = 0;
            Node* tmpNodeP = headP;
            Node* previous = (Node*)((ulong)0);
            Node* next;
            Node result = new Node();

            while (flag == 1)
            {
                next = (Node*)(((ulong)(tmpNodeP->both)) ^ (ulong)previous); // !both XOR !previous

                if (tmpIndexNode == index || tmpNodeP->both == previous)
                {
                    result.val = tmpNodeP->val;
                    flag = 0;
                }

                previous = tmpNodeP;
                tmpNodeP = next;
                tmpIndexNode++;
            }

            return result;
        }
    }
}
