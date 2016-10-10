// Define -- Parse tree node strategy for printing the special form define

using System;

namespace Tree
{
    public class Define : Special
    {
	public Define() { }

        public override void print(Node t, int n, bool p)
        {
            if(!p)
            {
                Node.indent(n);
                Console.Write("(define");
                if(t.getCdr().isPair())
                {
                    if(t.getCdr().getCar().isPair())
                    {
                        Console.Write(' ');
                        Node.print(t.getCdr().getCar(), -(Math.Abs(n) + 4), false);
                        Console.WriteLine();
                        Node.printCdr(t.getCdr().getCdr(), Math.Abs(n) + 4);
                    }
                    else
                    {
                        Node.print(t.getCdr(), -(Math.Abs(n) + 4), true);
                        Console.WriteLine();
                    }
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


