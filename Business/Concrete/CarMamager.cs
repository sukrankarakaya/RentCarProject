using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarMamager : ICarService
    {
        ICarDal _carDal;

        public CarMamager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetAllByBrandId(int id)
        {
            return _carDal.GetAll(c=> c.BrandId ==2);
        }

        public List<Car> GetAllByDailyPrice(decimal min, decimal max)
        {
            return _carDal.GetAll(c =>c.DailyPrice>= min && c.DailyPrice<= max);
        }

        public void Add(Car car)
        {
            using (RentCarContext context = new RentCarContext())
            {
                if (car.DailyPrice > 0 && context.Brands.SingleOrDefault(b => b.BrandId == car.BrandId).BrandName.Length > 2)
                {
                    _carDal.Add(car);
                    Console.WriteLine("Araba eklendi.");
                }
                else
                {
                    Console.WriteLine("ERROR!!!");

                }
            }
        }
        //public void Delete(Car car)
        //{
        //    using (RentCarContext context = new RentCarContext())
        //    {
        //        context.Cars.Remove(context.Cars.SingleOrDefault(c=> c.CarId == car.CarId));
        //        context.SaveChanges();
        //        Console.WriteLine("Araba silindi.");
        //    }
        //}
        public void Update(Car car)
        {
            using (RentCarContext context = new RentCarContext())
            {
                var carToUpdate = context.Cars.SingleOrDefault(c => c.CarId == car.CarId);
                carToUpdate.CarId = car.CarId;
                carToUpdate.BrandId = car.BrandId;
                carToUpdate.ColorId = car.ColorId;
                carToUpdate.DailyPrice = car.DailyPrice;
                carToUpdate.Description = car.Description;
                carToUpdate.ModelYear = car.ModelYear;
                context.SaveChanges();
            }
        }

        public List<Car> GetAllByColorId(int id)
        {
            return _carDal.GetAll(c => c.ColorId == id);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }
    }
}
