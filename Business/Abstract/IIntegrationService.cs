using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IIntegrationService
    {
        Task<IResult> Add(Integration interpolation);
        Task<IResult> Delete(Integration interpolation);
        Task<IResult> Update(Integration interpolation);
        IDataResult<Integration> GetByID(int id);
        Task<IDataResult<IEnumerable<Integration>>> GetAll();
    }
}
