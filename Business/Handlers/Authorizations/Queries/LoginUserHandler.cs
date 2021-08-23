using Business.Services.Authentication;
using Business.Services.Model;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Authorizations.Queries
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, IDataResult<LoginUserResult>>
    {
        private readonly IAuthenticationCoordinator _coordinator;

        public LoginUserHandler(IAuthenticationCoordinator coordinator)
        {
            _coordinator = coordinator;
        }

        [LogAspect(typeof(FileLogger))]
        public async Task<IDataResult<LoginUserResult>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var provider = _coordinator.SelectProvider(request.Provider);
            return new SuccessDataResult<LoginUserResult>(await provider.Login(request));
        }
    }
}
