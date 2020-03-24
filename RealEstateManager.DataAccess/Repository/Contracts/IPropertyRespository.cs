using System;
using System.Collections.Generic;
using RealEstateManager.Database.Models;

namespace RealEstateManager.DataAccess.Repositories.Contracts
{
    public interface IPropertyRespository{
        IEnumerable<Property> GetAll();

    }
}