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

        //cons print overridden by define print because it starts with a special
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
                //if cdr of cons node (everything after define) is another cons node
                // if (t.getCdr().isPair())
                // {
                //     //check if its t.cdr.car (item after define) is a cons node, if so print it, newline, print the rest
                //     if (t.getCdr().getCar().isPair())
                //     {
                //         // Console.WriteLine("\n;---- t.getCdr().getCar().isPair() --\n");                    
                //         Console.Write(' ');
                //         //n negative to print on same line
                //         Node.print(t.getCdr().getCar(), -(Math.Abs(n) + 4), false);
                //         Console.WriteLine();
                //         //n positive because printing on new line
                //         Node.printCdr(t.getCdr().getCdr(), Math.Abs(n) + 4);
                //     }
                //     //if its not a cons node print the whole thing and then newline after )
                //     else
                //     {
                //         //n negative to print items on same line with a space between
                //         Node.print(t.getCdr(), -(Math.Abs(n) + 4), true);
                //         Console.WriteLine();
                //     }
                // }
                // else
                // {
                //     // Console.WriteLine("\n;-- Define.print(p=true) --\n");                    
                //     //if not another cons node, dot or nil. negative n so that it wont indent or make a new line
                //     Node.printCdr(t.getCdr(), -(Math.Abs(n) + 4));
                //     Console.WriteLine();
                // }
   }

}
}



