#region Using derectives

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text.Json;
using RSPO_UP_14.FifthTask;
using RSPO_UP_14.FifthTask.ConcreteFactories;
using RSPO_UP_14.FifthTask.ConcreteProducts;
using RSPO_UP_14.Second_Task.Models;
using RSPO_UP_14.Third_Task.Models;

#endregion

namespace RSPO_UP_14
{
    /*
     * ИЗДЕЛИЕ: название, шифр, количество, комплектация.
     * 1. Даны названия 26 городов и стран, в которых они находятся. Среди них есть
        города, находящиеся в Италии. Напечатать их названия в алфавитном порядке.
        2. Даны даты каждого из 20 событий, произошедших после 1930 года: год, номер месяца и
        число. Составить программу, сравнивающую два любых события по времени (определяющую,
        какое из событий произошло позже). Событие может быть представлено:
        а) условным порядковым номером;
        б) в виде текста. (реализовать через 2 индексатора по индексу и оп названию события)
        3. Реализуйте интерфейс, c свойствами LastName, FirstName и методом Print
        4. Создать коллекцию объектов из варианта и реализовать обход коллекции через
        IEnumerable ходит по элементам чей индекс кратен 3м.
     * Для классов из задание 1 написать фабрику, которая принимает в метод создания
        объекта конкретную фабрику приведенную к интерфейсу с методом T
        CreateInstance&lt;T&gt; where T : Ваш супер класс.(1б)
        Задача конкретной фабрики в одном стиле инициализировать экземпляр класса.
        Добавить 2 конкретные фабрики.(1б)
     */
    internal class Program
    {
        private static void Main(string[] args)
        {
            //FirstTask();
            //SecondTask();
            FifthTask();
        }

        private static void FirstTask()
        {
            var filePath = $"{Directory.GetCurrentDirectory()}\\countries.json";
            var countries = JsonSerializer.Deserialize<List<Country>>(File.ReadAllText(filePath));
            var italy = countries.First(x => x.Name == "Italy");
            var italyCities = italy.Cities.OrderBy(x => x.Name);
            Console.WriteLine("Города Италии: ");

            foreach (var city in italyCities)
                Console.WriteLine(city.Name);
        }

        private static void SecondTask()
        {
            var filePath = $"{Directory.GetCurrentDirectory()}\\facts.json";
            using var fs = new FileStream(filePath, FileMode.Open);

            var formatter = new DataContractJsonSerializer(typeof(List<Fact>), new DataContractJsonSerializerSettings
                                                                               {
                                                                                       DateTimeFormat = new DateTimeFormat("yyyy-MM-dd")
                                                                               });

            var facts = formatter.ReadObject(fs) as List<Fact>;
            var explorer = new FactsExplorer(facts);
            var factByIndex = explorer[5];

            var factByText = explorer["Вступление частей Красной Армии на территорию Финляндии. Начало советско-финляндской («зимней») войны."];
            var compareResult = factByText < factByIndex;
            Console.WriteLine($"Первое событие: {factByIndex}{Environment.NewLine}Второе событие: {factByText}");
            Console.WriteLine($"Первое событие 'больше' второго: {compareResult}");
        }

        private static void FifthTask()
        {
            IProductFactory appleFactory = new AppleFactory();
            var apple = appleFactory.CreateInstance();
            IProductFactory bananaFactory = new BananaFactory();
            var banana = bananaFactory.CreateInstance();
        }
    }
}