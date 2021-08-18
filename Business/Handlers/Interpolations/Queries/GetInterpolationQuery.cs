using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Performance;
using Core.Aspects.Transaction;
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
    public class GetInterpolationQuery : IRequest<IDataResult<IEnumerable<Interpolation>>>
    {
        public class GetInterpolationQueryHandler : IRequestHandler<GetInterpolationQuery, IDataResult<IEnumerable<Interpolation>>>
        {
            private readonly IInterpolationDal _interpolationDal;
            private readonly IMediator _mediator;

            public GetInterpolationQueryHandler(IInterpolationDal interpolationDal, IMediator mediator)
            {
                _interpolationDal = interpolationDal;
                _mediator = mediator;
            }

            [CacheAspect(2)]
            [TransactionScopeAspect]
            [PerformanceAspect(3)]
            [LogAspect(typeof(FileLogger))]
            public async Task<IDataResult<IEnumerable<Interpolation>>> Handle(GetInterpolationQuery request, CancellationToken cancellationToken)
            {
                return new SuccessDataResult<IEnumerable<Interpolation>>(await _interpolationDal.GetListAsync());
            }
        }
    }
}
