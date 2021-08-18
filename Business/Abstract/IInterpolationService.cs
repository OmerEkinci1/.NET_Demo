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
        Task<IResult> Add(Interpolation interpolation, IFormFile file);
        Task<IResult> Delete(Interpolation interpolation);
        Task<IResult> Update(Interpolation interpolation, IFormFile file);
        IResult Send(IFormFile file);
        IDataResult<Interpolation> GetByID(int id);
        Task<IDataResult<IEnumerable<Interpolation>>> GetAll();
    }
}
