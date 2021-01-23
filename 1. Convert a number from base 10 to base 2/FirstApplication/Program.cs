using System;

namespace FirstApplication
{
    class Program
    {
        static void Main()
        {
            string inputString = Console.ReadLine();
            int input;

            if (!int.TryParse(inputString, out input))
            {
                Console.WriteLine("The program converts only positive integers.");
            }
            else if (input < 0)
            {
                Console.WriteLine("The program converts only positive integers.");
            }
            else
            {
                const int baseTwo = 2;
                string result = "";
                while (input >= 0)
                {
                    int resultBit = input % 2;
                    result += resultBit;
                    input /= baseTwo;
                    if (input == 0)
                    {
                        break;
                    }
                }

                Console.WriteLine(Reverse(result));
            }
        }

        static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}