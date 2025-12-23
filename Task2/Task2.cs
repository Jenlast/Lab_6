using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

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
                    using (Bitmap bitmap = new Bitmap(file))
                    {
                        bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);

                        string nameOnly = Path.GetFileNameWithoutExtension(fileName);
                        string newName = Path.Combine(dir, nameOnly + "-mirrored.gif");

                        bitmap.Save(newName, ImageFormat.Gif);
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