using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Abstract;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using System.Linq;
using Microsoft.AspNetCore.Http;
using DataAccess.Concrete.EntityFramework.Contexts;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfInterpolationDal : EfEntityRepositoryBase<Interpolation, ProjectDbContext>, IInterpolationDal
    {
        public EfInterpolationDal(ProjectDbContext context) : base(context)
        {

        }
        public async Task<Interpolation> GetByID(int id)
        {
            var single = await (from interpolation in Context.Interpolations
                              where interpolation.ID == id
                              select new Interpolation()
                              {
                                  ID = interpolation.ID,
                                  ImagePath = interpolation.ImagePath,
                                  ClassName = interpolation.ClassName
                              }).FirstOrDefaultAsync();
            return single;
        }      
    }
}
