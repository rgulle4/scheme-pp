// Define -- Parse tree node strategy for printing the special form define

using System;

namespace Tree
{
    public class Define : Special
    {
        // TODO: Add any fields needed.

        // TODO: Add an appropriate constructor.
	public Define() { }

        public override void print(Node t, int n, bool p)
        {

            t.indent(n);

            Node car = t.getCar();
            Node cdr = t.getCdr();
            Node cadr = cdr.getCar();
            Node caddr = cdr.getCdr().getCar();
            Node cdddr = cdr.getCdr().getCdr();

            if(!p)
            {
                Console.Write("(");
            }

            car.print(0, true);
            Console.Write(" ");
            cadr.print(0, false);
            Console.Write(" ");

            if(cadr.isPair())
            {
                caddr.print(0, false);
            }
            else
            {
                caddr.print(n++, false);
                n--;
            }
            cdddr.print(n, true);
        }
    }
}


