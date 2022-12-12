const int size = 6;

var head = new ListNode(1);
var node = head;

for (var i = 2; i <= size; i++)
{
    node.next = new ListNode(i);
    node = node.next;
}

new Solution().ReverseKGroup(head, 3);

public class ListNode 
{
    public int val;
    public ListNode? next;
    public ListNode(int val=0, ListNode next=null) 
    {
        this.val = val;
        this.next = next;
    }
}

public class Solution
{
    public ListNode ReverseKGroup(ListNode head, int k)
    {
        if (k <= 1)
        {
            return head;
        }
        
        var endChain = GetNodeByIndex(head, k);
        var newHead = endChain ?? head;
        
        while(endChain is not null)
        {
            var lastHead = head;
            var next = head.next!;
            head.next = endChain.next;
            
            for (var i = 1; i < k; i++)
            {
                var afterNext = next.next;
                next.next = head;
                head = next;
                next = afterNext!;
            }

            head = next;
            endChain = GetNodeByIndex(head, k);
            lastHead.next = endChain ?? head;
        }
        
        return newHead;
    }
    
    public ListNode? GetNodeByIndex(ListNode? head, int number)
    {
        for (var i = 1; i < number; i++)
        {
            if (head is null)
            {
                return null;
            }
            
            head = head.next;
        }
        
        return head;
    }
}