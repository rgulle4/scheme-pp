// Set -- Parse tree node strategy for printing the special form set!

using System;

namespace Tree
{
    public class Set : Special
    {
	public Set() { }
	
        public override void print(Node t, int n, bool p)
        {
            Node car = t.getCar();
            Node cdr = t.getCdr();
            Node cadr = cdr.getCar();
            Node cddr = cdr.getCdr();
            Node caddr = cdr.getCdr().getCar();
            Node cdddr = cdr.getCdr().getCdr();

            t.indent(n);

            if(!p) { Console.Write("("); }

            car.print(n, true);
            Console.Write(" ");
            cadr.print(n, true);
            Console.Write(" ");
            caddr.print(n, false);
            cdddr.print(n, true);
            Console.WriteLine();
        }
    }
}

