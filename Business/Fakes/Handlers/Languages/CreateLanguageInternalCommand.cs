using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Fakes.Handlers.Languages
{
    public class CreateLanguageInternalCommand : IRequest<IResult>
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public class CreateLanguageInternalCommandHandler : IRequestHandler<CreateLanguageInternalCommand, IResult>
        {
            private readonly ILanguageRepository _languageRepository;
            private readonly IMediator _mediator;

            public CreateLanguageInternalCommandHandler(ILanguageRepository languageRepository, IMediator mediator)
            {
                _languageRepository = languageRepository;
                _mediator = mediator;
            }

            [CacheRemoveAspect("Get")]
            public async Task<IResult> Handle(CreateLanguageInternalCommand request, CancellationToken cancellationToken)
            {
                var isThereLanguageRecord = _languageRepository.Query().Any(u => u.Name == request.Name);

                if (isThereLanguageRecord)
                {
                    return new ErrorResult(Messages.NameAlreadyExist);
                }

                var addedLanguage = new Language
                {
                    Name = request.Name,
                    Code = request.Code,
                };

                _languageRepository.Add(addedLanguage);
                await _languageRepository.SaveChangesAsync();
                return new SuccessResult(Messages.Added);
            }
        }
    }
}
