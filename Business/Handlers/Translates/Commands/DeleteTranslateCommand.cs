using Business.Constants;
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
    public class DeleteTranslateCommand : IRequest<IResult>
    {
        public int Id { get; set; }

        public class DeleteTranslteCommandHandler : IRequestHandler<DeleteTranslateCommand, IResult>
        {
            private readonly ITranslateRepository _translateRepository;
            private readonly IMediator _mediator;

            public DeleteTranslteCommandHandler(ITranslateRepository translateRepository, IMediator mediator)
            {
                _translateRepository = translateRepository;
                _mediator = mediator;
            }

            public async Task<IResult> Handle(DeleteTranslateCommand request, CancellationToken cancellationToken)
            {
                var translateToDelete = _translateRepository.Get(p => p.Id == request.Id);

                _translateRepository.Delete(translateToDelete);
                await _translateRepository.SaveChangesAsync();
                return new SuccessResult(Messages.Deleted);
            }
        }
    }
}
