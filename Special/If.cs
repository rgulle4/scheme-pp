using System;

namespace Tree
{
    public class If : Special
    {

	public If() { }

        public override void print(Node t, int n, bool p)
        {
            t.indent(n);

            Node cdr = t.getCdr();
            Node cddr = cdr.getCdr();
            Node cdddr = cdr.getCdr().getCdr();
            Node cddddr = cdr.getCdr().getCdr().getCdr();

            Console.write("(if ");
            cdr.getCar().print(0, false);
            n++;

            t.indent(n);

            cddr.getCar().print(0, false);

            if(!cddr.getCar().isPair()) {Console.WriteLine();}

            t.indent(n);

            cdddr.getCar().print(0, false);
            n--;
            Console.WriteLine();

            t.indent(n);

            cddddr.print(n, true);
            Console.WriteLine();
        }
    }
}

