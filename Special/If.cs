// If -- Parse tree node strategy for printing the special form if

using System;

namespace Tree
{
    public class If : Special
    {
	public If() { }

        public override void print(Node t, int n, bool p)
        {
            if(!p)
            {
                Node.indent(n);
                Console.Write("(if");
                if(t.getCdr().isPair())
                {
                    Console.Write(" ");
                    Node.print(t.getCdr().getCar(), -(Math.Abs(n) + 4), false);
                    Console.WriteLine();
                    Node.printCdr(t.getCdr().getCdr(), Math.Abs(n) + 4);
                }
                else
                {
                    Node.printCdr(t.getCdr(), -(Math.Abs(n) + 4));
                    Console.WriteLine();
                }
            }
            else { Node.print(t, n, true); }
        }
    }
}

