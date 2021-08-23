using Core.Entities.Concrete;
using Core.Utilities.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Business.Services.Model
{
    public class LoginUserCommand : IRequest<IDataResult<LoginUserResult>>
    {
        public string ExternalUserId { get; set; }

        public string MobilePhone { get; set; }

        public string Password { get; set; }

        public AuthenticationProviderType Provider { get; set; }

        public bool IsPhoneValid
        {
            get
            {
                if (string.IsNullOrWhiteSpace(MobilePhone))
                {
                    return false;
                }

                PostProcess();
                MobilePhone = Regex.Replace(MobilePhone, "[^0-9]", string.Empty);
                return MobilePhone.StartsWith("05") && MobilePhone.Length == 11;
            }
        }

        public long AsCitizenId() => long.Parse(ExternalUserId);

        public void PostProcess()
        {
            MobilePhone = Regex.Replace(MobilePhone, "[^0-9]", string.Empty);
        }
    }
}
