// Begin -- Parse tree node strategy for printing the special form begin

using System;

namespace Tree
{
    public class Begin : Special
    {
	public Begin() { }

        public override void print(Node t, int n, bool p)
        {
            if (!p && n >= 0 )
            {
                Node.indent(n);
                Console.Write("(");
                Node.print(t.getCar(), n, false);
                Console.WriteLine();
                t = t.getCdr();
                while(t.getCar() != null)
                {
                    Node.print(t.getCar(), n + 4, false);
                    t = t.getCdr();
                }
                
                Console.WriteLine(')');

            }
            else { Node.print(t, n, true); }
        }
    }
}
