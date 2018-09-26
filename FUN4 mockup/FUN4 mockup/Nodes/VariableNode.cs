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
    }
}
