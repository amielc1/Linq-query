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

            var query = personsList.Where(p => p.Gender == Gender.Male);

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
