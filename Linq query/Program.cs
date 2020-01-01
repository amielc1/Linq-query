using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq_query
{
    class Program
    {
        static void Main(string[] args)
        {
            var personsList = new List<Person>()
            {
                new Person(){ Name= "Amiel", Age = 30 , Gender = Gender.Male},
                new Person(){ Name= "Tal", Age = 20 , Gender = Gender.Female},
                new Person(){ Name= "Reut", Age =13, Gender = Gender.Female},
                new Person(){ Name= "Shalom", Age = 24, Gender = Gender.Male},
                new Person(){ Name= "Yoav", Age = 37 , Gender = Gender.Male},
            };

            //1.Deferred execution 
            // select, where, Take, Skip
            //2. Immediate execution. 
            //count, average, min, max, ToList etc

            var query = personsList.Where(p => p.Gender == Gender.Male);//ToList();

            personsList.Add(new Person() { Name = "Yosef", Age = 87, Gender = Gender.Male });

            //query.ToList().ForEach(p => Console.WriteLine(p));

            foreach (var person in query)
            {
                Console.WriteLine(person);
            }

            Console.WriteLine("Program End!");
            Console.Read();
        }

    }
}


//static void Main(string[] args)
//{
//    var cars = ProcessCars("fuel.csv");
//    var manufacturers = ProcessManufacturers("manufacturers.csv");

//    //OrderBy 
//    var query = from car in cars
//                where car.Manufacturer == "BMW" && car.Year == 2016 &&
//                (car.Combined == 23 || car.Combined == 22)
//                orderby car.Combined descending//, car.Name ascending
//                select car;

//    var exQuery = cars.Where(car =>
//        car.Manufacturer == "BMW" && car.Year == 2016 &&
//        (car.Combined == 23 || car.Combined == 22))
//    .OrderByDescending(car => car.Combined)
//    .ThenBy(car => car.Name);
//    //exQuery.ToList().ForEach(car => Console.WriteLine(car));
//    //

//    var BmwCars = query.ToList();
//    var joinQuery =
//        from car in BmwCars
//        join manufacturer in manufacturers on
//        car.Manufacturer equals manufacturer.Name
//        orderby car.Combined descending, car.Name
//        select new
//        {
//            car,
//            manufacturer.Headquarters
//        };
//    var res = joinQuery.ToList();
//    //res.ForEach(i => Console.WriteLine($"{i.Headquarters}, {i.car}"));
//    //


//    var germanyCars = from car in cars
//                      join man in manufacturers
//                      on car.Manufacturer equals man.Name
//                      where man.Headquarters == "Germany"
//                      orderby car.Combined descending, man.Name, car.Name
//                      select new
//                      {
//                          car,
//                          man.Headquarters
//                      };
//    germanyCars.Take(10).ToList().ForEach(i => Console.WriteLine($"{i.Headquarters} {i.car}"));

//    Console.WriteLine("$$$$");

//    var Top3 = germanyCars.Take(10).ToList();
//    var x = from car in Top3
//            group car by car.car.Manufacturer;
//    //x.ToList().ForEach(grp => Console.WriteLine($"{grp.Key} , {grp.Count()}"));
//    foreach (var group in x)
//    {
//        Console.WriteLine($"=> {group.Key}");
//        foreach (var innerg in group.OrderByDescending(c => c.car.Combined))
//        {
//            Console.WriteLine($"\t {innerg.car.Name} , {innerg.car.Combined}");
//        }
//    }
//    Console.Read();
//}
