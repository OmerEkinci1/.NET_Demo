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
using System.Drawing;
using Core.Utilities.Helpers;
using System.IO;
using System.Drawing.Imaging;

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
        public IResult Add(Integration integration)
        {
            //var result = BusinessRules.Run(CheckIfThereIsAnyData(), CheckIfImagePathDoesExist(integration));

            //if (result != null)
            //{
            //    return result;
            //}

            //string imageString = integration.PICTURE;
            //string fileName = DateTime.Now.ToString("yyyy-MM-dd HHmmssfff") + "_" + integration.JSON_TEXT;
            //Bitmap bmpFromString = BitmapHelper.Base64StringBitmap(imageString);
            //// For this usage, user must to create folder which is attached below code.
            //string path = Path.Combine(@"C:\Services\Images", fileName + ".bmp");
            //var i2 = new Bitmap(bmpFromString);
            //i2.Save(path, ImageFormat.Bmp);

            integration.INS_DT = DateTime.Now;
            integration.IS_PROCESSED = "T";
            integration.PROCESSED_DT = DateTime.Now;

            _interpolationRepository.Add(integration);
            _interpolationRepository.SaveChanges();
            return new SuccessResult(Messages.pictureAdded);
        }

        [TransactionScopeAspect]
        [LogAspect(typeof(FileLogger))]
        public IResult Delete(Integration integration)
        {
            var result = _interpolationRepository.Get(p => p.ID == integration.ID);

            _interpolationRepository.Delete(result);
            _interpolationRepository.SaveChanges();
            return new SuccessResult(Messages.pictureDeleted);
        }

        [CacheAspect(2)]
        [TransactionScopeAspect]
        [PerformanceAspect(3)]
        public IDataResult<IEnumerable<Integration>> GetAll()
        {
            var result = _interpolationRepository.GetList();
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
        public IResult Update(Integration integration)
        {
            //var result = BusinessRules.Run(CheckIfThereIsAnyData(), CheckIfImagePathDoesExist(interpolation));

            //if (result != null)
            //{
            //    return result;
            //}

            _interpolationRepository.Update(integration);
            _interpolationRepository.SaveChanges();
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
