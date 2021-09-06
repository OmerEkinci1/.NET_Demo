using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Transaction;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Interpolations.Commands
{
    public class CreateIntegrationCommand : IRequest<IResult>
    {
        public int ID { get; set; }
        public string JSON_TEXT { get; set; }
        public DateTime INS_DT { get; set; }
        public DateTime IS_PROCESSED { get; set; }
        public string PICTURE { get; set; }
        public DateTime PROCESSED_DT { get; set; }
        public int PRODUCT_TYPE { get; set; }

        public class CreateIntegrationCommandHandler : IRequestHandler<CreateIntegrationCommand, IResult>
        {
            private readonly IIntegrationRepository _interpolationDal;
            private readonly IMediator _mediator;

            public CreateIntegrationCommandHandler(IIntegrationRepository interpolationDal, IMediator mediator)
            {
                _interpolationDal = interpolationDal;
                _mediator = mediator;
            }

            //[TransactionScopeAspect]
            //[LogAspect(typeof(FileLogger))]
            //[CacheRemoveAspect("Get")]
            public async Task<IResult> Handle(CreateIntegrationCommand request, CancellationToken cancellationToken)
            {
                //var result = BusinessRules.Run(CheckIfThereIsAnyData(), CheckIfImagePathDoesExist(interpolation));

                string imageString = request.PICTURE;
                string fileName = DateTime.Now.ToString("yyyy-MM-dd HHmmssfff") + "_" + request.JSON_TEXT;
                Bitmap bmpFromString = BitmapHelper.Base64StringBitmap(imageString);
                // For this usage, user must to create folder which is attached below code.
                string path = Path.Combine(@"C:\Services\Images", fileName + ".bmp");
                var i2 = new Bitmap(bmpFromString);
                i2.Save(path, ImageFormat.Bmp);

                var interpolations = new Integration
                {
                    INS_DT = DateTime.Now,
                    IS_PROCESSED = "T",
                    JSON_TEXT = request.JSON_TEXT,
                    PRODUCT_TYPE = request.PRODUCT_TYPE,
                    PROCESSED_DT = DateTime.Now,
                    PICTURE = request.PICTURE
                };

                _interpolationDal.Add(interpolations);
                await _interpolationDal.SaveChangesAsync();
                return new SuccessResult(Messages.pictureAdded);
            }
        }
    }
}
