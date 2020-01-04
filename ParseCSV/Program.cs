using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ParseCSV
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = ProcessCSVFile("fuel.csv");
            var manufacturers = ProcessManufacturers("manufacturers.csv");

            var query = (from car in cars
                         where car.Manufacturer == "BMW"
                         orderby car.Combined descending, car.Name
                         select car);
            //query.ToList().ForEach(c => Console.WriteLine(c));

            var carManu = (from car in cars
                           join manufacturer in manufacturers
                           on car.Manufacturer equals manufacturer.Name
                           where manufacturer.Headquarters == "Germany"
                           orderby car.Combined descending, car.Name
                           select new
                           {
                               car,
                               manufacturer.Headquarters
                           }).Take(10);
            //carManu.ToList().ForEach(c => Console.WriteLine($"Headquarters {c.Headquarters} ,{c.car} ,"));


            var query1 = from car in cars
                         group car by car.Manufacturer into manufac
                         orderby manufac.Key
                         select new
                         {
                             Name = manufac.Key,
                             Max = manufac.Max(c => c.Combined),
                             Min = manufac.Min(c => c.Combined),
                             Avg = manufac.Average(c => c.Combined)
                         };

            query1.ToList().ForEach(c => Console.WriteLine($"{c.Name} : Max {c.Max}, Min {c.Min}, Avg {c.Avg}"));

            //foreach (var group in query1)
            //{
            //    Console.WriteLine(group.Key);
            //    foreach (var car in group)
            //    {
            //        Console.WriteLine($"\t {car}");
            //    }
            //}




















            //foreach (var group in grpQuery)
            //{
            //    Console.WriteLine($"{group.Key} Count {group.Count()}");
            //    foreach (var item in group)
            //    {
            //        Console.WriteLine($"\t {item.car}");
            //    }
            //}



            Console.Read();
        }

        private static IEnumerable<Car> ProcessCSVFile(string path)
        {
            var query = File.ReadAllLines(path)
                .Skip(1)
                .Where(line => line.Length > 0)
                .Select(Car.ParseCsvLineToCar);

            var linqQuery = from car in File.ReadAllLines(path).Skip(1)
                            where car.Length > 0
                            select Car.ParseCsvLineToCar(car);

            return linqQuery;
        }
        private static List<Manufacturer> ProcessManufacturers(string path)
        {
            var query =
                   File.ReadAllLines(path)
                       .Where(l => l.Length > 1)
                       .Select(l =>
                       {
                           var columns = l.Split(',');
                           return new Manufacturer
                           {
                               Name = columns[0],
                               Headquarters = columns[1],
                               Year = int.Parse(columns[2])
                           };
                       });
            return query.ToList();
        }
    }
}
