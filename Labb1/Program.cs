using System.Drawing;

namespace Labb1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintNumbersBetweenRepeatingNumbers("313a3544546746");
        }

        static void PrintNumbersBetweenRepeatingNumbers(string input)
        {
            List<int> numberGroupList = new List<int>();

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

                        for (int k = 0; k < input.Length; k++)
                        {
                            if(k >= i && k <= j)
                            {
                                currentNumberGroup += input[k];
                                Console.ForegroundColor = ConsoleColor.Red;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Gray;
                            }
                            Console.Write(input[k]);
                        }

                        numberGroupList.Add(Int32.Parse(currentNumberGroup));
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine();
                        i++;
                    }
                }
            }
            for (int i = 0; i < numberGroupList.Count; i++)
            {
                Console.WriteLine(numberGroupList[i]);
            }
        }
    }
}
