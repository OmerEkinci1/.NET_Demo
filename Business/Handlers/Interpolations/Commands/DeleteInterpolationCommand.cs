using Business.Constants;
using Core.Aspects.Autofac.Caching;
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
    public class DeleteInterpolationCommand : IRequest<IResult>
    {
        public int ID { get; set; }

        public class DeleteInterpolationCommandHandler : IRequestHandler<DeleteInterpolationCommand, IResult>
        {
            private readonly IInterpolationDal _interpolationDal;
            private readonly IMediator _mediator;

            public DeleteInterpolationCommandHandler(IInterpolationDal interpolationDal, IMediator mediator)
            {
                _interpolationDal = interpolationDal;
                _mediator = mediator;
            }

            [TransactionScopeAspect]
            [LogAspect(typeof(FileLogger))]
            [CacheRemoveAspect("Get")]
            public async Task<IResult> Handle(DeleteInterpolationCommand request, CancellationToken cancellationToken)
            {
                var interpolationToDelete = _interpolationDal.Get(p => p.ID == request.ID);

                _interpolationDal.Delete(interpolationToDelete);
                await _interpolationDal.SaveChangesAsync();
                return new SuccessResult(Messages.pictureDeleted);
            }
        }
    }
}
