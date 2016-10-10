// Parser -- the parser for the Scheme printer and interpreter
//
// Defines
//
//   class Parser;
//
// Parses the language
//
//   exp       ->  ( rest
//              |  #f
//              |  #t
//              |  ' exp 
//              |  integer_constant
//              |  string_constant
//              |  identifier
//
//   rest      ->  )
//              |  exp rest_tail 
//
//   rest_tail ->  rest
//              |  . exp )
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
            Token token = scanner.getNextToken();
            return parseExp(token);
        }
  
        protected Node parseRest()
        {
            Token token = scanner.getNextToken();
            return parseRest(token);
        }

        private Node parseRestTail()
        {
            Token token = scanner.getNextToken();
            return parseRestTail(token);
        }

        // -- parse the grammar -------------------------------- //

        // exp       ->  ( rest
        //            |  #f
        //            |  #t
        //            |  ' exp 
        //            |  integer_constant
        //            |  string_constant
        //            |  identifier
        public Node parseExp(Token token)
        {
            if (token == null)
                return null;
            else if (token.getType() == TokenType.LPAREN)
                return parseRest();
            else if (token.getType() == TokenType.FALSE)
                return falseNode;
            else if (token.getType() == TokenType.TRUE)
                return trueNode;
            else if (token.getType() == TokenType.QUOTE)
                return quoteNode();
            else if (token.getType() == TokenType.INT)
                return intLiteral(token);
            else if (token.getType() == TokenType.STRING)
                return stringLiteral(token);
            else if (token.getType() == TokenType.IDENT)
                return ident(token);
            return null;
        }

        // rest      ->  )
        //            |  exp rest_tail 
        protected Node parseRest(Token token)
        {
            if (token == null)
                return null;
            else if (token.getType() == TokenType.RPAREN)
                return nilNode;
            else
            {
                Node exp = parseExp(token);
                Node rest_tail = parseRestTail();
                if (exp == null || rest_tail == null)
                    return null;
                return new Cons(exp, rest_tail);
            }
            //return null;
        }

        // rest_tail ->  . exp )
        //            |  rest
        private Node parseRestTail(Token token)
        {
            if (token == null)
                return null;
            else if (token.getType() == TokenType.DOT)
            {
                Node exp = parseExp();
                if (exp == null)
                    return null;
                // Now we look ahead 1
                Token nextToken = scanner.getNextToken();
                while (nextToken != null && !isRparen(token))
                {
                    nextToken = scanner.getNextToken();
                }
                return exp;
            }
            else
                return parseRest(token);
            //return null;
        }

        // -- helpers for quote, literal, and ident nodes ----- //

        private Node quoteNode()
        {
            Node exp = parseExp();
            if (exp == null)
                return null;
            return new Cons(new Ident("quote"), 
                            new Cons(exp, nilNode));
        }

        private Node intLiteral(Token token)
        {
            return new IntLit(token.getIntVal());
        }

        private Node stringLiteral(Token token)
        {
            return new StringLit(token.getStringVal());
        }

        private Node ident(Token token)
        {
            return new Ident(token.getName());
        }

        // -- token type helpers ------------------------------- //
        private bool isRparen(Token token)
        {
            return token.getType() ==TokenType.RPAREN;
        }
    }
}

