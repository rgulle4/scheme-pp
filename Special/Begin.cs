// Begin -- Parse tree node strategy for printing the special form begin

using System;

namespace Tree
{
    public class Begin : Special
    {
	public Begin() { }

        public override void print(Node t, int n, bool p)
        {
            if (!p)
            {
                Node.indent(n);
                Console.WriteLine("(begin");
                Node.printCdr(t.getCdr(), Math.Abs(n) + 4);
            }
            else { Node.print(t, n, true); }
        }
    }
}

