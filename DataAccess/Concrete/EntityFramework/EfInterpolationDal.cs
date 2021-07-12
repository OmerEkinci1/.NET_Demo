using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Abstract;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfInterpolationDal : EfEntityRepositoryBase<Interpolation, DatabaseContext>, IInterpolationDal
    {
        public Interpolation GetByID(int id)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var result = from i in db.Interpolations
                             where i.ID == id
                             select new Interpolation
                             {
                                 ID = i.ID,
                                 Text = i.Text,
                                 Picture = i.Picture
                             };

                return result.SingleOrDefault();
            }
        }
    }
}
