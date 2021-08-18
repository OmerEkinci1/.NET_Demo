using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Interpolations.Queries
{
    public class GetInterpolationByIdQuery : IRequest<IDataResult<Interpolation>>
    {
        public int ID { get; set; }

        public class GetInterpolationQueryHandler : IRequestHandler<GetInterpolationByIdQuery, IDataResult<Interpolation>>
        {
            private readonly IInterpolationDal _interpolationDal;
            private readonly IMediator _mediator;

            [LogAspect(typeof(FileLogger))]
            public async Task<IDataResult<Interpolation>> Handle(GetInterpolationByIdQuery request, CancellationToken cancellationToken)
            {
                var interpolation = await _interpolationDal.GetAsync(x => x.ID == request.ID);
                return new SuccessDataResult<Interpolation>(interpolation);
            }
        }
    }
}
