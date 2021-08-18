using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IInterpolationService
    {
        Task<IResult> Add(Integration interpolation, IFormFile file);
        Task<IResult> Delete(Integration interpolation);
        Task<IResult> Update(Integration interpolation, IFormFile file);
        IResult Send(IFormFile file);
        IDataResult<Integration> GetByID(int id);
        Task<IDataResult<IEnumerable<Integration>>> GetAll();
    }
}
