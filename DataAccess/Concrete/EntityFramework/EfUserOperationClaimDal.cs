using Core.DataAccess.EntityFramework;
using Core.Entity.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
   public class EfUserOperationClaimDal : EfEntityRepositoryBase <UserOperationClaim,RentCarContext> , IUserOperationClaimDal
    {
       
    }  
}
