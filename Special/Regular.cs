// Regular -- Parse tree node strategy for printing regular lists

using System;

namespace Tree
{
    public class Regular : Special
    {
        // TODO: Add any fields needed.
    
        // TODO: Add an appropriate constructor.
        public Regular() { }

        public override void print(Node t, int n, bool p)
        {
            // TODO: Implement this function.
            if (p == false)
                printLparen();
            t.getCar().print(0, true);
            t.getCdr().print(0, true);
            printSpace();
            
        }

        /* -- helpers ------------------------------------------ */

        private void print(Object o) { Console.Write(o); }
        private void printLparen() { print('('); }
        private void printSpace() { print(' '); }
    }
}


