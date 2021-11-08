using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace LeetCodeLibrary
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "FieldCanBeMadeReadOnly.Global")]
    public class TreeNode
    {
        public int val;
        public TreeNode? left;
        public TreeNode? right;

        public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }

        public static TreeNode? GetTree(params int?[] values)
        {
            var firstValue = values[0];
            
            if (firstValue == null) return null;
            
            var head = new TreeNode(firstValue.Value);
            var nodes = new Queue<TreeNode>();
            nodes.Enqueue(head);

            var valueIndex = 1;

            while (nodes.Count > 0)
            {
                var node = nodes.Dequeue();

                if (valueIndex >= values.Length)
                {
                    node.left = null;
                }
                else
                {
                    var value = values[valueIndex];

                    node.left = value is null ? null : new TreeNode(value.Value);
                }

                valueIndex++;

                if (node.left != null)
                {
                    nodes.Enqueue(node.left);
                }
                    
                if (valueIndex >= values.Length)
                {
                    node.right = null;
                }
                else
                {
                    var value = values[valueIndex];

                    node.right = value is null ? null : new TreeNode(value.Value);
                }

                valueIndex++;
                    
                if (node.right != null)
                {
                    nodes.Enqueue(node.right);
                }
            }

            return head;
        }

        public int GetNodeCount()
        {
            var leftCount = left?.GetNodeCount() ?? 1;
            var rightCount = right?.GetNodeCount() ?? 1;

            return 1 + leftCount + rightCount;
        }

        public override string ToString()
        {
            var nodes = new List<TreeNode?>(GetNodeCount()) { this };
            int genFirst = 0, genSize = 1;

            while (genSize > 0)
            {
                var nextGenSize = 0;
                var genLast = genFirst + genSize;
                
                for (var i = genFirst; i < genLast; i++)
                {
                    var node = nodes[i];

                    if (node == null) continue;

                    nodes.Add(node.left);
                    nodes.Add(node.right);

                    nextGenSize += 2;
                }

                genFirst = genLast;
                genSize = nextGenSize;
            }

            var builder = new StringBuilder($"[{nodes[0]!.val}");
            
            for (var i = nodes.Count - 1; i >= 0; i--)
            {
                if (nodes[i] == null)
                {
                    nodes.RemoveAt(i);
                }
                else
                {
                    break;
                }
            }
            
            for (var i = 1; i < nodes.Count; i++)
            {
                var node = nodes[i];
                
                var str = node?.val.ToString() ?? "null";
                
                builder.Append($", {str}");
            }

            builder.Append("]");
            
            return builder.ToString();
        }
    }
}