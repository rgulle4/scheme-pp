// Begin -- Parse tree node strategy for printing the special form begin

using System;

namespace Tree
{
    public class Begin : Special
    {
	public Begin() { }
        public override void print(Node t, int n, bool p)
        {
            Node car = t.getCar();
            Node cdr = t.getCdr();

            t.indent(n);

            if(!p) Console.Write("(");

            car.print(n, true);
            Console.WriteLine();

            n++;

            t.setForm(new Regular());

            while(!cdr.isNull()) {
                t.printIndent(n);
                Node cadr = cdr.getCar();
                cadr.print(0, false);
                Console.WriteLine();
                cdr = cdr.getCdr();
            }

            n--;
            cdr.print(n, true);
            Console.WriteLine();
        }
    }
}

