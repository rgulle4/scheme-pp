
using System;

namespace Tree
{
    public class Let : Special
    {
	public Let() { }

        public override void print(Node t, int n, bool p)
        {
            Node cdr = t.getCdr();
            Node car = t.getCar();
            Node cadr = cdr.getCar();

            t.indent(n);

            if(!p)  { Console.Write("("); }

            car.print(n, true);
            Console.WriteLine();

            n++

            while(!cdr.isNull())
            {
                t.indent(n);
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


