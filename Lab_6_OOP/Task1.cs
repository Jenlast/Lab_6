using System;
using System.IO;
using System.Linq;

namespace Lab_6_OOP
{
    public static class Task1
    {
        public static void Execute()
        {
            long sum = 0;
            int count = 0;

            using StreamWriter noFile = new StreamWriter("no_file.txt", false);
            using StreamWriter badData = new StreamWriter("bad_data.txt", false);
            using StreamWriter overFlow = new StreamWriter("overflow.txt", false);

            foreach (int i in Enumerable.Range(10, 20))
            {
                string fileName = $"{i}.txt";
                try
                {
                    string[] lines = File.ReadAllLines(fileName);

                    int value1 = int.Parse(lines[0].Trim().Split()[0]);
                    int value2 = int.Parse(lines[1].Trim().Split()[0]);

                    int product = value1 * value2;

                    sum += product;
                    count++;

                }
                catch (FileNotFoundException)
                {
                    noFile.WriteLine(fileName);
                }
                catch (FormatException)
                {
                    badData.WriteLine(fileName);
                }
                catch (OverflowException)
                {
                    overFlow.WriteLine(fileName);
                }     
            }
            
            try
            {
                double average = (double)sum / count;
                Console.WriteLine($"Середнє значення: {average}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Не вдалося обчислити середнє значення через відсутність коректних даних.");
            }
        }
    }
}
