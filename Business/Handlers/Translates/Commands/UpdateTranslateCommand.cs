using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Translates.Commands
{
    public class UpdateTranslateCommand : IRequest<IResult>
    {
        public int Id { get; set; }
        public int LangId { get; set; }
        public string Value { get; set; }
        public string Code { get; set; }

        public class UpdateTranslateCommandHandler : IRequestHandler<UpdateTranslateCommand, IResult>
        {
            private readonly ITranslateRepository _translateRepository;
            private readonly IMediator _mediator;

            public UpdateTranslateCommandHandler(ITranslateRepository translateRepository, IMediator mediator)
            {
                _translateRepository = translateRepository;
                _mediator = mediator;
            }

            [CacheRemoveAspect("Get")]
            [LogAspect(typeof(FileLogger))]
            public async Task<IResult> Handle(UpdateTranslateCommand request, CancellationToken cancellationToken)
            {
                var isThereTranslateRecord = await _translateRepository.GetAsync(u => u.Id == request.Id);

                isThereTranslateRecord.Id = request.Id;
                isThereTranslateRecord.LangId = request.LangId;
                isThereTranslateRecord.Value = request.Value;
                isThereTranslateRecord.Code = request.Code;

                _translateRepository.Update(isThereTranslateRecord);
                await _translateRepository.SaveChangesAsync();
                return new SuccessResult(Messages.Updated);
            }
        }
    }
}
