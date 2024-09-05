using System.Drawing;

namespace Labb1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintNumbersBetweenRepeatingNumbers("29535123p48723487597645723645");
        }

        static void PrintNumbersBetweenRepeatingNumbers(string input)
        {
            List<long> numberGroupList = new List<long>();

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
                        bool isSameNumber = false;

                        for (int k = 0; k < input.Length; k++)
                        {
                            if(k >= i && k <= j && !isSameNumber)
                            {
                                currentNumberGroup += input[k];
                                Console.ForegroundColor = ConsoleColor.Red;

                                if (input[j] == input[k] && k > i)
                                {
                                    isSameNumber = true;
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Gray;
                            }

                            Console.Write(input[k]);
                        }

                        numberGroupList.Add(Int64.Parse(currentNumberGroup));
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine();
                        i++;
                    }
                }
            }

            Console.WriteLine($"The sum of the number groups in the string is {GetSumOfList(numberGroupList)}");
        }

        static long GetSumOfList(List<long> list)
        {
            long sumOfList = 0;

            for (int i = 0; i < list.Count; i++)
            {
                sumOfList += list[i];
            }

            return sumOfList;
        }

    }
}
