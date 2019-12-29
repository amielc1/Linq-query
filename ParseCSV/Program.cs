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
            cars.Take(10).
                ToList().
                ForEach(car => Console.WriteLine($"Car Name : {car.Name} , Year {car.Year}"));

            Console.ReadLine();
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
    }
}
