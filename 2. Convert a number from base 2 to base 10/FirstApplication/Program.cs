using System;

namespace FirstApplication
{
    class Program
    {
        static void Main()
        {
            int operationSelect = Convert.ToInt32(Console.ReadLine());
            string inputString = Console.ReadLine();
            long input;
            const int magicNumberTwo = 2;

            if (!long.TryParse(inputString, out input))
            {
                Console.WriteLine("The program converts only positive integers.");
            }
            else if (input < 0)
            {
                Console.WriteLine("The program converts only positive integers.");
            }
            else
            {
                if (operationSelect == 1)
                {
                    ConvertToBaseTwo(input);
                }
                else if (operationSelect == magicNumberTwo)
                {
                    ConvertToBaseTen(Convert.ToString(inputString));
                }
                else
                {
                    Console.WriteLine("Invalid operation.");
                }
            }
        }

        static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        static void ConvertToBaseTwo(long input)
        {
            const int baseTwo = 2;
            string result = "";
            while (input >= 0)
            {
                long resultBit = input % 2;
                result += resultBit;
                input /= baseTwo;
                if (input == 0)
                {
                    break;
                }
            }

            Console.WriteLine(Reverse(result));
        }

        static void ConvertToBaseTen(string input)
        {
            string inputString = Convert.ToString(input);

            foreach (char elem in input.ToCharArray(0, input.Length))
            {
                if (elem != '0' && elem != '1')
                {
                    Console.WriteLine("A valid binary number was not entered (only 0's and 1's).");
                    return;
                }
            }

            int result = Convert.ToInt32(inputString, 2);

            Console.WriteLine(result);
        }
    }
}