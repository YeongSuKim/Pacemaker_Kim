using System;
using System.Collections.Generic;


namespace LiveClinic02Example
{
    class Program
    {
        static void Main(string[] args)
        {

            Car carA = new Car();
            Car carB = new ElectricCar();
            ElectricCar carC = new ElectricCar();

            carA.Run();
            carB.Run();
            carC.Run();

            Console.WriteLine();

            carA.Refuel();
            carB.Refuel();
            carC.Refuel();


            Console.WriteLine();
            Console.WriteLine();


            List<Car> carList = new List<Car>();

            carList.Add(new Car());
            carList.Add(new ElectricCar());
            carList.Add(new Car());

            foreach (Car car in carList)
            {
                car.Run();
                car.Refuel();

                Console.WriteLine();
            }
        }
    }
}
