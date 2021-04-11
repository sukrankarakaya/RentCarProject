using Core.Utilities.Results;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);
        IDataResult<List<User>> GetAll();
        IDataResult<List<User>> GetByUserId(int userId);

        IDataResult<User> GetByMail(string email);
        List<OperationClaim> GetClaims(User user);
    
    
    
    
    }
}
