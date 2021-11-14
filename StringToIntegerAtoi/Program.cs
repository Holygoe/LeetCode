using System;

namespace StringToIntegerAtoi
{
    internal static class Program
    {
        private static void Main()
        {
            Console.WriteLine("Hello World!");
        }
        
        public static ListNode MergeKLists(ListNode[] lists)
        {
            ListNode head = null;
            ListNode current = null;
            ListNode next;

            do
            {
                next = null;
            
                for (var i = 0; i < lists.Length; i++)
                {
                    if (lists[i] == null) continue;
                
                    if (next == null || next.val < lists[i].val)
                    {
                        next = lists[i];
                    }
                }
            
                if (current == null)
                {
                    head = next;
                }
                else
                {
                    current.next = next;
                }
            
                current = next;
            }
            while (next != null);
        
            return head;
        }
        
        public class ListNode
        {
            public int val;

            public ListNode next;
        }
    }
}