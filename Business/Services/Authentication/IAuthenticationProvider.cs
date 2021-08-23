using Business.Services.Model;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IAuthenticationProvider
    {
        Task<LoginUserResult> Login(LoginUserCommand command);
        Task<IDataResult<DArchToken>> Verify(VerifyOtpCommand command);
    }
}
