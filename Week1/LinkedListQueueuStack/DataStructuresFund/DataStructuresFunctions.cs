

using System.Text;

namespace DataStructuresFund
{
    public class DataStructuresFunctions<T>
    {

        public static List<T> ReturnUniqueElements(List<T> input) => new HashSet<T>(input).ToList();

        public static bool EraseTheMiddleElement(LinkedList<T> input)
        {
            
            if (input.Count == 0)
            {
                return false;
            }
            int middle = input.Count / 2;
            LinkedListNode<T> current = input.First;
            while (middle > 0)
            {
                current = current.Next;
                
                middle--;
            }

            input.Remove(current); // remove the middle node


            return true; 
        }

        public static Stack<int> SolveTowersOfHonoi(Stack<int> A)
        {

            A.Push(30);
            A.Push(20);
            A.Push(10);
            Stack<int> B = new Stack<int>();
            Stack<int> C = new Stack<int>();


            C.Push(A.Pop());
            B.Push(A.Pop());
            B.Push(C.Pop());
            C.Push(A.Pop());
            A.Push(B.Pop());
            C.Push(B.Pop());
            C.Push(A.Pop());

            return C;
        }

        public static string ExpressionExpander(string input)
        {
            StringBuilder result = new StringBuilder();
            Stack<char> brackets = new Stack<char>();
            int i = 0;
            while (i < input.Length)
            {
                if (Char.IsDigit(input[i]))
                {
                    int multiplier = (int)(input[i] - '0');
                    StringBuilder expression = new StringBuilder();

                    i += 2; // skip openning bracket
                    brackets.Push('(');
                    while (brackets.Count != 1 || input[i] != ')')
                    {
                        if (input[i] == '(')
                        {
                            brackets.Push('(');
                        }
                        else if (input[i] == ')')
                        {
                            brackets.Pop();
                        }
                        expression.Append(input[i]);
                        i++;

                    }

                    if (expression.ToString().Any(Char.IsDigit))
                    {
                        expression = new StringBuilder(ExpressionExpander(expression.ToString()));
                    }

                    for (int j = 0; j < multiplier; j++)
                    {
                        result.Append(expression);
                    }


                    brackets.Pop();
                }
                else
                {
                    result.Append(input[i]);
                }
                i++;
            }

            return result.ToString();
        }

        public static Queue<char> ShuntingYardParser(string expression)
        {
            // 1+2/2-3     1 2 + 2 / 3 -
            Queue<char> parsed = new Queue<char>();
            int index = 0;
            while (index < expression.Length)
            {
                if (Char.IsDigit(expression[index]))
                {
                    char firstOperand = expression[index];
                    parsed.Enqueue(firstOperand);
                }
                else
                {
                    char operation = expression[index];
                    index++;
                    char secondOperand = expression[index];
                    parsed.Enqueue(secondOperand);
                    parsed.Enqueue(operation);

                }
                index++;
            }
            return parsed;
        }

        public static int Evaluate(Queue<char> input)
        {
            if (input.Count == 0)
            {
                throw new InvalidOperationException();
            }
            int acumulator = (int)(input.Dequeue() - '0');
            int current = -1;
            while (input.Count > 0)
            {

                if (Char.IsDigit(input.Peek()))
                {
                    current = (int)(input.Dequeue() - '0');
                }
                else
                {
                    switch (input.Dequeue())
                    {
                        case '+': acumulator += current; break;
                        case '-': acumulator -= current; break;
                        case '*': acumulator *= current; break;
                        case '/': acumulator /= current; break;
                    }
                }

            }
            return acumulator;
        }
    }
}