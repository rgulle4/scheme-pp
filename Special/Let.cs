// Let -- Parse tree node strategy for printing the special form let

using System;

namespace Tree
{
    public class Let : Special
    {
	public Let() { }

        public override void print(Node t, int n, bool p)
        {
            if (!p && n >= 0 )
            {
                Node.indent(n);
                Console.Write("(");
                Node.print(t.getCar(), n - 4, false);
                Console.WriteLine();
                t = t.getCdr();
                while(t.getCar() != null)
                {
                    Node.print(t.getCar(), n + 4, false);
                    t = t.getCdr();
                }
                Node.indent(n);
                Console.WriteLine(')');

            }
            else { Node.print(t, n, true); }
        }
    }
}


