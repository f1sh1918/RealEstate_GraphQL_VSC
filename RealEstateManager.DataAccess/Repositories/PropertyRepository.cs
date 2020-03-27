using System;
using System.Collections.Generic;
using System.Linq;
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

        public Property GetById(int id)
        {
            return _dbContext.Properties.SingleOrDefault(x=>x.Id == id);
        }
    }
}
