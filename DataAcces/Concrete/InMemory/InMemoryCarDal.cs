using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _car;
        public InMemoryCarDal()
        {
            _car = new List<Car> { 
                new Car{CarId =1, BrandId=1 , ColorId= 1, ModelYear=2019,  Description="Manuel", DailyPrice=500},
                new Car{CarId =2, BrandId=1 , ColorId= 2, ModelYear=2020,  Description="Otomatik", DailyPrice=450},
                new Car{CarId =3, BrandId=2 , ColorId= 3, ModelYear=2018,  Description="Otomatik", DailyPrice=600},
                new Car{CarId =4, BrandId=3 , ColorId= 2, ModelYear=2016,  Description="Manuel", DailyPrice=700}
            };
        }
        public void Add(Car cars)
        {
            _car.Add(cars);
        }

        public void Delete(Car cars)
        {
            Car carToDelete = _car.SingleOrDefault(c => c.CarId == cars.CarId);

            _car.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllByBrandId(int brandId)
        {
            return _car.Where(c=> c.BrandId == brandId).ToList();
        }

        public void Update(Car cars)
        {
            Car carToDelete = _car.SingleOrDefault(c =>c.CarId== cars.CarId);
            carToDelete.BrandId = cars.BrandId;
            carToDelete.ColorId = cars.ColorId;
            carToDelete.DailyPrice = cars.DailyPrice;
            carToDelete.Description = cars.Description;        
        }
    }
}
