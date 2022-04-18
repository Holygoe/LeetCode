namespace Kth_Smallest_Element_in_a_BST;

public class Solution
{
    public int KthSmallest(TreeNode root, int k)
    {
        var threshold = int.MinValue;

        while (k > 0)
        {
            k--;
            TryGetSmallest(root, threshold, int.MaxValue, out var result);
            threshold = result;
        }
        
        return threshold;
    }

    bool TryGetSmallest(TreeNode? node, int threshold, int current, out int result)
    {
        result = current;
        
        if (node == null)
        {
            return false;
        }

        var isVal = node.val > threshold;
        
        if (node.val < result && isVal)
        {
            result = node.val;
        }
        
        if (!TryGetSmallest(node.left, threshold, current, out var left))
        {
            node.left = null;
        }
        else if (left < result)
        {
            result = left;
        }

        if (!TryGetSmallest(node.right, threshold, current, out var right))
        {
            node.right = null;
        }
        else if (right < result)
        {
            result = right;
        }

        return isVal || node.left != null || node.right != null;
    }
}