using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();

        //bool UpdatedAuthority(Car car);

        bool YetkisiVarMı(bool yetki);

        void Add(Car car);

    }
}
