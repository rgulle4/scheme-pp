using System;
using Tokens;
using Tree;

namespace Parse
{
    public class Parser {
	
        private Scanner scanner;

        public Parser(Scanner s) { scanner = s; }

        // Actual execution to parse an expression, calls the version of parseExp
        // that takes a parameter token T
        public Node parseExp()      { return parseExp(scanner.getNextToken()); }
  
        // Actual execution to parse the remainder of an expression, calls the version of 
        // parseRest that takes a parameter token T
        protected Node parseRest()  { return parseRest(scanner.getNextToken()); }

        // Takes a parameter token T and deciphers its type. Returns a portion of the program string
        // corresponding to the token type and value
        public Node parseExp(Token t)
        {
            if (t == null) { return null; }
            else if (t.getType() == TokenType.LPAREN) { return parseRest(); }
            else if (t.getType() == TokenType.TRUE) { return new BoolLit(true); }
            else if (t.getType() == TokenType.FALSE) { return new BoolLit(false); }
            else if (t.getType() == TokenType.QUOTE)
            {
                Node exp = parseExp();
                if (exp == null)
                {
                    Console.Error.WriteLine("End of file");
                    return null;
                }
                return new Cons(new Ident("quote"), new Cons(exp, new Nil()));
            }
            else if (t.getType() == TokenType.INT) { return new IntLit(t.getIntVal()); }
            else if (t.getType() == TokenType.STRING) { return new StringLit(t.getStringVal()); }
            else if (t.getType() == TokenType.IDENT) { return new Ident(t.getName()); }
            else
                Console.WriteLine("Invalid input");
            return parseExp();
        }

        // Is called if the last token read was a LPAREN. First checks to see if the next token is
        // an RPAREN, signifying nil. If not, it looks ahead to the next token and parses it. 
        // Finally looks ahead once more to check if the expr is ready to be terminated or if
        // it needs to be constructed into another pair.
        protected Node parseRest(Token t)
        {
            if (t.getType() == TokenType.RPAREN) { return new Nil(); }
            else if(t == null) { return null; }
            else 
            {
                Node next = parseExp(t);
                if (next == null) { return null; }
                else 
                {
                    Node lookahead = parseLookahead();
                    if (lookahead == null) { return null; }
                    return new Cons(next, lookahead);
                }
            }
        }

        // Is called in parseRest() to look ahead and check if the construction of a new pair is 
        // necessary. Checks if there is a dot signifying a list and, if there is, recursively calls 
        // parseExp() to find the next member of the list. 
        protected Node parseLookahead()
        {
            Token next = scanner.getNextToken();
            if (next == null)                        { return null;            }
            else if(next.getType() == TokenType.DOT) { return parseExp();      }
            else                                     { return parseRest(next); }
        }
    }
}

