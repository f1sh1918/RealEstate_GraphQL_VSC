using GraphQL.Types;
using RealEstateManager.DataAccess.Repositories;
using RealEstateManager.Types.Property;
namespace RealEstateManager.Api.Queries
{
    public class PropertyQuery : ObjectGraphType
{
    public PropertyQuery(IPropertyRepository propertyRepository)
    {
      Field<ListGraphType<PropertyType>>(
          "properties",
          resolve: context => propertyRepository.GetAll()
      );  
      Field<PropertyType>(
          "property",
          arguments : new QueryArguments(new QueryArgument<IntGraphType>{Name="id"}),
        resolve: context => propertyRepository.GetById(context.GetArgument<int>("id"))
      );
    }
}
}