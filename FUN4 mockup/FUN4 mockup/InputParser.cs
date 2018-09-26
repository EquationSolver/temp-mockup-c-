using FUN4_mockup.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FUN4_mockup
{
    class InputParser
    {
        string input = "";
        Node equation;
        Node top;
        Regex numbers = new Regex("[0-9]");
        Regex letters = new Regex("[A-z]");

        public Node parseInput(string input)
        {
            this.input = input.Replace(" ", string.Empty);
            fixInput();
            if (input[0] == '(')
            {
                InputParser p = new InputParser();
                top = new ParenthesesNode();
                top.AddChild(p.parseInput(input.Substring(1)));
                input = p.input;
            }
            else
            {
                top = new ConstantNode(input[0].ToString());
            }
            this.input = this.input.Substring(1);

            parseStringPartNode(top, top);
            return equation;
        }

        private void fixInput()
        {
            Regex bracketOpen = new Regex(@"[0-9A-z]\(");
            Regex bracketClose = new Regex(@"\)[0-9A-z]");
            Regex numberVar = new Regex("[0-9][A-z]");
            input = input.Replace(")(", ")*(");
            while (bracketOpen.IsMatch(input))
            {
                int index = bracketOpen.Match(input).Index + 1;
                input = input.Substring(0, index) + "*" + input.Substring(index);
            }
            while (bracketClose.IsMatch(input))
            {
                int index = bracketClose.Match(input).Index + 1;
                input = input.Substring(0, index) + "*" + input.Substring(index);
            }
            while (numberVar.IsMatch(input))
            {
                int index = numberVar.Match(input).Index + 1;
                input = input.Substring(0, index) + "*" + input.Substring(index);
            }
        }

        private void parseStringPartNode(Node child, Node parent)
        {
            Node current = null;
            if (input.Length == 0)
                return;
            try
            {
                switch (input[0])
                {
                    case '+':
                        current = new PlusNode();
                        current.AddChild(top);
                        input = input.Substring(1);
                        top = current;
                        parseStringPartNode(child, current);
                        break;
                    case '-':
                        current = new MinNode();
                        current.AddChild(top);
                        input = input.Substring(1);
                        top = current;
                        parseStringPartNode(child, current);
                        break;
                    case '*':
                        current = new MultiplicationNode();
                        current.AddChild(child);
                        input = input.Substring(1);
                        parent.OverrideChild(child, current);
                        if (top is ConstantNode)
                            top = current;
                        parseStringPartNode(child, current);
                        break;
                    case '/':
                        current = new DivisionNode();
                        current.AddChild(child);
                        input = input.Substring(1);
                        parent.OverrideChild(child, current);
                        if (top is ConstantNode)
                            top = current;
                        parseStringPartNode(child, current);
                        break;
                    case '=':
                        current = new EqualsNode();
                        current.AddChild(top);
                        input = input.Substring(1);
                        equation = current;
                        parseStringPartNode(child, current);
                        break;
                    case '(':
                        current = new ParenthesesNode();
                        InputParser p = new InputParser();
                        current.AddChild(p.parseInput(input.Substring(1)));
                        input = p.input;
                        parent.AddChild(current);
                        parseStringPartNode(current, parent);
                        break;
                    case ')':
                        input = input.Substring(1);
                        equation = top;
                        break;
                    default:
                        if (letters.IsMatch(input[0].ToString()))
                        {
                            current = new VariableNode(input[0]);
                            parent.AddChild(current);
                            input = input.Substring(1);
                            parseStringPartNode(current, parent);
                            break;
                        }
                        if (numbers.IsMatch(input[0].ToString()))
                        {
                            string value = "" + input[0];
                            input = input.Substring(1);
                            while (!String.IsNullOrWhiteSpace(input) && numbers.IsMatch(input[0].ToString()))
                            {
                                value += input[0];
                                input = input.Substring(1);
                            }

                            current = new ConstantNode(value);
                            parent.AddChild(current);
                            parseStringPartNode(current, parent);
                            break;
                        }
                        throw new NotImplementedException("INVALID INPUT");
                        break;
                }
            }
            finally { }
        }
    }
}
