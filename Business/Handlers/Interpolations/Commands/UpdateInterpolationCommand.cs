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
    public class UpdateInterpolationCommand : IRequest<IResult>
    {
        public int ID { get; set; }
        public string ImagePath { get; set; }
        public string ClassName { get; set; }

        public class UpdateInterpolationCommandHandler : IRequestHandler<UpdateInterpolationCommand, IResult>
        {
            private readonly IInterpolationDal _interpolationDal;
            private readonly IMediator _mediator;

            public UpdateInterpolationCommandHandler(IInterpolationDal interpolationDal, IMediator mediator)
            {
                _interpolationDal = interpolationDal;
                _mediator = mediator;
            }

            [TransactionScopeAspect]
            [LogAspect(typeof(FileLogger))]
            public async Task<IResult> Handle(UpdateInterpolationCommand request, CancellationToken cancellationToken)
            {
                var isInterpolationRecord = await _interpolationDal.GetAsync(x => x.ID == request.ID);

                isInterpolationRecord.ID = request.ID;
                isInterpolationRecord.ImagePath = request.ImagePath;
                isInterpolationRecord.ClassName = request.ClassName;

                _interpolationDal.Update(isInterpolationRecord);
                await _interpolationDal.SaveChangesAsync();
                return new SuccessResult(Messages.pictureUpdated);
            }
        }
    }
}
