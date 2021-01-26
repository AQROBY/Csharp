using System;

namespace FirstApplication
{
    class Program
    {
        static void Main()
        {
            int operationSelect = Convert.ToInt32(Console.ReadLine());
            string inputString = Console.ReadLine();
            const int optionNumberTwo = 2;
            const int optionNumberThree = 3;

            if (operationSelect == 1)
            {
                ConvertToBaseTwo(inputString);
            }
            else if (operationSelect == optionNumberTwo)
            {
                ConvertToBaseTen(Convert.ToString(inputString));
            }
            else if (operationSelect == optionNumberThree)
            {
                ApplyNotOperator(Convert.ToString(inputString));
            }
            else
            {
                Console.WriteLine("Invalid operation.");
            }
        }

        static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        static void ConvertToBaseTwo(string inputString)
        {
            long input;
            if (!long.TryParse(inputString, out input) || input < 0)
            {
                Console.WriteLine("The program converts only positive integers.");
                return;
            }

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

        static void ApplyNotOperator(string input)
        {
            char[] arr = input.ToCharArray(0, input.Length);

            if (!ValidateApplyNotOperator(arr))
            {
                return;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = arr[i] == '0' ? '1' : '0';
            }

            if (arr.Length > 1)
            {
                char[] deletedZeroes = new char[arr.Length - 1];

                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] == '0')
                    {
                        Array.Copy(arr, 1, deletedZeroes, 0, deletedZeroes.Length);
                    }
                    else
                    {
                        break;
                    }
                }

                if (deletedZeroes[0] == '0')
                {
                    Console.WriteLine('0');
                    return;
                }

                string result = new string(deletedZeroes);
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine(arr[0]);
            }
        }

        static bool ValidateApplyNotOperator(char[] arr)
        {
            foreach (char elem in arr)
            {
                if (elem != '0' && elem != '1')
                {
                    Console.WriteLine("A valid binary number was not entered(only 0's and 1's).");
                    return false;
                }
            }

            return true;
        }
    }
}