using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace AddTwoNumbers
{
    public class NumberNode : IEquatable<NumberNode>
    {
        public readonly int Value;

        public readonly NumberNode? Next;

        private NumberNode(int value, NumberNode? next)
        {
            Value = value;
            Next = next;
        }

        public static NumberNode? GetNextNode(IEnumerator<int> enumerator)
        {
            if (!enumerator.MoveNext()) return null;

            var value = enumerator.Current;
                
            Contract.Assert(value >= 0 && value <= 9, "The input numbers must be within [0..9].");
                
            var nextNode = GetNextNode(enumerator);

            if (nextNode == null && value == 0) return null;

            return new NumberNode(value, nextNode);
        }

        public static NumberNode? Sum(NumberNode? aNode, NumberNode? bNode, int carry = 0)
        {
            if (aNode == null && bNode == null)
            {
                return carry == 0 ? null : new NumberNode(carry, null);
            }

            var a = aNode?.Value ?? 0;
            var b = bNode?.Value ?? 0;
            var sum = a + b + carry;
            var value = sum % 10;
            var nextNode = Sum(aNode?.Next, bNode?.Next, sum / 10);

            return new NumberNode(value, nextNode);
        }
        
        public bool Equals(NumberNode? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            
            return Value == other.Value && Equals(Next, other.Next);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            
            return obj.GetType() == GetType() && Equals((NumberNode)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value, Next);
        }
    }
}