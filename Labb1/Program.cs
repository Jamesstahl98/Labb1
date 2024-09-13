namespace Labb1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool complete = false;
            Console.WriteLine("Write a string of numbers and letter");
            while (!complete)
            {
                try
                {
                    PrintNumbersBetweenRepeatingNumbers(Console.ReadLine());
                    complete = true;
                }

                catch(OverflowException)
                {
                    Console.Clear();
                    Console.WriteLine("Series of numbers is too big, try writing a different string");
                }
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        static void PrintNumbersBetweenRepeatingNumbers(string input)
        {
            UInt128 sum = 0;
            Console.Clear();

            for (int i = 0; i < input.Length; i++)
            {
                if (!char.IsNumber(input[i]))
                {
                    continue;
                }

                for (int j = i + 1; j < input.Length; j++)
                {
                    if (!char.IsNumber(input[j]))
                    {
                        break;
                    }

                    if (input[i] == input[j])
                    {
                        string currentNumberGroup = input.Substring(i, j-i+1);

                        PrintNumberString(i, j+1, currentNumberGroup, input);

                        UInt128 numberGroupUInt = UInt128.Parse(currentNumberGroup);
                        sum += numberGroupUInt;

                        break;
                    }
                }
            }

            Console.WriteLine($"The sum of the number groups in the string is {sum}");
        }

        static void PrintNumberString(int startIndex, int stopIndex, string numberGroup, string input)
        {
            Console.Write(input.Substring(0, startIndex));

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(numberGroup);

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(input.Substring(stopIndex));
        }
    }
}
