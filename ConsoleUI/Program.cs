using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarTest();

           // BrandTest();

           // ColorTest();

        }

        private static void ColorTest()
        {
            Console.WriteLine("-------------------------renkler ve Id'leri----------------------------------------------------------------");
            Console.WriteLine(" ");

            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorId + " " + color.colorName);
            }
        }

        private static void BrandTest()
        {
            Console.WriteLine("-------------------------Markalar ve Idleri---------------------------------------------------------------------");
            Console.WriteLine(" ");

            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandId + " = " + brand.BrandName);
            }
        }

        private static void CarTest()
        {
            CarMamager carMamager = new CarMamager(new EfCarDal());
            foreach (var car in carMamager.GetAll().Data)
            {
                Console.WriteLine(car.CarId + " " + car.Description + " " + car.DailyPrice);
            }
            Console.WriteLine(" ");



            foreach (var car in carMamager.GetAllByDailyPrice(350, 500).Data)
            {
                Console.WriteLine(car.CarId + " " + car.Description + " " + car.DailyPrice);
            }
            Console.WriteLine("------------------------BrandId'si 2 olan arabalar-------------------------------------------------------------");
            Console.WriteLine(" ");

            foreach (var car in carMamager.GetAllByBrandId(2).Data)
            {
                Console.WriteLine(car.BrandId + " " + car.CarId + " " + car.Description + " " + car.DailyPrice);
            }

            Console.WriteLine("-------------------------Databesa'e araba eklemek----------------------------------------------------------------");
            Console.WriteLine(" ");

            carMamager.Add(new Car()
            {
                BrandId = 4,
                ColorId = 1,
                ModelYear = 2016,
                DailyPrice = 300,
                Description = "Manuel"

            });
      
            Console.WriteLine("------------------------------------9. dersin çıktısı--------------------------------------------------------------");
            Console.WriteLine(" ");

            foreach (var car in carMamager.GetCarDetails().Data)
            {
                Console.WriteLine(car.CarName +" "+car.BrandName + " " + car.ColorName + " " + car.DailyPrice);
            }

        }
       
    }
}
