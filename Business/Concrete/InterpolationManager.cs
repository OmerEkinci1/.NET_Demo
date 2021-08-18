using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Performance;
using Core.Aspects.Transaction;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class InterpolationManager : IInterpolationService
    {
        //    private IIntegrationDal _interpolationDal;

        //    public InterpolationManager(IIntegrationDal interpolationDal)
        //    {
        //        _interpolationDal = interpolationDal;
        //    }

        //    [TransactionScopeAspect]
        //    [LogAspect(typeof(FileLogger))]
        //    public async Task<IResult> Add(Integration interpolation, IFormFile file)
        //    {
        //        var result = BusinessRules.Run(CheckIfThereIsAnyData(),CheckIfImagePathDoesExist(interpolation));

        //        if (result != null)
        //        {
        //            return result;
        //        }

        //        interpolation.ImagePath = FileHelper.AddAsync(file);
        //        _interpolationDal.Add(interpolation);
        //        await _interpolationDal.SaveChangesAsync();
        //        return new SuccessResult(Messages.pictureAdded);
        //    }

        //    [TransactionScopeAspect]
        //    [LogAspect(typeof(FileLogger))]
        //    public async Task<IResult> Delete(Integration interpolation)
        //    {
        //        var result = _interpolationDal.Get(p => p.ID == interpolation.ID);

        //        var oldpath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) + _interpolationDal.Get(p => p.ID == interpolation.ID).ImagePath;
        //        _interpolationDal.Delete(result);
        //        await _interpolationDal.SaveChangesAsync();
        //        return new SuccessResult(Messages.pictureDeleted);
        //    }

        //    [CacheAspect(2)]
        //    [TransactionScopeAspect]
        //    [PerformanceAspect(3)]
        //    public async Task<IDataResult<IEnumerable<Integration>>> GetAll()
        //    {
        //        var result = await _interpolationDal.GetListAsync();
        //        return new SuccessDataResult<IEnumerable<Integration>>(result);
        //    }

        //    [CacheAspect]
        //    [PerformanceAspect(3)]
        //    public IDataResult<Integration> GetByID(int id)
        //    {
        //        return new SuccessDataResult<Integration>(_interpolationDal.Get(p => p.ID == id));
        //    }

        //    //public async Task<IDataResult<IEnumerable<Interpolation>>> GetCount()
        //    //{
        //    //    var result = _interpolationDal.GetCount();
        //    //    return new SuccessDataResult<IEnumerable<Interpolation>>(result);
        //    //}

        //    [TransactionScopeAspect]
        //    public IResult Send(IFormFile file)
        //    {
        //        return new SuccessResult(Messages.PhotoIsSendingToMLServer);
        //    }

        //    [TransactionScopeAspect]
        //    [LogAspect(typeof(FileLogger))]
        //    public async Task<IResult> Update(Integration interpolation, IFormFile file)
        //    {
        //        var result = BusinessRules.Run( CheckIfThereIsAnyData(), CheckIfImagePathDoesExist(interpolation));

        //        if (result != null)
        //        {
        //            return result;
        //        }

        //        var oldpath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) + _interpolationDal.Get(p => p.ID == interpolation.ID).ImagePath;

        //        interpolation.ImagePath = FileHelper.UpdateAsync(oldpath ,file);
        //        _interpolationDal.Update(interpolation);
        //        await _interpolationDal.SaveChangesAsync();
        //        return new SuccessResult(Messages.pictureUpdated);
        //    }

        //    private IResult CheckIfImagePathDoesExist(Integration interpolation)
        //    {
        //        var result = _interpolationDal.Get(p => p.ImagePath == interpolation.ImagePath);

        //        if (result != null)
        //        {
        //            return new ErrorResult(Messages.textDataIsAlreadyExist);
        //        }
        //        return new SuccessResult();
        //    }

        //    private IResult CheckIfThereIsAnyData()
        //    {
        //        var result = GetAll();

        //        if (result != null)
        //        {
        //            return new ErrorResult(Messages.thereIsNoPicture);
        //        }
        //        return new SuccessResult();
        //    }

        //    //private IResult CheckTheImageLimit()
        //    //{
        //    //    var result = GetAll();

        //    //    if (result.Count > 30)
        //    //    {
        //    //        return new ErrorResult(Messages.pictureLimitIsFull);
        //    //    }
        //    //    return new SuccessResult();
        //    //}
        //}
        public Task<IResult> Add(Integration interpolation, IFormFile file)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Delete(Integration interpolation)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<IEnumerable<Integration>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Integration> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Send(IFormFile file)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Update(Integration interpolation, IFormFile file)
        {
            throw new NotImplementedException();
        }
    }
}
