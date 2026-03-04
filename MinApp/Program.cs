using System;

namespace GettingInput
{
  class Program
  {
    static void Main()
    {
        Console.WriteLine("Enter the first number:");
        int number1 = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the second number:");
        int number2 = int.Parse(Console.ReadLine());

        Console.WriteLine("Choose an operation (+, -, *, /):");
        string operation = Console.ReadLine();

        int result = 0;

        if (operation == "+")
            {
                result = number1 + number2;
            }
        else if (operation == "-")
            {
                result = number1 - number2;
            }
        else if (operation == "*")
            {
                result = number1 * number2;
            }
        else if (operation == "/")
            {
                result = number1 / number2;
            }
        else
            {
                Console.WriteLine("Invalid operation.");
                return;
            }
        
        Console.WriteLine($"The result is:  + {result}");
    }
  }
    }