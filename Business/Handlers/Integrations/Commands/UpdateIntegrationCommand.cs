using Business.Constants;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Transaction;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Interpolations.Commands
{
    public class UpdateIntegrationCommand : IRequest<IResult>
    {
        public int ID { get; set; }
        public string JSON_TEXT { get; set; }
        public DateTime INS_DT { get; set; }
        public DateTime IS_PROCESSED { get; set; }
        public byte[] PICTURE { get; set; }
        public DateTime PROCESSED_DT { get; set; }
        public int PRODUCT_TYPE { get; set; }

        public class UpdateInterpolationCommandHandler : IRequestHandler<UpdateIntegrationCommand, IResult>
        {
            private readonly IIntegrationRepository _integrationDal;
            private readonly IMediator _mediator;

            public UpdateInterpolationCommandHandler(IIntegrationRepository integrationDal, IMediator mediator)
            {
                _integrationDal = integrationDal;
                _mediator = mediator;
            }

            [TransactionScopeAspect]
            [LogAspect(typeof(FileLogger))]
            public async Task<IResult> Handle(UpdateIntegrationCommand request, CancellationToken cancellationToken)
            {
                var isInterpolationRecord = await _integrationDal.GetAsync(x => x.ID == request.ID);

                isInterpolationRecord.ID = request.ID;
                isInterpolationRecord.JSON_TEXT = request.JSON_TEXT;
                isInterpolationRecord.INS_DT = request.INS_DT;
                isInterpolationRecord.IS_PROCESSED = request.IS_PROCESSED;
                isInterpolationRecord.PICTURE = request.PICTURE;
                isInterpolationRecord.PRODUCT_TYPE = request.PRODUCT_TYPE;

                _integrationDal.Update(isInterpolationRecord);
                await _integrationDal.SaveChangesAsync();
                return new SuccessResult(Messages.pictureUpdated);
            }
        }
    }
}
