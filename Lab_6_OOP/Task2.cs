using System;
using System.IO;
using System.Text.RegularExpressions;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace Lab_6_OOP
{
    public static class Task2
    {
        public static void Execute()
        {
            string dir = Directory.GetCurrentDirectory();
            string[] files = Directory.GetFiles(dir);

            Regex regexExt = new Regex(@"\.(bmp|gif|tiff?|jpe?g|png)$", RegexOptions.IgnoreCase);

            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);

                try
                {
                    using (Image image = Image.Load(file))
                    {
                        image.Mutate(x => x.Flip(FlipMode.Vertical));

                        string nameOnly = Path.GetFileNameWithoutExtension(fileName);
                        string newName = Path.Combine(dir, nameOnly + "-mirrored.gif");

                        image.SaveAsGif(newName);
                        Console.WriteLine($"Файл оброблено: {fileName} -> {Path.GetFileName(newName)}");
                    }
                }
                catch (Exception)
                {
                    try
                    {
                        string ext = Path.GetExtension(fileName);

                        if (regexExt.IsMatch(ext))
                        {
                            Console.WriteLine($"Не вдалося обробити файл зображення: {fileName}");
                        }
                    }
                    catch {}
                }                
            }
        }
    }
}