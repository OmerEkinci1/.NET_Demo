using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IInterpolationDal : IEntityRepository<Interpolation>
    {
        Interpolation GetByID(int id);
    }
}
