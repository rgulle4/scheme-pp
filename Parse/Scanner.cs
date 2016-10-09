// Scanner -- The lexical analyzer for the Scheme printer and interpreter

using System;
using System.IO;
using Tokens;

namespace Parse
{
    public class Scanner
    {
        /* -- field(s) ------------------------------------- */

        private TextReader In;

        // maximum length of strings and identifier
        private const int BUFSIZE = 1000;
        private char[] buf = new char[BUFSIZE];

        public Scanner(TextReader i) { In = i; }

        /* -- option(s) ------------------------------------ */

        private readonly bool PRINT_MESSAGES = false;

        /* -- private method(s) ---------------------------- */

        private void printDebugMsg(Object o) 
        {
            if (PRINT_MESSAGES) { Console.WriteLine(o); }
        }

        /**
         * TODO: this thing isn't eating whitespace properly, especially 
         * line breaks or multiple space chars.
         */
        private bool isWhiteSpace(int ch) 
        {
            bool result = Char.IsWhiteSpace((Char) ch);
            if (result) { printDebugMsg("Whitespace!"); }
            return result;
        }

        private bool isStartOfComment(int ch) 
        {
            bool result = (ch == ';');
            if (result) { printDebugMsg("Semicolon!"); }
            return result;
        }

        /**
         * An identifier begins with any non-number, usually. 
         * See https://people.csail.mit.edu/jaffer/r5rs_4.html
         */
         private bool isBeginningofIdentifier(int ch)
         {
             return (
                 (ch >= 'A' && ch <= 'Z') 
                 || (ch >= 'a' && ch <= 'z')
                 || (ch == '+')
                 || (ch == '-')
                 || (ch == '*')
                 || (ch == '/')
                 || (ch == '=')
            );
         }

        /**
         * An identifier ends with a white space, (, ), or .
         */
        private bool isEndOfIdentifier(int ch)
        {
            if (isWhiteSpace(ch))
                return true;
            // else if (ch == '\'')
                // return true;
            else if (ch == '(')
                return true;
            else if (ch == ')')
                return true;
            else if (ch == '.')
                return true;
            else
                return false;
        }

        private int chToLower(int ch)
        {
            if (ch >= 'A' && ch <= 'Z')
                ch = Char.ToLower((Char) ch);
            return ch;
        }

        private bool isNumber(int ch)
        {
            return (ch >= '0' && ch <= '9');
        }

        /* -- method(s) ------------------------------------ */

        public Token getNextToken()
        {
            int ch;

            try
            {
                // It would be more efficient if we'd maintain our own
                // input buffer and read characters out of that
                // buffer, but reading individual characters from the
                // input stream is easier.
                ch = In.Read();
                printDebugMsg("[" + (Char) ch + "]");
   
                // skip white space
                while (isWhiteSpace(ch))
                {
                    ch = In.Read();
                    printDebugMsg("[" + (Char) ch + "]");
                }

                // skip comments
                if (isStartOfComment(ch))
                {
                    In.ReadLine();
                    printDebugMsg("[" + (Char) ch + "]");
                }
                
                if (ch == -1)
                    return null;
        
                // Special characters
                else if (ch == '\'')
                    return new Token(TokenType.QUOTE);
                else if (ch == '(')
                    return new Token(TokenType.LPAREN);
                else if (ch == ')')
                    return new Token(TokenType.RPAREN);
                else if (ch == '.')
                    // We ignore the special identifier `...'.
                    return new Token(TokenType.DOT);
                
                // Boolean constants
                else if (ch == '#')
                {
                    ch = In.Read();

                    if (ch == 't')
                        return new Token(TokenType.TRUE);
                    else if (ch == 'f')
                        return new Token(TokenType.FALSE);
                    else if (ch == -1)
                    {
                        Console.Error.WriteLine("Unexpected EOF following #");
                        return null;
                    }
                    else
                    {
                        Console.Error.WriteLine("Illegal character '" +
                                                (char)ch + "' following #");
                        return getNextToken();
                    }
                }

                // String constants
                else if (ch == '"')
                {
                    // scan a string into the buffer variable buf
                    int i = 0;
                    bool done = false;
                    while (!done)
                    {
                        ch = In.Read();
                        buf[i] = (Char) ch;
                        i++;
                        // if (isEndOfString(In.Peek()))
                        if (In.Peek() == '"')
                        {
                            In.Read();
                            done = true;
                        }
                    }                       
                    return new StringToken(new String(buf, 0, i));
                }

    
                // Integer constants
                else if (isNumber(ch))
                {
                    // int theInteger = ch - '0';
                    // scan the number and convert it to an integer
                    int i = 0;
                    bool done = false;
                    while (!done)
                    {
                        buf[i] = (Char) ch;
                        i++;
                        if (!isNumber(In.Peek()))
                            done = true;
                        else 
                            ch = (Char) In.Read();
                    }

                    int result = 0;
                    for (int j = 0 ; j < i; j++)
                    {
                        int thisDigit = buf[j] - '0';
                        result = result + (thisDigit * (int) Math.Pow(10, i - j - 1));
                    }

                    // make sure that the character following the integer
                    // is not removed from the input stream
                    return new IntToken(result);
                }
        
                // Identifiers
                // or ch is some other valid first character
                // for an identifier
                else if (isBeginningofIdentifier(ch)) 
                {
                    // scan an identifier into the buffer
                    int i = 0;
                    bool done = false;
                    while (!done) 
                    {
                        buf[i] = (Char) chToLower(ch);
                        i++;
                        if (isEndOfIdentifier(In.Peek()))
                            done = true;
                        else
                            ch = In.Read();
                    }

                    // make sure that the character following the integer
                    // is not removed from the input stream

                    // public String(char[] value, int startIndex, int length);
                    return new IdentToken(new String(buf, 0, i));
                }
    
                // Illegal character
                else
                {
                    Console.Error.WriteLine("Illegal input character '"
                                            + (char)ch + '\'');
                    return getNextToken();
                }
            }
            catch (IOException e)
            {
                Console.Error.WriteLine("IOException: " + e.Message);
                return null;
            }
        }
    }

}

