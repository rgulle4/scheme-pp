// Parser -- the parser for the Scheme printer and interpreter
//
// Defines
//
//   class Parser;
//
// Parses the language
//
//   exp  ->  ( rest
//         |  #f
//         |  #t
//         |  ' exp
//         |  integer_constant
//         |  string_constant
//         |  identifier
//    rest -> )
//         |  exp+ [. exp] )
//
// and builds a parse tree.  Lists of the form (rest) are further
// `parsed' into regular lists and special forms in the constructor
// for the parse tree node class Cons.  See Cons.parseList() for
// more information.
//
// The parser is implemented as an LL(0) recursive descent parser.
// I.e., parseExp() expects that the first token of an exp has not
// been read yet.  If parseRest() reads the first token of an exp
// before calling parseExp(), that token must be put back so that
// it can be reread by parseExp() or an alternative version of
// parseExp() must be called.
//
// If EOF is reached (i.e., if the scanner returns a NULL) token,
// the parser returns a NULL tree.  In case of a parse error, the
// parser discards the offending token (which probably was a DOT
// or an RPAREN) and attempts to continue parsing with the next token.

using System;
using Tokens;
using Tree;

namespace Parse
{
    public class Parser {
	
        private Scanner scanner;

        public Parser(Scanner s) { scanner = s; }

        // we only need one instance of each of these
        public static readonly Nil nilNode = new Nil();
        public static readonly BoolLit trueNode = new BoolLit(true);
        public static readonly BoolLit falseNode = new BoolLit(false);
  
        public Node parseExp()
        {
            Node exp = null;

            Token token = scanner.getNextToken();

            if(token == null)
            {
                exp = null;
            }
            else if(token.getType() == TokenType.LPAREN)
            {
                exp = parseRest();
            }
            else if(token.getType() == TokenType.FALSE)
            {
                exp = new BoolLit(false);
            }
            else if(token.getType() == TokenType.TRUE)
            {
                exp = new BoolLit(true);
            }
            else if(token.getType() == TokenType.QUOTE)
            {
                exp = new Cons(new Ident("'"), new Cons(parseExp(), null);
            }
            else if(token.getType() == TokenType.INT)
            {
                exp = new IntLit(token.getIntVal());
            }
            else if(token.getType() = TokenType.STRING)
            {
                exp = new StringLit(token.getStringVal());
            }
            else if(token.getType() = TokenType.IDENT)
            {
                exp = new Ident(token.getName());
            }
            else if(token.getType() = TokenType.RPAREN)
            {
                System.out.println("Token Error: )");
                exp = parseExp();
            }
            else if(token.getType() = TokenType.DOT)
            {
                System.out.println("Token Error: .");
                exp = parseExp();
            }
            // parsing error
            else{
                System.out.println("Token Error Type: " + token.getType());
            }
            return exp;
        }
  
        protected Node parseRest()
        {
           //uhhh 
        }
    }
}
    



