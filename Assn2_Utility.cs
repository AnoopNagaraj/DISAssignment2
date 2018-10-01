using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Assignment_2;

namespace Assn2
{
    class Assn2_Utility
    {
        public static StockNode ReverseList(StockNode n)
        {

            StockNode head = n;
            StockNode current = n;
            StockNode firstNodeBeforeReverse = n;  // keep track of origional FirstNode

            while (true)
            {
                StockNode temp = current;
                // keep track of currentHead in LinkedList "n", for continued access to unprocessed List

                if (current.Next != null) { current = current.Next; }
                temp.Next = head;
                // keep track of head of Reversed List that will be returned post processing
                head = temp;

                if (current != null)
                {
                    if (current.Next == null)
                    {

                        temp = current;
                        current.Next = head;
                        head = temp;
                        // Set the original FirstNode to NULL
                        firstNodeBeforeReverse.Next = null;

                        break;
                    }
                }
            }
            return head;
        }


        //The main function
        public static StockNode MergeSort(StockNode head)
        {
            if (head == null || head.Next == null)
            {
                return head;
            }
            StockNode middle = GetMiddleElement(head);      //get the middle of the list
            StockNode sHalf = middle.Next;
            middle.Next = null;   //split the list into two halfs

            return Merge(MergeSort(head), MergeSort(sHalf));  //recurse on that
        }

        //Merge subroutine to merge two sorted lists
        public static StockNode Merge(StockNode a, StockNode b)
        {
            StockNode dummyHead, curr;
            dummyHead = new StockNode();
            curr = dummyHead;
            while (a != null && b != null)
            {
                if (a.StockHolding.Holdings <= b.StockHolding.Holdings)
                {
                    curr.Next = a;
                    a = a.Next;
                }
                else
                {
                    curr.Next = b;
                    b = b.Next;
                }
                curr = curr.Next;
            }
            curr.Next = (a == null) ? b : a;
            return dummyHead.Next;
        }

        //Finding the middle element of the list for splitting
        public static StockNode GetMiddleElement(StockNode head)
        {
            if (head == null)
            {
                return head;
            }
            StockNode slowNode, fastNode;
            slowNode = fastNode = head;
            while (fastNode.Next != null && fastNode.Next.Next != null)
            {
                slowNode = slowNode.Next; fastNode = fastNode.Next.Next;
            }
            return slowNode;
        }

        public static bool Compare(object object1, object object2)
        {
            if (object1 == null || object2 == null)
            {
                return false;
            }
            if (!object1.GetType().Equals(object2.GetType()))
            {
                return false;
            }

            Type type = object1.GetType();
            if (type.IsPrimitive || typeof(string).Equals(type))
            {
                return object1.Equals(object2);
            }
            if (type.IsArray)
            {
                Array first = object1 as Array;
                Array second = object2 as Array;
                var en = first.GetEnumerator();
                int i = 0;
                while (en.MoveNext())
                {
                    if (!Compare(en.Current, second.GetValue(i)))
                        return false;
                    i++;
                }
            }
            else
            {
                foreach (PropertyInfo propInfo in type.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public))
                {
                    var val = propInfo.GetValue(object1);
                    var tval = propInfo.GetValue(object2);
                    if (!Compare(val, tval))
                        return false;
                }
                foreach (FieldInfo fi in type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public))
                {
                    var val = fi.GetValue(object1);
                    var tval = fi.GetValue(object2);
                    if (!Compare(val, tval))
                        return false;
                }
            }
            return true;
        }

    }
}
