using System;


namespace LiveClinic02Example
{
    class Car
    {
        public void Run()
        {
            Console.WriteLine("자동차가 달립니다.");
        }

        public virtual void Refuel()
        {
            Console.WriteLine("급유합니다.");
        }
    }


    class ElectricCar : Car
    {
        public new void Run()
        {
            Console.WriteLine("전기차가 달립니다.");
        }

        public override void Refuel()
        {
            Console.WriteLine("충전합니다.");
        }
    }

}
