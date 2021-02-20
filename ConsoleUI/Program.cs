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
            CarMamager carMamager = new CarMamager(new EfCarDal());
            foreach (var car in carMamager.GetAll())
            {
                Console.WriteLine(car.CarId+" "+ car.Description  + " "+ car.DailyPrice);
            }
            Console.WriteLine("-----------------------Filtreli arabalar----------------------------------------------------------------------");
            Console.WriteLine(" "); 

            
            
            foreach (var car in carMamager.GetAllByDailyPrice( 350 , 500))
            {
                Console.WriteLine(car.CarId + " " + car.Description + " " + car.DailyPrice);
            }
            Console.WriteLine("------------------------BrandId'si 2 olan arabalar-------------------------------------------------------------");
            Console.WriteLine(" ");

            foreach (var car in carMamager.GetAllByBrandId(2))
            {
                Console.WriteLine(car.BrandId + " " +car.CarId + " " + car.Description + " " + car.DailyPrice);
            }

            Console.WriteLine("-------------------------Markalar ve Idleri---------------------------------------------------------------------");
            Console.WriteLine(" ");

            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandId+" = "+ brand.BrandName);
            }
            Console.WriteLine("-------------------------renkler ve Id'leri----------------------------------------------------------------");
            Console.WriteLine(" ");

            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorId+ " "+ color.colorName);
            }

            Console.WriteLine("-------------------------Databesa'e araba eklemek----------------------------------------------------------------");
            Console.WriteLine(" ");

            carMamager.Add(new Car()
            {
                BrandId = 3,
                ColorId = 2,
                ModelYear = 2020,
                DailyPrice = 0,
                Description = "Manuel"
            });
           

        }
    }
}
