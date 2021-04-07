using core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace DataAccess.Concrete
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RentCarContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result =

                         from customer in context.Customers
                         join user in context.Users
                             on customer.UserId equals user.UserId
                         



                         select new CustomerDetailDto
                         {
                             UserId=user.UserId,
                             EMail=user.Email,
                             FirstName=user.FirstName,
                             LastName=user.LastName,
                             CustomerId=customer.CustomerId
                         };

                return result.ToList();

            }
        }
    }
}
