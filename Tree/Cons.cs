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
    
        // parseList() `parses' special forms, constructs an appropriate
        // object of a subclass of Special, and stores a pointer to that
        // object in variable form.  It would be possible to fully parse
        // special forms at this point.  Since this causes complications
        // when using (incorrect) programs as data, it is easiest to let
        // parseList only look at the car for selecting the appropriate
        // object from the Special hierarchy and to leave the rest of
        // parsing up to the interpreter.
        void parseList()
        {
            // Implement this function and any helper functions
            // you might need.
            if (isBegin(car))
                form = new Begin();
            else if (isCond(car))
                form = new Cond();
            else if (isDefine(car))
                form = new Define();
            else if (isIf(car))
                form = new If();
            else if (isLambda(car))
                form = new Lambda();
            else if (isLet(car))
                form = new Let();
            else if (isQuote(car)) 
                form = new Quote();
            else if (isSet(car))
                form = new Set();
            // fall through to default form Regular
            form = new Regular();
        }
 
        public override void print(int n)
        {
            form.print(this, n, false);
        }

        public override void print(int n, bool p)
        {
            form.print(this, n, p);
        }

        public override bool isPair() { return true; }

        /* -- Car and cdr overrides ------------------------- */

        // After setCar, a Cons cell needs to be 'parsed' again 
        // using parseList.

        public override Node getCar() {
            return car;
        }
        
        public override Node getCdr() { 
           return cdr;
        }

        public override void setCar(Node a) { 
            car = a;
            parseList();
        }

        public override void setCdr(Node d) { 
            cdr = d;
        }

        /* -- Helpers to determine special types --------------- */
        private bool isBegin(Node node) {
            return (node.getName().Equals("begin"));
        }

        private bool isCond(Node node) {
            return (node.getName().Equals("cond"));
        }

        private bool isDefine(Node node) {
            return (node.getName().Equals("define"));
        }
        private bool isIf(Node node) {
            return (node.getName().Equals("if"));
        }
        private bool isLambda(Node node) {
            return (node.getName().Equals("lambda"));
        }
        private bool isLet(Node node) {
            return (node.getName().Equals("let"));
        }
        private bool isQuote(Node node) {
            return (node.getName().Equals("quote"));
        }
        private bool isSet(Node node) {
            return (node.getName().Equals("set"));
        }
    }
}

