using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text.Json;
using RSPO_UP_14.Second_Task.Models;
using RSPO_UP_14.Third_Task.Models;

namespace RSPO_UP_14
{
	internal class Program
    {
	    private static void Main(string[] args)
        {
            //FirstTask();
            SecondTask();
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
	        var formatter = new DataContractJsonSerializer(typeof(List<Fact>), new DataContractJsonSerializerSettings()
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
    }
}
