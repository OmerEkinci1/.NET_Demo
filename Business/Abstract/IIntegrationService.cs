using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;

namespace Business.Abstract
{
    // We point ServiceContract for using WCF.
    [ServiceContract]
    public interface IIntegrationService
    {
        [OperationContract]
        IResult Add(Integration interpolation);

        [OperationContract]
        IResult Delete(Integration interpolation);

        [OperationContract]
        IResult Update(Integration interpolation);

        [OperationContract]
        IDataResult<Integration> GetByID(int id);

        [OperationContract]
        IDataResult<IEnumerable<Integration>> GetAll();
    }
}
