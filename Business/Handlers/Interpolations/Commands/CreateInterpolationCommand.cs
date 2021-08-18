using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Transaction;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Interpolations.Commands
{
    public class CreateInterpolationCommand : IRequest<IResult>
    {
        public int ID { get; set; }
        public string ImagePath { get; set; }
        public string ClassName { get; set; }

        public class CreateInterpolationCommandHandler : IRequestHandler<CreateInterpolationCommand, IResult>
        {
            private readonly IInterpolationDal _interpolationDal;

            public CreateInterpolationCommandHandler(IInterpolationDal interpolationDal)
            {
                _interpolationDal = interpolationDal;
            }   

            [TransactionScopeAspect]
            [LogAspect(typeof(FileLogger))]
            [CacheRemoveAspect("Get")]
            public async Task<IResult> Handle(CreateInterpolationCommand request, CancellationToken cancellationToken)
            {
                //var result = BusinessRules.Run(CheckIfThereIsAnyData(), CheckIfImagePathDoesExist(interpolation));

                //var interpolations = new Interpolation
                //{
                    
                //};

                //interpolations.ImagePath = FileHelper.AddAsync(file);
                //_interpolationDal.Add(interpolations);
                //await _interpolationDal.SaveChangesAsync();
                //return new SuccessResult(Messages.pictureAdded);
            }
        }
    }
}
