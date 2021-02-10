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
            const int optionNumberFour = 4;
            const int optionNumberFive = 5;
            const int optionNumberSix = 6;

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
            else if (operationSelect == optionNumberFour)
            {
                ApplyOrOperator(inputString, Console.ReadLine());
            }
            else if (operationSelect == optionNumberFive)
            {
                ApplyAndOperator(inputString, Console.ReadLine());
            }
            else if (operationSelect == optionNumberSix)
            {
                ApplyXorOperator(inputString, Console.ReadLine());
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
                    Console.WriteLine("A valid binary number was not entered (only 0's and 1's).");
                    return false;
                }
            }

            return true;
        }

        static void ApplyOrOperator(string input, string secondInput)
        {
            char[] arr = input.ToCharArray(0, input.Length);
            char[] secondArr = secondInput.ToCharArray(0, secondInput.Length);

            if (string.IsNullOrEmpty(secondInput))
            {
                Console.WriteLine(input);
                return;
            }

            if (!ValidateApplyNotOperator(arr) || !ValidateApplyNotOperator(secondArr))
            {
                return;
            }

            if (arr.Length > secondArr.Length)
            {
                char[] addedZeroes = new char[arr.Length];
                for (int i = 0; i < addedZeroes.Length; i++)
                {
                    addedZeroes[i] = '0';
                }

                int copyingIndex = arr.Length - secondArr.Length;
                Array.Copy(secondArr, 0, addedZeroes, copyingIndex, secondArr.Length);
                ApplyOrOperatorLogic(arr, addedZeroes);
            }
            else if (arr.Length < secondArr.Length)
            {
                char[] addedZeroes = new char[secondArr.Length];
                for (int i = 0; i < addedZeroes.Length; i++)
                {
                    addedZeroes[i] = '0';
                }

                int copyingIndex = secondArr.Length - arr.Length;
                Array.Copy(arr, 0, addedZeroes, copyingIndex, arr.Length);
                ApplyOrOperatorLogic(secondArr, addedZeroes);
            }
            else
            {
                ApplyOrOperatorLogic(arr, secondArr);
            }
        }

        static void ApplyOrOperatorLogic(char[] arr1, char[] arr2)
        {
            char[] arrResult = new char[arr1.Length];
            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] == '1' && arr2[i] == '1')
                {
                    arrResult[i] = '1';
                }
                else if (arr1[i] == '1' && arr2[i] == '0')
                {
                    arrResult[i] = '1';
                }
                else if (arr1[i] == '0' && arr2[i] == '1')
                {
                    arrResult[i] = '1';
                }
                else
                {
                    arrResult[i] = '0';
                }
            }

            string result = new string(arrResult);

            Console.WriteLine(Convert.ToString(result));
        }

        static void ApplyAndOperator(string input, string secondInput)
        {
            char[] arr = input.ToCharArray(0, input.Length);
            char[] secondArr = secondInput.ToCharArray(0, secondInput.Length);

            if (string.IsNullOrEmpty(secondInput))
            {
                Console.WriteLine(input);
                return;
            }

            if (!ValidateApplyNotOperator(arr) || !ValidateApplyNotOperator(secondArr))
            {
                return;
            }

            if (arr.Length > secondArr.Length)
            {
                char[] addedZeroes = new char[arr.Length];
                for (int i = 0; i < addedZeroes.Length; i++)
                {
                    addedZeroes[i] = '0';
                }

                int copyingIndex = arr.Length - secondArr.Length;
                Array.Copy(secondArr, 0, addedZeroes, copyingIndex, secondArr.Length);
                ApplyAndOperatorLogic(arr, addedZeroes);
            }
            else if (arr.Length < secondArr.Length)
            {
                char[] addedZeroes = new char[secondArr.Length];
                for (int i = 0; i < addedZeroes.Length; i++)
                {
                    addedZeroes[i] = '0';
                }

                int copyingIndex = secondArr.Length - arr.Length;
                Array.Copy(arr, 0, addedZeroes, copyingIndex, arr.Length);
                ApplyAndOperatorLogic(addedZeroes, secondArr);
            }
            else
            {
                ApplyAndOperatorLogic(arr, secondArr);
            }
        }

        static void ApplyAndOperatorLogic(char[] arr1, char[] arr2)
        {
            char[] arrResult = new char[arr1.Length];

            for (int i = 0; i < arr1.Length; i++)
            {
                arrResult[i] = arr1[i] == '1' && arr2[i] == '1' ? '1' : '0';
            }

            if (arrResult.Length > 1 && arrResult[0] != '1')
            {
                EliminateZeroes(arrResult);
            }
            else if (arrResult[0] == '1')
            {
                string resultOne = new string(arrResult);
                Console.WriteLine(resultOne);
            }
        }

        static void EliminateZeroes(char[] arrResult)
        {
            string result = "";
            int dynamicIndex = 1;
            char[] finalResult = new char[arrResult.Length];
            for (int i = 0; i < arrResult.Length; i++)
            {
                char[] deletedZeroes = new char[arrResult.Length - dynamicIndex];
                if (arrResult[i] == '1')
                {
                    string resultDeletedZeroes = new string(finalResult);
                    Console.WriteLine(resultDeletedZeroes);
                    return;
                }
                else if (deletedZeroes.Length <= 1)
                {
                    Console.WriteLine('0');
                    return;
                }
                else if (arrResult[i] == '0')
                {
                    Array.Copy(arrResult, dynamicIndex, deletedZeroes, 0, deletedZeroes.Length);
                    dynamicIndex++;
                    finalResult = deletedZeroes;
                }

                result = new string(deletedZeroes);
            }

            Console.WriteLine(result);
        }

        static void ApplyXorOperator(string input, string secondInput)
        {
            char[] arr = input.ToCharArray(0, input.Length);
            char[] secondArr = secondInput.ToCharArray(0, secondInput.Length);

            if (string.IsNullOrEmpty(secondInput))
            {
                Console.WriteLine(input);
                return;
            }

            if (!ValidateApplyNotOperator(arr) || !ValidateApplyNotOperator(secondArr))
            {
                return;
            }

            if (arr.Length > secondArr.Length)
            {
                char[] addedZeroes = new char[arr.Length];
                for (int i = 0; i < addedZeroes.Length; i++)
                {
                    addedZeroes[i] = '0';
                }

                int copyingIndex = arr.Length - secondArr.Length;
                Array.Copy(secondArr, 0, addedZeroes, copyingIndex, secondArr.Length);
                ApplyXorOperatorLogic(arr, addedZeroes);
            }
            else if (arr.Length < secondArr.Length)
            {
                char[] addedZeroes = new char[secondArr.Length];
                for (int i = 0; i < addedZeroes.Length; i++)
                {
                    addedZeroes[i] = '0';
                }

                int copyingIndex = secondArr.Length - arr.Length;
                Array.Copy(arr, 0, addedZeroes, copyingIndex, arr.Length);
                ApplyXorOperatorLogic(addedZeroes, secondArr);
            }
            else
            {
                ApplyXorOperatorLogic(arr, secondArr);
            }
        }

        static void ApplyXorOperatorLogic(char[] arr1, char[] arr2)
        {
            char[] arrResult = new char[arr1.Length];

            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] == '1' && arr2[i] == '0')
                {
                    arrResult[i] = '1';
                }
                else if (arr1[i] == '0' && arr2[i] == '1')
                {
                    arrResult[i] = '1';
                }
                else
                {
                    arrResult[i] = '0';
                }
            }

            if (arrResult.Length > 1 && arrResult[0] != '1')
            {
                EliminateZeroes(arrResult);
            }
            else if (arrResult[0] == '1')
            {
                string resultOne = new string(arrResult);
                Console.WriteLine(resultOne);
            }
        }
    }
}