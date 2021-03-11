using Business;
using Business.Concrete;
using Business.Constants;
using DataAccess.Concrete;
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
            //CarTest();
            // BrandTest();
            // ColorTest();
            //UserTest();
            //CustomerTest();

            RentalTest();

        }

        private static void RentalTest()
        {
           RentalMenager rentalMenager = new RentalMenager(new EfRentalDal());
           Console.WriteLine( rentalMenager.Add(new Rental()
            {

                CarId = 5,
                CustomerId = 2,
                RentDate = DateTime.Now,
                ReturnDate = new DateTime(2021, 03, 06)


            }).Message);



            Console.WriteLine(" Id     CarId    CustomerId          RentDate                  ReturnDate");
            Console.WriteLine("----   -------  -------------       -------------            ----------------");
            
            foreach (var rental in rentalMenager.GetAll().Data)
            {
             Console.WriteLine(rental.RentalId + "    " + rental.CarId + "          " + rental.CustomerId + "               " + rental.RentDate + "       " + rental.ReturnDate);
            }






        }

        private static void CustomerTest()
        {
            CustomerMenager customerMenager = new CustomerMenager(new EfCustomerDal());
            customerMenager.Add(new Customer() { UserId = 1, CustomerId = 5, CompanyName = "Bayram İndirimi" });
            Console.WriteLine(Messages.CustomerAdd);
            foreach (var customer in customerMenager.GetAll().Data)
            {
                Console.WriteLine(Messages.CustomerList);
            }
        }

        //private static void UserTest()
        //{
        //    UserManager userManager = new UserManager(new EfUserDal());
        //    userManager.Add(new User()
        //    {
        //        FirstName = "ahmet",
        //        LastName = "Kaya",
        //        EMail = "Ahmet45@gmail",
        //       Password = "784"
        //    });
        //    Console.WriteLine(Messages.UderAdd);
        //    foreach (var user in userManager.GetAll().Data)
        //    {
        //        Console.WriteLine(user.FirstName+" "+ user.LastName+" "+user.EMail);
               
        //    }
        //    Console.WriteLine(Messages.UserList);
        //}

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
            CarManager carMamager = new CarManager(new EfCarDal());
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
                Console.WriteLine(car.CarName + " " + car.BrandName + " " + car.ColorName + " " + car.DailyPrice);
            }

        }
        

    } 
}
