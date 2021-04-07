using core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentCarContext>, IRentalDal
    {
            public List<RentalDateilDto> GetRentalDetails(Expression<Func<Rental, bool>> filter)
            {

                using (RentCarContext context = new RentCarContext())
                {
                    var result =
                             from rental in context.Rentals.Where(filter)
                             join customer in context.Customers
                              on rental.CustomerId equals customer.CustomerId
                             join user in context.Users
                                 on customer.UserId equals user.UserId
                             join car in context.Cars
                                 on rental.CarId equals car.CarId
                             join brand in context.Brands
                                 on car.BrandId equals brand.BrandId
                             join color in context.Colors
                             on car.ColorId equals color.ColorId

                             select new RentalDateilDto
                             {
                                 CarId=car.ColorId,
                                 CarName = brand.BrandName,
                                 FirstName = user.FirstName,
                                 LastName=user.LastName,
                                 Color=color.colorName,
                                 Description = car.Description,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear=car.ModelYear,
                                 RentDate=rental.RentDate,
                                 ReturnDate=rental.ReturnDate,
                                 CustomerId=customer.CustomerId
                                 
                             };

                     return result.ToList();

                }
            }
    }
}



