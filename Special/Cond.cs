// Cond -- Parse tree node strategy for printing the special form cond

using System;

namespace Tree
{
    public class Cond : Special
    {
	public Cond() { }

        public override void print(Node t, int n, bool p)
        { 
            if(!p)
            {
                Node.indent(n);
                Console.WriteLine("(cond"); 
                Node.printCdr(t.getCdr(), Math.Abs(n) + 4);
            }
            else { Node.print(t, n, true); }   
        }
    }
}


