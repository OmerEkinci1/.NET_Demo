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
        public byte[] PICTURE { get; set; }
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

            [TransactionScopeAspect]
            [LogAspect(typeof(FileLogger))]
            [CacheRemoveAspect("Get")]
            public async Task<IResult> Handle(CreateIntegrationCommand request, CancellationToken cancellationToken)
            {
                //var result = BusinessRules.Run(CheckIfThereIsAnyData(), CheckIfImagePathDoesExist(interpolation));

                var interpolations = new Integration
                {
                    INS_DT = request.INS_DT,
                    IS_PROCESSED = request.IS_PROCESSED,
                    JSON_TEXT = request.JSON_TEXT,
                    PRODUCT_TYPE = request.PRODUCT_TYPE,
                    PROCESSED_DT = request.PROCESSED_DT,
                    PICTURE = request.PICTURE
                };

                _interpolationDal.Add(interpolations);
                await _interpolationDal.SaveChangesAsync();
                return new SuccessResult(Messages.pictureAdded);
            }
        }
    }
}
