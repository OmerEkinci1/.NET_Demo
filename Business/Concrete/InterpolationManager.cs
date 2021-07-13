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

namespace Business.Concrete
{
    public class InterpolationManager : IInterpolationService
    {
        private IInterpolationDal _interpolationDal;

        public InterpolationManager(IInterpolationDal pictureDal)
        {
            _interpolationDal = pictureDal;
        }

        [TransactionScopeAspect]
        [LogAspect(typeof(FileLogger))]
        public IResult Add(Interpolation interpolation, IFormFile file)
        {
            var result = BusinessRules.Run(CheckIfPictureDoesExist(interpolation), CheckIfThereIsAnyData(), 
                CheckIfTextDoesExist(interpolation), CheckTheImageLimit());

            if (result != null)
            {
                return result;
            }

            interpolation.Picture = FileHelper.AddAsync(file);
            _interpolationDal.Add(interpolation);
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        [LogAspect(typeof(FileLogger))]
        public IResult Delete(Interpolation interpolation)
        {
            var result = _interpolationDal.Get(p => p.ID == interpolation.ID);

            var oldpath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) + _interpolationDal.Get(p => p.ID == interpolation.ID).Picture;
            _interpolationDal.Delete(result);
            return new SuccessResult();
        }

        [CacheAspect(2)]
        [TransactionScopeAspect]
        [PerformanceAspect(3)]
        public IDataResult<List<Interpolation>> GetAll()
        {
            return new SuccessDataResult<List<Interpolation>>(_interpolationDal.GetAll());
        }

        [CacheAspect]
        [PerformanceAspect(3)]
        public IDataResult<Interpolation> GetByID(int id)
        {
            return new SuccessDataResult<Interpolation>(_interpolationDal.Get(p => p.ID == id));
        }

        [TransactionScopeAspect]
        [LogAspect(typeof(FileLogger))]
        public IResult Update(Interpolation interpolation, IFormFile file)
        {
            var result = BusinessRules.Run(CheckIfPictureDoesExist(interpolation), CheckIfThereIsAnyData(),
                CheckIfTextDoesExist(interpolation));

            if (result != null)
            {
                return result;
            }

            var oldpath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) + _interpolationDal.Get(p => p.ID == interpolation.ID).Picture;

            interpolation.Picture = FileHelper.UpdateAsync(oldpath ,file);
            _interpolationDal.Update(interpolation);
            return new SuccessResult();
        }

        private IResult CheckIfPictureDoesExist(Interpolation interpolation)
        {
            var result = _interpolationDal.Get(p => p.Picture == interpolation.Picture);

            if (result != null)
            {
                return new ErrorResult(Messages.pictureIsAlreadyExist);
            }
            return new SuccessResult();
        }

        private IResult CheckIfTextDoesExist(Interpolation interpolation)
        {
            var result = _interpolationDal.Get(p => p.Text == interpolation.Text);

            if (result != null)
            {
                return new ErrorResult(Messages.textDataIsAlreadyExist);
            }
            return new SuccessResult();
        }

        private IResult CheckIfThereIsAnyData()
        {
            var result = _interpolationDal.GetAll();

            if (result != null)
            {
                return new ErrorResult(Messages.thereIsNoPicture);
            }
            return new SuccessResult();
        }

        private IResult CheckTheImageLimit()
        {
            var result = _interpolationDal.GetAll();

            if (result.Count > 30)
            {
                return new ErrorResult(Messages.pictureLimitIsFull);
            }
            return new SuccessResult();
        }
    }
}
