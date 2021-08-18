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
    public class GetIntegrationsQuery : IRequest<IDataResult<IEnumerable<Integration>>>
    {
        public class GetInterpolationQueryHandler : IRequestHandler<GetIntegrationsQuery, IDataResult<IEnumerable<Integration>>>
        {
            private readonly IIntegrationDal _interpolationDal;
            private readonly IMediator _mediator;

            public GetInterpolationQueryHandler(IIntegrationDal interpolationDal, IMediator mediator)
            {
                _interpolationDal = interpolationDal;
                _mediator = mediator;
            }

            [CacheAspect(2)]
            [TransactionScopeAspect]
            [PerformanceAspect(3)]
            [LogAspect(typeof(FileLogger))]
            public async Task<IDataResult<IEnumerable<Integration>>> Handle(GetIntegrationsQuery request, CancellationToken cancellationToken)
            {
                return new SuccessDataResult<IEnumerable<Integration>>(await _interpolationDal.GetListAsync());
            }
        }
    }
}
