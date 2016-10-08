// Cond -- Parse tree node strategy for printing the special form cond

using System;

namespace Tree
{
    public class Cond : Special
    {

	public Cond() { }

        public override void print(Node t, int n, bool p)
        { 
            Node car = t.getCar(); 
            Node cdr = t.getCdr();

            t.indent(n);

            if (!p) {
                Console.Write("(");
            }

            car.print(n, true);
            Console.WriteLine();

            n++;

            while(!cdr.isNull()) 
            {
                t.indent(n);
                cdr.getCar().print(0, false); //If left paren has not been printed
                Console.WriteLine();
                cdr = cdr.getCdr();
            }
            n--;
            cdr.print(n, true);
            Console.WriteLine();
        }
    }
}


