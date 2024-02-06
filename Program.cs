using System.Security.Cryptography;

namespace FunctionsAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, and welcome to my program!");
            IterateProgram();
        }

        static void IterateProgram()
        {
            Console.WriteLine();
            
            Console.Write("Please enter a number > ");
            double num1 = GetInputAsDouble();
            
            Console.Write("Please enter a second number > ");
            double num2 = GetInputAsDouble();
            
            Console.Write("Please enter an operator > ");
            string op = GetOperator();
            

            
            PerformMath(num1, num2, op);

            
            
            Console.Write("Would you like to go again? Y/N > ");
            string input = Console.ReadLine();

            if (input.ToUpper() == "Y") IterateProgram();
            else if (input.ToUpper() == "N")
            {
                Console.WriteLine("Have a nice day!");
                Console.ReadLine();
            }
        }

        static double GetInputAsDouble()
        {
            try
            {
                return double.Parse(Console.ReadLine());
            }
            catch
            {
                // Add 1 to newNumber so we never get 0
                // 0 can be problematic if this is the second operand during division
                double newNumber = RandomNumberGenerator.GetInt32(100) + 1;
                Console.WriteLine("Invalid number. I'll just assume you meant " + newNumber);
                return newNumber;
            }
        }

        static string GetOperator()
        {
            string[] validOperators = { "+", "-", "*", "/", "%", "^" };
            string input = Console.ReadLine();
            foreach(string op in validOperators)
            {
                if (input == op)
                    return op;
            }
            int randomIndex = RandomNumberGenerator.GetInt32(validOperators.Length);
            string newOperator = validOperators[randomIndex];
            Console.WriteLine("Invalid operator! I'll just assume you meant " + newOperator);
            return newOperator;
        }

        static void PerformMath(double num1, double num2, string op)
        {
            double result = 0;

            switch(op)
            {
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    if (num2 == 0)
                    {
                        Console.WriteLine("Cannot divide by zero!");
                        return;
                    }
                    else result = num1 / num2;
                    break;
                case "%":
                    result = num1 % num2;
                    break;
                case "^":
                    result = Math.Pow(num1, num2);
                    break;
            }
            Console.WriteLine(num1 + " " + op + " " + num2 + " = " + result);

        }
    }
}
