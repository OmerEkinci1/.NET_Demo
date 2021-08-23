using Core.Entities.Concrete;
using Core.Utilities.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Model
{
    public class VerifyOtpCommand : IRequest<IDataResult<DArchToken>>
    {
        public AuthenticationProviderType Provider { get; set; }

        /// <summary>
        /// Specifies the subtype so that the same provider user can enter from different systems.
        /// </summary>
        public string ProviderSubType { get; set; }

        public string ExternalUserId { get; set; }
        public int Code { get; set; }
    }
}
