using System;

namespace Tree
{
    public class Node
    {
        public virtual void print(int n) { }

        public virtual void print(int n, bool p) { print(n); }

        public static void indent(int spaces)
        {
            for(int i = 0; i < spaces; i++) 
            { 
                Console.Write(" ");
            }
        }

        public static void print(Node t, int n, bool p) { t.print(n, p); }
        public static void print(Node t, int n, bool p, int i) { t.print(n, p); }

        public static void printCdr(Node t, int n)
        {
            if (t.isPair() || t.isNull()) { print(t, n, true); }
            else
            {
                if (n >= 0)
                {
                    indent(n);
                    Console.Write(". ");
                    print(t, -Math.Abs(n), false);
                    indent(n - 4);
                    Console.Write(')');
                }
                else
                {
                    Console.Write(" . ");
                    print(t, -Math.Abs(n), false);
                    Console.Write(')');
                }
            }
        }

        public virtual bool isBool()   { return false; }  // BoolLit
        public virtual bool isNumber() { return false; }  // IntLit
        public virtual bool isString() { return false; }  // StringLit
        public virtual bool isSymbol() { return false; }  // Ident
        public virtual bool isNull()   { return false; }  // Nil
        public virtual bool isPair()   { return false; }  // Cons
        public virtual Node getCar() { return null; }
        public virtual Node getCdr() { return null; }
        public virtual void setCar(Node a) { }
        public virtual void setCdr(Node d) { }
        public virtual string getName() { return ""; }
    }
}

