using System;
using System.IO;
using System.Linq;

namespace Lab_6_OOP
{
    public static class Task1
    {
        public static void Execute()
        {
            int sum = 0;
            int count = 0;

            using StreamWriter noFile = new StreamWriter("no_file.txt", false);
            using StreamWriter badData = new StreamWriter("bad_data.txt", false);
            using StreamWriter overFlow = new StreamWriter("overflow.txt", false);

            foreach (int i in Enumerable.Range(10, 20))
            {
                int value1 = 0;
                int value2 = 0;
                string fileName = $"{i}.txt";
                try
                {
                    string[] lines = File.ReadAllLines(fileName);

                    try
                    {
                        value1 = int.Parse(lines[0].Trim().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)[0]);
                        value2 = int.Parse(lines[1].Trim().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)[0]);
                    }
                    catch (OverflowException)
                    {
                        badData.WriteLine(fileName);
                        continue;
                    }

                    int product = checked(value1 * value2);

                    sum += product;
                    count++;

                }
                catch (FileNotFoundException)
                {
                    noFile.WriteLine(fileName);
                }
                catch (Exception ex) when (ex is FormatException || ex is IndexOutOfRangeException)
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
