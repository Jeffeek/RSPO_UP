using System;
using System.Collections.Generic;
using System.Linq;
using RSPO_UP_15.Entities;
using RSPO_UP_15.Entities.Tasks;

namespace RSPO_UP_15
{
    /*
     * Служащий, персона, рабочий, инженер
     * Расширить иерархию классов из задания 1 с использованием
       абстрактного класса, содержащего виртуальные методы. Показать пример использования
       полиморфизма методов. Перегрузить все имеющиеся виртуальные методы класса.
     * Реализовать для иерархии из задания 2 механизм интерфейсов, при этом каждый из
       классов должен реализовывать как минимум 2 интерфейса. Использовать для
       демонстрации всех методов переменные-коллекции интерфейса.
     * Реализовать обработку исключений системных, в крайнем случае создать свой класс
	   исключений с полями(полезными) для задания 3
	   1) StackOverflowException
	   2) ArrayTypeMismatchException
	   3) DivideByZeroException
	   4) IndexOutOfRangeException
	   5) InvalidCastException
	   6) OutOfMemoryException
	   7) OverflowException.
     * Создать классы, состоящие из 15 рабочих и списка выполненных ими работ
	   за месяц. Необходимо найти среднее количество выполняемой ими работы за рабочую
       смену, учитывая возможность различного количества рабочих дней в месяце.
     * На основании задания 1 произвести эмуляцию процесса. Выделить самый
	   эффективный класс, самый не эффективный класс. Класс выполняющий большее
       количество работы. Объект просуществовавший меньше всего, самую долгоживущую
	   единицу.
     */

    internal class Program
    {
	    private static string[] _operations = new[]
	                                          {
                                                  "Какая-то операция_1",
                                                  "Какая-то операция_2",
                                                  "Какая-то операция_3",
                                                  "Какая-то операция_4",
                                                  "Какая-то операция_5",
                                                  "Какая-то операция_6",
                                                  "Какая-то операция_7",
                                                  "Какая-то операция_8",
                                                  "Какая-то операция_9",
                                                  "Какая-то операция_10",
                                                  "Какая-то операция_11",
                                                  "Какая-то операция_12",
                                                  "Какая-то операция_13",
                                                  "Какая-то операция_14",
                                                  "Какая-то операция_15",
                                                  "Какая-то операция_16",
                                                  "Какая-то операция_17",
                                                  "Какая-то операция_18",
                                                  "Какая-то операция_19",
                                                  "Какая-то операция_20",
                                              };

	    private static string[] _skills = new[]
	                                      {
		                                      "Какой-то скилл_1",
		                                      "Какой-то скилл_2",
		                                      "Какой-то скилл_3",
		                                      "Какой-то скилл_4",
		                                      "Какой-то скилл_5",
		                                      "Какой-то скилл_6",
		                                      "Какой-то скилл_7",
		                                      "Какой-то скилл_8",
		                                      "Какой-то скилл_9",
		                                      "Какой-то скилл_10",
		                                      "Какой-то скилл_11",
		                                      "Какой-то скилл_12",
		                                      "Какой-то скилл_13",
	                                      };

	    // TODO: доделать лабу, осталось два задания
        static void Main(string[] args)
        {
	        var jobs = CreateRandomJobs(100).ToList();
	        var stat = GetWorkersWithJobs(jobs);
        }

        private static DateTime CreateRandomDateTime(int minYear = 1970,
                                                     int maxYear = 2020,
                                                     int minMonth = 1,
                                                     int maxMonth = 12,
                                                     int minDay = 1,
                                                     int maxDay = 30)
        {
	        var random = new Random();
	        var year = random.Next(minYear, maxYear + 1);
	        var month = random.Next(minMonth, maxMonth + 1);
	        var day = random.Next(minDay, maxDay + 1);
	        return new DateTime(year, month, day);
        }

        private static Operation CreateRandomOperation()
        {
	        var random = new Random();
	        var operation = _operations[random.Next(0, _operations.Length)];
	        var startYear = random.Next(2000, DateTime.Now.Year + random.Next(0, 31));
	        var finishYear = random.Next(startYear, startYear + random.Next(0, 31));
	        var dateStart = CreateRandomDateTime(minYear: startYear, startYear + random.Next(0, 10));
	        var dateFinish = CreateRandomDateTime(startYear, finishYear);
	        return new Operation(operation, dateStart, dateFinish);
        }

        private static IEnumerable<Operation> CreateRandomOperations(int count = 10)
        {
	        for (var i = 0; i < count; i++)
		        yield return CreateRandomOperation();
        }

        private static IEnumerable<Job> CreateRandomJobs(int count = 10)
        {
	        for (var i = 0; i < count; i++)
		        yield return CreateRandomJob();
        }

        private static Job CreateRandomJob()
        {
	        var operations = CreateRandomOperations();
	        var worker = CreateRandomWorker();
	        return new Job(worker, operations);
        }

        private static Worker CreateRandomWorker() => new Engineer(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString())
                                                      {
	                                                      Skills = _skills.Where(x => x.Length % 5 )
                                                      };

        private static List<(Worker, List<Job>)> GetWorkersWithJobs(IEnumerable<Job> jobs)
        {
	        var array = jobs as Job[] ?? jobs.ToArray();
	        return array.Select(job =>
	                                  {
		                                  var enumerable = jobs as Job[] ?? array.ToArray();
		                                  return (job.Worker, enumerable.Where(x => x.Worker == job.Worker).ToList());
	                                  }).ToList();
        }
    }
}