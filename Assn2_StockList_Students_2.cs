using System;
using System.Collections.Generic;
using System.Text;


namespace Assignment_2
{
    public partial class StockList
    {
        //param   (StockList)listToMerge : second list to be merged 
        //summary      : merge two different list into a single result list
        //return       : merged list
        //return type  : StockList
        public StockList MergeList(StockList listToMerge)
        {
            StockList resultList = new StockList();

            // write your implementation here

            return resultList;
        }

        //param        : NA
        //summary      : finds the stock with most number of holdings
        //return       : stock with most shares
        //return type  : Stock
        public Stock MostShares()
        {
            Stock mostShareStock = null;
            decimal curMaxHolding = 0;

            if (this.head != null)
            {
                var current = this.head;

                while (current.Next != null)
                {
                    if (current.StockHolding.Holdings > curMaxHolding)
                    {
                        curMaxHolding = current.StockHolding.Holdings;
                        mostShareStock = current.StockHolding;
                    }

                    current = current.Next;
                }

                if (current.StockHolding.Holdings > curMaxHolding)
                {

                    mostShareStock = current.StockHolding;
                }

            }

            // write your implementation here

            return mostShareStock;
        }

        //param        : NA
        //summary      : finds the number of nodes present in the list
        //return       : length of list
        //return type  : int
        public int Length()
        {
            int length = 0;

            // write your implementation here
            StockNode current = this.head;
            if (current == null)
            {
                return length;
            }
            length += 1;
            while (current.Next != null)
            {
                length += 1;
                current = current.Next;
            }
            return length;
        }
    }
}