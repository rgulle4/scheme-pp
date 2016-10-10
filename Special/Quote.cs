// Quote -- Parse tree node strategy for printing the special form quote

using System;

namespace Tree
{
    public class Quote : Special
    {
	public Quote() { }

        public override void print(Node t, int n, bool p)
        {
            if(!p)
            {
                Node.indent(n);
                Console.Write('\'');
                Node.print(t.getCdr().getCar(), -(Math.Abs(n) + 1), false);
            }
            else { Node.print(t, n, true); }
        }
    }
}

