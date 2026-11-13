namespace expressionEvaluator
{
    public class ExpressionTokenizer
    {
        private bool isOperator(string token)
        {
            return token == "+" || token == "-" || token == "*" || token == "/" || token == "%" ||
                 token == "<" || token == "^" || token == ">" || token == "<=" || token == ">=" ||
                 token == "!=" || token == "=" || token == "and" || token == "or" || token == "not" ||
                 token == "or" || token == "u-" || token == "u+";
        }
        public List<string> Tokenize(string expression)
        {
            List<string> tokens = new List<string>();
            for (int i = 0; i < expression.Length; i++)
            {
                char e = expression[i];
                if (char.IsWhiteSpace(e)) continue;
                if (char.IsLetter(e))
                {
                    string number = "";
                    while (i < expression.Length && char.IsLetterOrDigit(expression[i]))
                    {
                        number += expression[i];
                        i++;
                    }
                    tokens.Add(number);
                    i--;
                }
                else if ((e == '<' || e == '>' || e == '!') && i + 1 < expression.Length && expression[i + 1] == '=')
                {
                    tokens.Add(e.ToString() + "=");
                    i++;
                }
                else if (e == '-' || e == '+')
                {
                    bool isUnary = false;
                    if (tokens.Count == 0)
                    {
                        isUnary = true;
                    }
                    else
                    {
                        string lastToken = tokens[tokens.Count - 1];

                        if (lastToken == "(" || isOperator(lastToken))
                        {
                            isUnary = true;
                        }
                    }
                    if (isUnary)
                    {
                        tokens.Add(e == '-' ? "u-" : "u+");
                    }
                }
                else
                {
                    tokens.Add(e.ToString());
                }

            }
            return tokens;
        }
    }
}