using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text.RegularExpressions;

namespace RSPO_UP_19
{
    /*
     * 1. Сформировать файл из значений случайных величин:
       0,324; 0,524; 0,789; 0,556; 0,761; 0,248; 0,345; 0,911; 0,216, // +
       Определить для данной последовательности среднее арифметическое компонентов,
       значения которых меньше 0,5. // +
     * 2. Разбить произвольный текст, находящийся в файле, на строки определенной
       длины. При переносе слова предусмотреть вывод дефиса. // +
     * 3. Сформировать файл целых чисел. Вывести на экран только четные значения
       компонентов файла. // +
     * 4. Из текста, расположенного в файле, исключить группы символов,
       расположенных между круглыми скобками. // +
     */

    internal static class Program
    {
        #region FirstTaskFields

        private static readonly string _firstTaskFilePath = $"{Directory.GetCurrentDirectory()}\\firstTaskIO_Nums.txt";

        private static readonly double[] _firstTaskNumbers =
        {
            0.324, 0.524, 0.789, 0.556, 0.761, 0.248, 0.345, 0.911, 0.216
        };

        #endregion

        #region SecondTaskFields

        private static readonly string _secondTaskRandomText = $"sfsdfsdf fdsdfsdfsdfsdfsdf sdfhrfjyuj jdf jsl{Environment.NewLine}kdnfj ns jsdnf jnsdfj n jsdn jsnd{Environment.NewLine}fjnsd sd djndjsn sjdfns{Environment.NewLine}jdfnjsdn sdf fsdffsndf";

        private static readonly string _secondTaskFilePath = $"{Directory.GetCurrentDirectory()}\\secondTask_randomText.txt";

        #endregion

        #region ThirdTaskFields

        private static readonly Random _random = new Random();

        private static readonly int[] _thirdTaskRandomNumbers = Enumerable.Range(0, 100)
                                                                          .Select(x => _random.Next(-1000, 1000))
                                                                          .ToArray();

        private static readonly string _thirdTaskFilePath = $"{Directory.GetCurrentDirectory()}\\thirdTask_Numbers.txt";

        #endregion

        #region FourthTaskFields

        private static readonly string _fourthTaskTextWithBrackets = "sdf sdfsdf(sdf),,sd()slokl(sdggsd);sd,42sadf2(sdf)f";

        private static readonly string _fourthTaskFilePath = $"{Directory.GetCurrentDirectory()}\\fourthTask_TextWithBrackets.txt";

        #endregion

        static void Main(string[] args)
        {
            #region First

            Console.WriteLine($"{new String('-', 10)} FirstTask {new String('-', 10)}");
            InitializeFile();
            CalculateAndPrint();

            #endregion

            #region Second

            Console.WriteLine($"{new String('-', 10)} SecondTask {new String('-', 10)}");
            WriteRandomTextToFile();
            DoSecondTaskWork();

            #endregion

            #region Third

            Console.WriteLine($"{new String('-', 10)} ThirdTask {new String('-', 10)}");
            WriteRandomNumbersToFile();
            ReadAndWriteOnlyEvenNumbers();

            #endregion

            #region Fourth

            Console.WriteLine($"{new String('-', 10)} FourthTask {new String('-', 10)}");
            InitializeFileWithTextWithBrackets();
            RemoveAllTextBetweenBracketsAndPrint();

            #endregion
        }

        #region FirstTask

        private static void InitializeFile()
        {
            var textToWrite = String.Join(' ', _firstTaskNumbers);
            File.WriteAllText(_firstTaskFilePath, textToWrite);
        }

        private static double[] ReadNumbersReadFromFile() =>
            File.ReadAllText(_firstTaskFilePath)
                .Split()
                .Select(Double.Parse)
                .ToArray();

        private static void CalculateAndPrint()
        {
            var numbers = ReadNumbersReadFromFile();
            var avg = numbers.Where(x => x > 0.5).Average();
            Console.WriteLine($"Average of numbers {avg}");
        }

        #endregion

        #region SecondTask

        private static void WriteRandomTextToFile() => 
            File.WriteAllText(_secondTaskFilePath, _secondTaskRandomText);

        private static string ReadAllTextFromFile() => File.ReadAllText(_secondTaskFilePath);

        private static void DoSecondTaskWork()
        {
            var text = ReadAllTextFromFile();
            var lastIndex = 0;

            foreach (Match m in Regex.Matches(text, @".{5}"))
            {
                Console.WriteLine($"{m.Value} - {m.Value.Length}");
                lastIndex = m.Index + m.Value.Length;
            }

            if (text.Length - lastIndex > 0)
                Console.WriteLine(text[lastIndex..]);
        }

        #endregion

        #region ThirdTask

        private static void WriteRandomNumbersToFile()
        {
            var textToWrite = String.Join(' ', _thirdTaskRandomNumbers);
            File.WriteAllText(_thirdTaskFilePath, textToWrite);
        }

        private static int[] ReadRandomNumbersFromFile() =>
            File.ReadAllText(_thirdTaskFilePath)
                .Split()
                .Select(Int32.Parse)
                .ToArray();

        private static void ReadAndWriteOnlyEvenNumbers()
        {
            var numbers = ReadRandomNumbersFromFile();
            var textToPrint = String.Join(Environment.NewLine, numbers.Where(x => x % 2 == 0));
            Console.WriteLine(textToPrint);
        }

        #endregion

        #region FourthTask

        private static void InitializeFileWithTextWithBrackets() => File.WriteAllText(_fourthTaskFilePath, _fourthTaskTextWithBrackets);

        private static string ReadTextWithBracketsFromFile() => File.ReadAllText(_fourthTaskFilePath);

        private static void RemoveAllTextBetweenBracketsAndPrint()
        {
            var initialText = ReadTextWithBracketsFromFile();
            Console.WriteLine($"Initial text: {initialText}");
            var pattern = new Regex("\\(\\w*\\)");
            var newText =  pattern.Replace(initialText, String.Empty);
            Console.WriteLine($"New text: {newText}");
        }

        #endregion
    }
}