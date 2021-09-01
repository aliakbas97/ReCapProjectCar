using Business.Abstract;
using Business.Constants;
using Core.DataAccess.Results;
using Core.DataAccess.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
   public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessfullResult(Messages.CustomerAdded);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessfullResult(Messages.CustomerDeleted);
        }
        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessfullResult(Messages.CustomerUpdated);

        }


        public IDataResult<List<Customer>> GetCustomerByUserId(int id)
        {
            return new SuccessfullDataResult<List<Customer>>(_customerDal.GetAll(p => p.UserId == id), Messages.CustomerGet);
        }
    }
}
