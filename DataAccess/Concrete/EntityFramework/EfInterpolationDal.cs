using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Abstract;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfInterpolationDal : EfEntityRepositoryBase<Interpolation, MsDbContext>, IInterpolationDal
    {
        public Interpolation GetByID(int id)
        {
            using (MsDbContext db = new MsDbContext())
            {
                var result = from i in db.Interpolations
                             where i.ID == id
                             select new Interpolation
                             {
                                 ID = i.ID,
                                 ImagePath = i.ImagePath,
                                 ClassName = i.ClassName,
                             };

                return result.SingleOrDefault();
            }
        }
    }
}
