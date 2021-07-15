using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IInterpolationService
    {
        IResult Add(Interpolation interpolation, IFormFile file);
        IResult Delete(Interpolation interpolation);
        IResult Update(Interpolation interpolation, IFormFile file);
        IResult Send(IFormFile file);
        IDataResult<Interpolation> GetByID(int id);
        IDataResult<List<Interpolation>> GetAll();
    }
}
