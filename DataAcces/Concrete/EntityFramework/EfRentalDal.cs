using core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentCarContext>, IRentalDal
    {
            public List<RentalDateilDto> GetRentalDetails()
            {

                using (RentCarContext context = new RentCarContext())
                {
                var result =
                         from rental in context.Rentals
                         join customer in context.Customers
                          on rental.CustomerId equals customer.CustomerId
                         join user in context.Users
                             on customer.UserId equals user.UserId
                         join car in context.Cars
                             on rental.CarId equals car.CarId
                         join brand in context.Brands
                             on car.BrandId equals brand.BrandId

                         select new RentalDateilDto
                         {
                             CarName = brand.BrandName,
                             FirstName = user.FirstName,
                             LastName=user.LastName,
                             RentDate=rental.RentDate,
                             ReturnDate=rental.ReturnDate
                         };

                return result.ToList();

            }
            }
    }
}



