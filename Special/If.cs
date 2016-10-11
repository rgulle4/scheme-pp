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
               // else
               // {
               //  Console.Write("HITTING ELSE");
               //  Node.indent(n);
               //  Console.Write("(");
               //  Node.print(t.getCar(), n, false);
               //  t = t.getCdr();
               //  Console.WriteLine();
               //  while(t.getCar() != null)
               //  {
               //      Node.print(t.getCar(), n, false);
               //      t = t.getCdr();
               //      if(t.getCar() != null) { Console.Write(" "); }
               //  }
                
               //  Console.WriteLine(')');
               // }
           }
        }
        else
        {
            Node.print(t, n, true);
        }
       }
    }
}

