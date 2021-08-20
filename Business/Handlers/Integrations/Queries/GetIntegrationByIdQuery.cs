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
    public class GetIntegrationByIdQuery : IRequest<IDataResult<Integration>>
    {
        public int ID { get; set; }

        public class GetIntegrationQueryHandler : IRequestHandler<GetIntegrationByIdQuery, IDataResult<Integration>>
        {
            private readonly IIntegrationRepository _interpolationDal;
            private readonly IMediator _mediator;

            [LogAspect(typeof(FileLogger))]
            public async Task<IDataResult<Integration>> Handle(GetIntegrationByIdQuery request, CancellationToken cancellationToken)
            {
                var interpolation = await _interpolationDal.GetAsync(x => x.ID == request.ID);
                return new SuccessDataResult<Integration>(interpolation);
            }
        }
    }
}
