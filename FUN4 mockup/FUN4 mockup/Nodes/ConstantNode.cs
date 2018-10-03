using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUN4_mockup.Nodes
{
    class ConstantNode : Node
    {

        public ConstantNode(string value)
        {
            this.fullValue = value;
        }

        public override string Value => fullValue;

        public override string Print()
        {
            return Value;
        }

        public override Node Multiply(Node firstChild)
        {
            fullValue = (int.Parse(fullValue) * int.Parse(firstChild.Value)).ToString();
            return this;
        }

        public override Node Calculate()
        {
            return this;
        }
    }
}
