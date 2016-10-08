using System;

namespace Tree
{
    public class Regular : Special
    {
        public Regular() { }

        public override void print(Node t, int n, bool p)
        {
            Node car = t.getCar();
            Node cdr = t.getCdr();

            t.indent(n);

            if(!p)                          { Console.Write("(");   }

            if(car.isNull())                { Console.Write("()");  }

            if(t.isPair() && !cdr.isNull())
            {
                if(car.isPair())            { car.print(n, false);  }
                else                        { car.print(n, true);   }

                Console.Write(" ");

                if(cdr.isPair())            { cdr.print(n, false);  }
                else                        { cdr.print(n, true);   }
            }

            else if(!t.isPair())
            {
                t.print(0, true);
            }
        }
    }
}


