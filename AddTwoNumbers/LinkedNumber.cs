using System;
using System.Text;

namespace AddTwoNumbers
{
    public class LinkedNumber : IEquatable<LinkedNumber>
    {
        private readonly NumberNode? _head;

        public LinkedNumber(params int[] inputNumbers)
        {
            var arraySegment = new ArraySegment<int>(inputNumbers);
            
            using var enumerator = arraySegment.GetEnumerator();

            _head = NumberNode.GetNextNode(enumerator);
        }

        private LinkedNumber(NumberNode? head)
        {
            _head = head;
        }
        
        public static LinkedNumber operator +(LinkedNumber a, LinkedNumber b)
        {
            var resultHead = NumberNode.Sum(a._head, b._head);

            return new LinkedNumber(resultHead);
        }
        
        public override string ToString()
        {
            if (_head == null) return "[]";
            
            var builder = new StringBuilder($"[{_head.Value}");
            var node = _head;

            while (node.Next != null)
            {
                node = node.Next;

                builder.Append($", {node.Value}");
            }

            builder.Append("]");

            return builder.ToString();
        }

        public bool Equals(LinkedNumber? other)
        {
            if (ReferenceEquals(null, other)) return false;
            
            return ReferenceEquals(this, other) || Equals(_head, other._head);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            
            return obj.GetType() == GetType() && Equals((LinkedNumber)obj);
        }

        public override int GetHashCode()
        {
            return _head != null ? _head.GetHashCode() : 0;
        }
    }
}