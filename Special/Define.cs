// Define -- Parse tree node strategy for printing the special form define

using System;

namespace Tree
{
    // ;; Two ways to print define:
    // ;; SINGLE LINE WHEN DEFINING A VARIABLE
    //
    // (define x 3)
    //
    // ;; BREAK THE LINE AND INDENT WHEN DEFINING FUNCTION
    //
    // (define (foo n)
    //     (define x 3)
    //     (* x (foo (- n 1)))
    // )
    //
    public class Define : Special
    {
        // TODO: Add any fields needed.

        // TODO: Add an appropriate constructor.
       public Define() { }

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
                   Node.print(t.getCar(), n, false);
                   Console.Write(" ");
                   t = t.getCdr();
                   Node.print(t.getCar(), -(Math.Abs(n)), false);
                   t = t.getCdr();
                   while(t.getCdr() != null)
                   {
                       Node.print(t.getCar(), n+4, false);
                       t = t.getCdr();
                   }
                   Console.WriteLine(')');
               }
               else
               {
                Node.indent(n);
                Console.Write("(");
                while(t.getCar() != null)
                {
                    Node.print(t.getCar(), n, false);
                    t = t.getCdr();
                    if(t.getCar() != null) { Console.Write(" "); }
                }
                Console.WriteLine(')');
               }
           }


       }
   }

}
}



