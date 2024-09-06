using System.Drawing;

namespace Labb1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write a string of numbers and letter");

            PrintNumbersBetweenRepeatingNumbers(Console.ReadLine());
        }

        static void PrintNumbersBetweenRepeatingNumbers(string input)
        {
            List<ulong> numberGroupList = new List<ulong>();

            for (int i = 0; i < input.Length; i++)
            {
                if (!char.IsNumber(input[i]))
                {
                    continue;
                }

                for (int j = i+1; j < input.Length; j++)
                {
                    if (!char.IsNumber(input[j]))
                    {
                        break;
                    }

                    if (input[j] == input[i])
                    {
                        string currentNumberGroup = string.Empty;
                        bool isSameAsStartNumber = false;

                        for (int k = 0; k < input.Length; k++)
                        {
                            if(k >= i && k <= j && !isSameAsStartNumber)
                            {
                                currentNumberGroup += input[k];
                                Console.ForegroundColor = ConsoleColor.Red;

                                if (input[j] == input[k] && k > i)
                                {
                                    isSameAsStartNumber = true;
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Gray;
                            }

                            Console.Write(input[k]);
                        }

                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine();

                        ulong numberGroupULong;

                        bool success = UInt64.TryParse(currentNumberGroup, out numberGroupULong);
                        if(success)
                        {
                            numberGroupList.Add(numberGroupULong);
                        }
                        else
                        {
                            Console.WriteLine("Series of numbers is too big, try a different number");
                            for (int l = 0; l < numberGroupList.Count; l++)
                            {
                                Console.WriteLine(numberGroupList[i]);
                            }
                            return;
                        }
                        i++;
                    }
                }
            }

            Console.WriteLine($"The sum of the number groups in the string is {GetSumOfList(numberGroupList)}");
        }

        static ulong GetSumOfList(List<ulong> list)
        {
            ulong sumOfList = 0;

            for (int i = 0; i < list.Count; i++)
            {
                sumOfList += list[i];
            }

            return sumOfList;
        }

    }
}
