using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, RentCarContext>, IUserDal
    {
        public List<UserDetailDto> GetUserDetails()
        {
            using (RentCarContext carContext = new RentCarContext())
            {
                var results = from u in carContext.Users
                              join c in carContext.Customers
                              on u.Id equals c.UserId
                              select new UserDetailDto { FirstName = u.FirstName, LastName = u.LastName, Email = u.Email, Password = u.Password, CompanyName = c.CompanyName };

                return results.ToList();

                     
            }
        }
    }
}


	
    


