// Lambda -- Parse tree node strategy for printing the special form lambda

using System;

namespace Tree
{
    public class Lambda : Special
    {
	public Lambda() { }

        public override void print(Node t, int n, bool p)
        {
            Node car = t.getCar();
            Node cdr = t.getCdr();
            Node cadr = cdr.getCar();
            Node caddr = cdr.getCdr().getCar();
            Node cdddr = cdr.getCdr().getCdr();

            t.indent(n);

            if(!p)
            {
                Console.Write("(");
            }

            car.print(0, true);
            Console.Write(" ");

            cadr.print(0, false);
            n++;

            t.indent(n);

            caddr.print(n, false);
            n--;

            t.indent(n);

            cdddr.print(n, true);
            Console.WriteLine();





  	    }
    }
}

