using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUN4_mockup.Nodes
{
    class MultiplicationNode : Node
    {
        public MultiplicationNode()
        {
            this.value = '*';
        }

        public override Node Calculate()
        {
            firstChild = firstChild.Calculate();
            secondChild = secondChild.Calculate();
            if (secondChild.isVariable())
                return secondChild.Multiply(firstChild);
            return firstChild.Multiply(secondChild);
        }
    }
}
