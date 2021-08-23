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
    public class IntegrationRepository : EfEntityRepositoryBase<Integration, ProjectDbContext>, IIntegrationRepository
    {
        public IntegrationRepository(ProjectDbContext context) : base(context)
        {

        }
        public async Task<Integration> GetByID(int id)
        {
            var single = await (from integration in Context.Integrations
                              where integration.ID == id
                              select new Integration()
                              {
                                  ID = integration.ID,
                                  INS_DT = integration.INS_DT,
                                  IS_PROCESSED = integration.IS_PROCESSED,
                                  JSON_TEXT = integration.JSON_TEXT,
                                  PICTURE = integration.PICTURE,
                                  PROCESSED_DT = integration.PROCESSED_DT,
                                  PRODUCT_TYPE = integration.PRODUCT_TYPE
                              }).FirstOrDefaultAsync();
            return single;
        }      
    }
}
