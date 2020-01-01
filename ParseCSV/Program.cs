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

            var carsQuery = from car in cars
                            where car.Manufacturer == "BMW"
                            orderby car.Combined descending, car.Name
                            select car;
            //carsQuery.ToList().ForEach(c => Console.WriteLine(c));

            var manuCars = (from car in cars
                            join manufacturer in manufacturers
                            on car.Manufacturer equals manufacturer.Name
                            where manufacturer.Headquarters == "Germany"
                            orderby car.Combined descending, car.Name
                            select new
                            {
                                car,
                                manufacturer.Headquarters
                            }).Take(10);
            //manuCars.ToList().ForEach(mc => Console.WriteLine( $"Car {mc.car} ,Headquarters {mc.Headquarters}"));
            var carGroups = from car in manuCars
                            group car by car.car.Manufacturer;
            foreach (var group in carGroups)
            {
                Console.WriteLine($"{group.Key} Count {group.Count()}");
                foreach (var item in group.OrderByDescending(c => c.car.Combined))
                {
                    Console.WriteLine($"\t {item.car.Name} , {item.car.Combined}");
                }
            }


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
