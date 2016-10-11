// Lambda -- Parse tree node strategy for printing the special form lambda

using System;

namespace Tree
{
    public class Lambda : Special
    {
        // TODO: Add any fields needed.

        // TODO: Add an appropriate constructor.
	public Lambda() { }

        public override void print(Node t, int n, bool p)
        {
            if(t.getCdr().isPair())
            {
                if(t.getCdr().getCar().isPair())
                {
                   Node.indent(n);
                   Console.Write('(');
                   Node.print(t.getCar(), n - 4, false);
                   Console.Write(" ");
                   t = t.getCdr();
                   if(n > 0) { Node.print(t.getCar(), n - 4, false); }
                   else { Node.print(t.getCar(), n, false); }
                   Console.WriteLine();
                   t = t.getCdr();
                   while(t.getCdr() != null)
                   {
                       Node.print(t.getCar(), n+4, false);
                       t = t.getCdr();
                       if(t.getCdr() != null) {Console.WriteLine();}
                   }
                   Node.indent(n);
                   Console.WriteLine(')');
               }
           }
        }
    }
}

