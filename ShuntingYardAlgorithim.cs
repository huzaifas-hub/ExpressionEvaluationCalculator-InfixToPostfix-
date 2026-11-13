using System.ComponentModel.Design;

namespace expressionEvaluator
{
    public class ShuntingYard
    {
        private bool IsRightAssociative(string token)
        {
            // The power operator and unary minus/plus evaluate right-to-left
            return token == "^" || token == "u-" || token == "u+";
        }
        private readonly Dictionary<string, int> precedence = new Dictionary<string, int>
    {
        { "or", 1 },
        { "and", 2 },
        { "not", 3 },
        { "<", 4 }, { "<=", 4 }, { ">", 4 }, { ">=", 4 }, { "=", 4 }, { "!=", 4 },
        { "+", 5 }, { "-", 5 },
        { "*", 6 }, { "/", 6 },
        { "u+", 7 }, { "u-", 7 },
        { "^", 8 }
    };
        public List<string> ConvertToPostfix(List<string> tokens)
        {
            List<string> postfix = new List<string>();
            Stack<string> operatorStack = new Stack<string>();
            foreach (string token in tokens)
            {
                if (char.IsLetterOrDigit(token[0]))
                {
                    postfix.Add(token);
                }
                else if (token == "(")
                {
                    operatorStack.Push(token);

                }
                else if (token == ")")
                {
                    while (!operatorStack.IsEmpty() && operatorStack.Peek() == ")")
                    {
                        postfix.Add(operatorStack.Pop());
                    }
                    if (!operatorStack.IsEmpty() && operatorStack.Peek() == ")")
                    {
                        operatorStack.Pop();
                    }
                }
                else if (precedence.ContainsKey(token))
                {
                    {
                        while (!operatorStack.IsEmpty() && operatorStack.Peek() != "(" &&
                               (precedence[operatorStack.Peek()] > precedence[token] ||
                               (precedence[operatorStack.Peek()] == precedence[token] && !IsRightAssociative(token))))
                        {
                            postfix.Add(operatorStack.Pop());
                        }

                        operatorStack.Push(token);
                    }


                }
            }
        }
    }

}
