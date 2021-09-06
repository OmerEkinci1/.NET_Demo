using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Transaction;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Performance;

namespace Business.Concrete
{
    public class IntegrationManager : IIntegrationService
    {
        private IIntegrationRepository _interpolationRepository;

        public IntegrationManager(IIntegrationRepository integrationRepository)
        {
            _interpolationRepository = integrationRepository;
        }

        [TransactionScopeAspect]
        [LogAspect(typeof(FileLogger))]
        public async Task<IResult> Add(Integration integration)
        {
            //var result = BusinessRules.Run(CheckIfThereIsAnyData(), CheckIfImagePathDoesExist(integration));

            //if (result != null)
            //{
            //    return result;
            //}

            _interpolationRepository.Add(integration);
            await _interpolationRepository.SaveChangesAsync();
            return new SuccessResult(Messages.pictureAdded);
        }

        [TransactionScopeAspect]
        [LogAspect(typeof(FileLogger))]
        public async Task<IResult> Delete(Integration interpolation)
        {
            var result = _interpolationRepository.Get(p => p.ID == interpolation.ID);

            _interpolationRepository.Delete(result);
            await _interpolationRepository.SaveChangesAsync();
            return new SuccessResult(Messages.pictureDeleted);
        }

        [CacheAspect(2)]
        [TransactionScopeAspect]
        [PerformanceAspect(3)]
        public async Task<IDataResult<IEnumerable<Integration>>> GetAll()
        {
            var result = await _interpolationRepository.GetListAsync();
            return new SuccessDataResult<IEnumerable<Integration>>(result);
        }

        [CacheAspect]
        [PerformanceAspect(3)]
        public IDataResult<Integration> GetByID(int id)
        {
            return new SuccessDataResult<Integration>(_interpolationRepository.Get(p => p.ID == id));
        }

        [TransactionScopeAspect]
        [LogAspect(typeof(FileLogger))]
        public async Task<IResult> Update(Integration interpolation)
        {
            //var result = BusinessRules.Run(CheckIfThereIsAnyData(), CheckIfImagePathDoesExist(interpolation));

            //if (result != null)
            //{
            //    return result;
            //}

            _interpolationRepository.Update(interpolation);
            await _interpolationRepository.SaveChangesAsync();
            return new SuccessResult(Messages.pictureUpdated);
        }

        //private IResult CheckIfImagePathDoesExist(Integration interpolation)
        //{

        //    if (result != null)
        //    {
        //        return new ErrorResult(Messages.textDataIsAlreadyExist);
        //    }
        //    return new SuccessResult();
        //}

        //private IResult CheckIfThereIsAnyData()
        //{
        //    var result = GetAll();

        //    if (result != null)
        //    {
        //        return new ErrorResult(Messages.thereIsNoPicture);
        //    }
        //    return new SuccessResult();
        //}

        //private IResult CheckTheImageLimit()
        //{
        //    var result = GetAll();

        //    if (result.Count > 30)
        //    {
        //        return new ErrorResult(Messages.pictureLimitIsFull);
        //    }
        //    return new SuccessResult();
        //}
    }
}
