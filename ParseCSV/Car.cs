using System;

namespace ParseCSV
{
    public class Car
    {
        public int Year { get; set; }
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public double Displacement { get; set; }
        public int Cylinders { get; set; }
        public int City { get; set; }
        public int Highway { get; set; }
        public int Combined { get; set; }
        public override string ToString() => $"Manufacturer {Manufacturer},\t Combined {Combined}, \t Name : {Name}";

        internal static Car ParseCsvLineToCar(string line)
        {
            //Model Year,Division,Carline,Eng Displ,# Cyl,City FE,Hwy FE,Comb FE
            //2016,Volkswagen,Touareg,3.6,6,17,23,19
            var car = new Car();
            var carLine = line.Split(',');
            car.Year = Convert.ToInt32(carLine[0]);
            car.Manufacturer = carLine[1];
            car.Name = carLine[2];
            car.Displacement = Convert.ToDouble(carLine[3]);
            car.Cylinders = Convert.ToInt32(carLine[4]);
            car.City = Convert.ToInt32(carLine[5]);
            car.Highway = Convert.ToInt32(carLine[6]);
            car.Combined = Convert.ToInt32(carLine[7]);
            return car;
        }
    }
}
