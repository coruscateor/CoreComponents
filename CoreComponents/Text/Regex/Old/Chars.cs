using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using reg = System.Text.RegularExpressions;

namespace CoreComponents.Text.Regex
{

    [Dictionary()]
    public static class Chars
    {

        //see: http://en.wikipedia.org/wiki/Regex

        //metacharacters
        public const char OpeningSB = '['; //	A bracket expression. Matches a single character that is contained within the brackets. For example, [abc] matches "a", "b", or "c". [a-z] specifies a range which matches any lowercase letter from "a" to "z". These forms can be mixed: [abcx-z] matches "a", "b", "c", "x", "y", or "z", as does [a-cx-z].
        public const char ClosingSB = ']'; //The - character is treated as a literal character if it is the last or the first (after the ^) character within the brackets: [abc-], [-abc]. Note that backslash escapes are not allowed. The ] character can be included in a bracket expression if it is the first (after the ^) character: []abc].
        public const char Backslash = '\\';
        public const char Caret = '^'; //	Matches the starting position within the string. In line-based tools, it matches the starting position of any line.
        public const char Dollar = '$'; //	Matches the ending position of the string or the position just before a string-ending newline. In line-based tools, it matches the ending position of any line.
        public const char Dot = '.'; //	Matches any single character (many applications exclude newlines, and exactly which characters are considered newlines is flavor, character encoding, and platform specific, but it is safe to assume that the line feed character is included). Within POSIX bracket expressions, the dot character matches a literal dot. For example, a.c matches "abc", etc., but [a.c] matches only "a", ".", or "c".
        public const char Or = '|';

        //[^ ] 	Matches a single character that is not contained within the brackets. For example, [^abc] matches any character other than "a", "b", or "c". [^a-z] matches any single character that is not a lowercase letter from "a" to "z". As above, literal characters and ranges can be mixed.

        //BRE: \( \)
        //ERE: ( ) 	Defines a marked subexpression. The string matched within the parentheses can be recalled later (see the next entry, \n). A marked subexpression is also called a block or capturing group.

        //Quantification
        public const char Question = '?'; //The question mark indicates there is zero or one of the preceding element. For example, colou?r matches both "color" and "colour".
        public const char Asterisk = '*'; //The asterisk indicates there are zero or more of the preceding element. For example, ab*c matches "ac", "abc", "abbc", "abbbc", and so on.
                                          //Matches the preceding element zero or more times. For example, ab*c matches "ac", "abc", "abbbc", etc. [xyz]* matches "", "x", "y", "z", "zx", "zyx", "xyzzy", and so on. \(ab\)* matches "", "ab", "abab", "ababab", and so on.
        public const char Plus = '+'; //	The plus sign indicates that there is one or more of the preceding element. For example, ab+c matches "abc", "abbc", "abbbc", and so on, but not "ac".
        public const char OpeningRB = '(';
        public const char ClosingRB = ')';
        public const string b = @"\b"; // word boundary
        public const string w = @"\w";
        //public const string n = @"\n"; 	//Matches what the nth marked subexpression matched, where n is a digit from 1 to 9. This construct is theoretically irregular and was not adopted in the POSIX ERE syntax. Some tools allow referencing more than nine capturing groups

        //BRE: \{m,n\}
        //ERE: {m,n} 	Matches the preceding element at least m and not more than n times. For example, a\{3,5\} matches only "aaa", "aaaa", and "aaaaa". This is not found in a few older instances of regular expressions.
        
        public static string slashn(int n)
        {

            if (n < 0)
            {
                n = 0;

            } else if(n > 9)
            {
                n = 9;
            }

            return "\\" + n.ToString();

        }

        //literalcharacters
        public const char OpeningBrace = '{';
        public const char ClosingBrace = '}';
        public const char Hyphen = '-';
        public const char UnderScore = '_';

        /*
        public List<char> ToCharList(System.Text.RegularExpressions.Regex reg)
        {

            return new List<char>(reg.);

        }
        */
    }

    [Dictionary()]
    public static class ASCIITokens
    {
        public const string Control = "\\c";
        //System.Text.ASCIIEncoding
        public const string ControlA = "\\cA";
        //In Between
        public const string ControlZ = "\\cZ";

    }

}
