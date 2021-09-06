using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Core.Utilities.Results;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;

public class IntegrationService : IIntegrationService
{
    public IntegrationService()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    IIntegrationService _integrationService = InstanceFactory.GetInstance<IIntegrationService>();

    public IResult Add(Integration integration)
    {
        return _integrationService.Add(integration);
    }

    public IResult Delete(Integration integration)
    {
        return _integrationService.Delete(integration);
    }

    public IDataResult<IEnumerable<Integration>> GetAll()
    {
        return _integrationService.GetAll();
    }

    public IDataResult<Integration> GetByID(int id)
    {
        return _integrationService.GetByID(id);
    }

    public IResult Update(Integration integration)
    {
        return _integrationService.Update(integration);
    }
}