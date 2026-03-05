using System;

namespace Calculator
{

    class Program
    {
        static void Main()
        {
            Console.Title = "Calculator";
            PrintHeader();

            double number1 = ReadNumber("Enter the first number : ");
            double number2 = ReadNumber("Enter the second number: ");

            string operation = ReadOperation();

            if (!TryCalculate(number1, number2, operation, out double result, out string? error))
            {
                PrintError(error!);
                return;
            }

            PrintResult(number1, operation, number2, result);
        }

        static double ReadNumber(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();

                if (double.TryParse(input, out double value))
                    return value;

                PrintError("Invalid number. Please try again.");
            }
        }

        static string ReadOperation()
        {
            string[] validOperators = { "+", "-", "*", "/" };

            while (true)
            {
                Console.Write("Choose an operation (+, -, *, /): ");
                string? input = Console.ReadLine()?.Trim();

                if (input is not null && Array.Exists(validOperators, op => op == input))
                    return input;

                PrintError($"'{input}' is not a valid operator. Use +, -, * or /.");
            }
        }

        static bool TryCalculate(double a, double b, string op, out double result, out string? error)
        {
            result = 0;
            error  = null;

            switch (op)
            {
                case "+": result = a + b; break;
                case "-": result = a - b; break;
                case "*": result = a * b; break;
                case "/":
                    if (b == 0)
                    {
                        error = "Division by zero is not allowed.";
                        return false;
                    }
                    result = a / b;
                    break;
                default:
                    error = $"Unknown operator '{op}'.";
                    return false;
            }

            return true;
        }

        static void PrintHeader()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════╗");
            Console.WriteLine("║       CALCULATOR         ║");
            Console.WriteLine("╚══════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();
        }

        static void PrintResult(double a, string op, double b, double result)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"  {a} {op} {b} = {result}");
            Console.ResetColor();
        }

        static void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"  [Error] {message}");
            Console.ResetColor();
        }
    }
}
