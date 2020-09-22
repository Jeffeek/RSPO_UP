using System;
using System.Linq;
using RSPO_UP_1.Locators;
using UP_1.Algorithms;

namespace RSPO_UP_1.Algorithms
{
    public class FileNameAlgo : IAlgo
    {
        public readonly char[] RestrictedChars = { '@', '$', '.', '*', '\\', '/', ':', '"', '<', '>', '|', '+', '%', '!' };
        public void Start()
        {
            if (int.TryParse(Console.ReadLine(), out int answer))
            {
                switch (answer)
                {
                    case 0:
                    {
                        return;
                    }

                    case 1:
                    {
                        Console.WriteLine($"Текущее имя файла: {FileSettings.Path}");
                        Console.WriteLine("Хотите поменять имя файла? \n 1. Да \n 2. Нет");
                        if (int.TryParse(Console.ReadLine(), out answer))
                        {
                            if (answer == 1)
                            {
                                Console.WriteLine("Введите имя файла(без расширения): ");
                                string newFileName = Console.ReadLine();
                                newFileName = GetRightFileName(newFileName);
                                FileSettings.Path = newFileName;
                            }
                        }

                        break;
                    }
                }
            }
            else
            {
                throw new Exception("Введена некорректная информация!");
            }
        }

        public bool IsRightName(string filename)
        {
            foreach (var ch in filename)
            {
                if (RestrictedChars.Contains(ch))
                {
                    return false;
                }
            }

            return true;
        }

        public string GetRightFileName(string file)
        {
            if (!String.IsNullOrWhiteSpace(file))
            {
                file = String.Join("", file.Where(x => !RestrictedChars.Contains(x)));
                if (file.Length > 0)
                    return file;
            }
            throw new ArgumentException(nameof(file));
        }
    }
}
