using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Core.Utilities.Results;
using Business.Concrete;

public class IntegrationService : IIntegrationService
{
    public IntegrationService()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    IIntegrationService _integrationService = InstanceFactory

    public IResult Add(Integration interpolation)
    {
        throw new NotImplementedException();
    }

    public IResult Delete(Integration interpolation)
    {
        throw new NotImplementedException();
    }

    public IDataResult<IEnumerable<Integration>> GetAll()
    {
        throw new NotImplementedException();
    }

    public IDataResult<Integration> GetByID(int id)
    {
        throw new NotImplementedException();
    }

    public IResult Update(Integration interpolation)
    {
        throw new NotImplementedException();
    }
}