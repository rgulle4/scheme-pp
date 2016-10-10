// Cons -- Parse tree node class for representing a Cons node

using System;

namespace Tree
{
    public class Cons : Node
    {
        private Node car;
        private Node cdr;
        private Special form;
    
        public Cons(Node a, Node d)
        {
            car = a;
            cdr = d;
            parseList();
        }

        void parseList()
        {
            if(!car.isSymbol()) { form = new Regular(); }
            else
            {
                string name = car.getName();
                if (name.Equals("begin")) form = new Begin();
                else if (name.Equals("cond")) form = new Cond();
                else if (name.Equals("define")) form = new Define();
                else if (name.Equals("if")) form = new If();
                else if (name.Equals("lambda")) form = new Lambda();
                else if (name.Equals("let")) form = new Let();
                else if (name.Equals("quote")) form = new Quote();
                else if (name.Equals("set")) form = new Set();
                else form = new Regular();
            }
        }

        public override Node getCar() { return car; }
        public override Node getCdr() { return cdr; }
 
        public override void print(int n)
        {
            form.print(this, n, false);
        }

        public override void print(int n, bool p)
        {
            form.print(this, n, p);
        }

        public override bool isPair() { return true; }
    }
}

