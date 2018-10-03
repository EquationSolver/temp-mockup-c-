using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUN4_mockup.Nodes
{
    class DivisionNode : Node
    {
        public DivisionNode()
        {
            this.value = '/';
        }

        /*public override Node Calculate()
        {
            firstChild.Calculate();
            secondChild.Calculate();
            if (secondChild.isVariable())
                return secondChild.Divide(firstChild);
            return firstChild.Divide(secondChild);
        }*/
    }
}
