using System;
using System.Collections.Generic;
using RealEstateManager.Database;
using RealEstateManager.Database.Models;

namespace RealEstateManager.DataAccess.Repositories
{
public class PropertyRepository : IPropertyRepository
{
    private readonly RealEstateContext _dbContext;

    public PropertyRepository(RealEstateContext dbContext) 
    {
        _dbContext = dbContext;
    }
public IEnumerable<Property> GetAll()
{
    return _dbContext.Properties;
}
}
}
