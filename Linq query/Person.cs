using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_query
{
    public enum Gender
    {
        Male,
        Female
    }
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        private Gender _Gender;
        public Gender Gender
        {
            get
            {
                Console.WriteLine($"Enter to Person {Name} Gender {_Gender}");
                return _Gender;
            }
            set { _Gender = value; }
        }

        public override string ToString() => $"Person {Name}, Age {Age}, Gender {_Gender}";
    }
}
