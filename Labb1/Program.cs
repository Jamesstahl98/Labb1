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
            Console.ReadLine();
        }

        static void PrintNumbersBetweenRepeatingNumbers(string input)
        {
            List<UInt128> numberGroupList = new List<UInt128>();

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

                        Console.Write(input.Substring(0, i));

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(currentNumberGroup);

                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write(input.Substring(j+1));

                        Console.WriteLine();

                        UInt128 numberGroupUInt = UInt128.Parse(currentNumberGroup);
                        numberGroupList.Add(numberGroupUInt);

                        break;
                    }
                }
            }

            Console.WriteLine($"The sum of the number groups in the string is {GetSumOfList(numberGroupList)}");
        }

        static UInt128 GetSumOfList(List<UInt128> list)
        {
            UInt128 sumOfList = 0;

            for (int i = 0; i < list.Count; i++)
            {
                sumOfList += list[i];
            }

            return sumOfList;
        }

    }
}
