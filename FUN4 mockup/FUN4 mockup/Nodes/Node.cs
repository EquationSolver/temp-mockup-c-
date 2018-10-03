using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUN4_mockup.Nodes
{
    class Node
    {
        protected char value;
        public virtual string Value { get => value.ToString(); }
        protected string fullValue;
        protected Node firstChild;
        protected Node secondChild;

        public void AddChild(Node node)
        {
            if (firstChild == null)
                firstChild = node;
            else if (secondChild == null)
                secondChild = node;
        }

        public virtual Node Multiply(Node firstChild)
        {
            throw new NotImplementedException();
        }

        public virtual bool isVariable()
        {
            return false;
        }

        public virtual Node Calculate()
        {
            firstChild = firstChild.Calculate();
            secondChild = secondChild.Calculate();
            return this;
        }

        public void OverrideChild(Node child, Node node)
        {
            if (firstChild == child)
                firstChild = node;
            else if (secondChild == child)
                secondChild = node;
        }

        public bool isFull()
        {
            return firstChild != null && secondChild != null;
        }

        public override string ToString()
        {
            return Value;
        }

        public virtual string Print()
        {
            return firstChild.Print() + Value + secondChild.Print();
        }
    }
}
