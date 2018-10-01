using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Assn2;

namespace Assignment_2
{
    public partial class StockList
    {
        //param        : NA
        //summary      : Calculate the value of each node by multiplying holdings with price, and returns the total value
        //return       : total value
        //return type  : decimal
        public decimal Value()
        {
            decimal value = 0.0m;
            if (this.head != null)
            {
                var current = this.head;
                while (current.Next != null)
                {
                    value += current.StockHolding.CurrentPrice * current.StockHolding.Holdings;
                    current = current.Next;
                }
                value += current.StockHolding.CurrentPrice * current.StockHolding.Holdings;
            }
            // write your implementation here

            return value;
        }

        //param  (StockList) listToCompare     : StockList which has to comared for similarity index
        //summary      : finds the similar number of nodes between two lists
        //return       : similarty index
        //return type  : int
        public int Similarity(StockList listToCompare)
        {
            int similarityIndex = 0;

            var firstCurrent = this.head;
            var tempFirst = firstCurrent;
            var secondCurrent = listToCompare.head;
            var tempSecond = secondCurrent;

            while (firstCurrent != null)
            {
                while (secondCurrent != null)
                {
                    if (Assn2_Utility.Compare(secondCurrent.StockHolding, firstCurrent.StockHolding))
                    {
                        similarityIndex += 1;
                    }

                    secondCurrent = secondCurrent.Next;
                }

                firstCurrent = firstCurrent.Next;
                secondCurrent = tempSecond;
            }


            return similarityIndex;
        }

        //param        : NA
        //summary      : Print all the nodes present in the list
        //return       : NA
        //return type  : NA
        public void Print()
        {
            Console.WriteLine("Printing all node present in the list:");
            if (this.head != null)
            {
                var currentNode = this.head;
                while (currentNode.Next != null)
                {
                    Console.WriteLine(currentNode.StockHolding);
                    currentNode = currentNode.Next;
                }
                Console.WriteLine(currentNode.StockHolding);
            }
            else
            {
                Console.WriteLine("No nodes present in this list");
            }

            Console.WriteLine("\n");
        }
    }
}