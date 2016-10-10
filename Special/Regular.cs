// Regular -- Parse tree node strategy for printing regular lists

using System;

namespace Tree
{
    public class Regular : Special
    {
        public Regular() { }

        public override void print(Node t, int n, bool p)
        {
            if(!p)
            {
                Node.indent(n);
                Console.Write('(');
                while(t.getCar() != null)
                {
                    Node.print(t.getCar(), n, false);
                    t = t.getCdr();
                    if(t.getCar() != null) {Console.Write(' ');}
                }
                Console.Write(')');
            }
            else
            {
                if (n < 0) { Console.Write(' '); }
                Node.print(t.getCar(), n, false);
            }
        }
    }
}


