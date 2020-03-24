using System.Collections.Generic;
using RealEstateManager.Database.Models;
public interface IPropertyRepository
{
    IEnumerable<Property> GetAll();
    //Property GetById(int id);
    //Property Add(Property property);
}