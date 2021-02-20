using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RSPO_UP_17.Cnsl
{
    /*
     * 3. Создать консольное приложение. В нем два потока обращаются к
       одному и тому же объекту. Метод этого объекта распечатывает внутренний
       массив объекта и имя потока, для которого производится печать. Обеспечить
       синхронизацию работы потоков.
       4. Создать два потока. Первый поток производит запись в файл
       случайных данных. Второй производит чтение этих данных из этого файла и
       выводит их на экран.
     */

    class Program
    {
        private static object _syncObject = new object();

        static void Main(string[] args)
        {
            //SecondTask();
            //FirstTask();
        }

        static void FirstTask()
        {
            var random = new Random();
            var array = Enumerable.Range(0, 10).Select(x => random.Next(0, 10)).ToArray();

            var threads = Enumerable.Range(0, 100).Select(x => new Thread(PrintArray));

            //Parallel.ForEach(threads, thread => thread.Start(array));

            foreach (var thread in threads)
                thread.Start(array);
        }

        static void PrintArray(object array)
        {
            lock (_syncObject)
            {
                Console.WriteLine($"Thread: {Thread.CurrentThread.ManagedThreadId}\tResult: {String.Join(" ", (int[])array)}");
            }
        }

        static void SecondTask()
        {
            File.WriteAllText($"{Directory.GetCurrentDirectory()}\\textFile.txt", String.Empty);
            var writeThread = new Thread(WriteToFile);
            var readThread = new Thread(ReadFromFile);
            writeThread.Start();
            readThread.Start();
        }

        static void WriteToFile()
        {
            var random = new Random();
            var text = "";
            for (var i = 0; i < 1000; i++)
            {
                text += (char)random.Next(0, 200);
                lock (_syncObject)
                {
                    File.WriteAllText($"{Directory.GetCurrentDirectory()}\\textFile.txt", text);
                }
            }
        }

        static void ReadFromFile()
        {
            for (var i = 0; i < 1000; i++)
            {
                var text = "";
                lock (_syncObject)
                {
                    text = File.ReadAllText($"{Directory.GetCurrentDirectory()}\\textFile.txt");
                }

                Console.WriteLine(text.Length);
            }
        }
    }
}
