using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUN4_mockup.Nodes
{
    class ParenthesesNode : Node
    {
        public ParenthesesNode()
        {
            this.value = '(';
        }

        public override string Print()
        {
            return "(" + firstChild.Print() + ")";
        }
    }
}
