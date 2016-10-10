// Set -- Parse tree node strategy for printing the special form set!

using System;

namespace Tree
{
    public class Set : Special
    {
	public Set() { }
	
        public override void print(Node t, int n, bool p)
        { 
            if(!p)
            {
                Node.indent(n);
                Console.Write("(set!"); 
                Node.printCdr(t.getCdr(), -(Math.Abs(n) + 4));
                Console.WriteLine();
            }
            else { Node.print(t, n, true); }   
        }
    }
}

