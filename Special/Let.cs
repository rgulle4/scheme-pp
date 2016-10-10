// Let -- Parse tree node strategy for printing the special form let

using System;

namespace Tree
{
    public class Let : Special
    {
	public Let() { }

        public override void print(Node t, int n, bool p)
        {
            if(!p)
            {
                Node.indent(n);
                Console.Write("(let");
                Node.printCdr(t.getCdr(), Math.Abs(n) + 4);
            }
            else { Node.print(t, n, true); }
        }
    }
}


