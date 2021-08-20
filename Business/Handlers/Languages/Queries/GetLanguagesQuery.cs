using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Performance;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Languages.Queries
{
    public class GetLanguagesQuery : IRequest<IDataResult<IEnumerable<Language>>>
    {
        public class GetLanguagesQueryHandler : IRequestHandler<GetLanguagesQuery, IDataResult<IEnumerable<Language>>>
        {
            private readonly ILanguageRepository _languageRepository;
            private readonly IMediator _mediator;

            public GetLanguagesQueryHandler(ILanguageRepository languageRepository, IMediator mediator)
            {
                _languageRepository = languageRepository;
                _mediator = mediator;
            }

            [PerformanceAspect(5)]
            [CacheAspect(10)]
            [LogAspect(typeof(FileLogger))]
            public async Task<IDataResult<IEnumerable<Language>>> Handle(GetLanguagesQuery request, CancellationToken cancellationToken)
            {
                return new SuccessDataResult<IEnumerable<Language>>(await _languageRepository.GetListAsync());
            }
        }
    }
}
