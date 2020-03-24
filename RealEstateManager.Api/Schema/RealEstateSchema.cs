using GraphQL;
using RealEstateManager.Api.Queries;
namespace RealEstateManager.Api.Schema
{
public class RealEstateSchema : GraphQL.Types.Schema
{
    public RealEstateSchema(IDependencyResolver resolver)
    :base(resolver)
    {
        Query = resolver.Resolve<PropertyQuery>();
    }
}
}