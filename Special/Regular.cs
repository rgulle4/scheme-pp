// Regular -- Parse tree node strategy for printing regular lists

using System;

namespace Tree
{
    public class Regular : Special
    {
        public Regular() { }

        public override void print(Node t, int n, bool p)
        {
            if(!p && n>=0)
            {
                Node.indent(n);
                Console.Write('(');
                while(t.getCar() != null)
                {
                    Node.print(t.getCar(), -(1 + Math.Abs(n)), false);
                    t = t.getCdr();
                    if(t.getCar() != null) {Console.Write(' ');}
                }
                Console.Write(')');
                Console.WriteLine();
            }
            else if(!p && n<0)
            {
                n = n-1;
                Node.indent(n);
                Console.Write('(');
                while(t.getCar() != null)
                {
                    Node.print(t.getCar(), n-1, false);
                    t = t.getCdr();
                    if(t.getCar() != null) {Console.Write(' ');}
                }
                Console.Write(')');
            }
        }
    }
}


