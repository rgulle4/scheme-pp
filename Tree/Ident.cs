// Ident -- Parse tree node class for representing identifiers

using System;

namespace Tree
{
    public class Ident : Node
    {
        private string name;

        public Ident(string n)
        {
            name = n;
        }

        public override string getName() { return name; }

        public override void print(int n)
        {
	        // There got to be a more efficient way to print n spaces.
	        indent(n);
            Console.Write(name);
        }

        public override bool isSymbol() { return true; }
    }
}

