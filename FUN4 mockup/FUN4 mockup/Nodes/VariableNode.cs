using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUN4_mockup.Nodes
{
    class VariableNode : Node
    {
        public VariableNode(char value)
        {
            this.value = value;
            this.fullValue = "1";
        }

        public VariableNode(char value, string fullValue)
        {
            this.value = value;
            this.fullValue = fullValue;
        }

        public override string Value => fullValue + value;

        public override string Print()
        {
            return Value;
        }

        public override bool isVariable()
        {
            return true;
        }

        public override Node Multiply(Node firstChild)
        {
            if (firstChild.isVariable())
                fullValue = (int.Parse(fullValue) * int.Parse(firstChild.Value.Remove(firstChild.Value.Length-1))).ToString();
            else
                fullValue = (int.Parse(fullValue) * int.Parse(firstChild.Value)).ToString();
            return this;
        }

        public override Node Calculate()
        {
            return this;
        }
    }
}
