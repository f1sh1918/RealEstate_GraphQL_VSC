using GraphQL.Types;
using RealEstateManager.Types.Payment;
using RealEstateManager.DataAccess.Repositories.Contracts;

namespace RealEstateManager.Types.Property {
    public class PropertyType : ObjectGraphType<Database.Models.Property> {
        public PropertyType (IPaymentRepository paymentRepository) {
            Field(x => x.Id);
            Field(x=>x.Name);
            Field(x=>x.Value);
            Field(x=>x.City);
            Field(x=>x.Family);
            Field(x=>x.Street);
            //Connector to Payment Type
            Field<ListGraphType<PaymentType>>("payments",
            arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "last"}),
            resolve: context => {
                var lastItemFilter = context.GetArgument<int?>("last");
                return lastItemFilter != null
                ?paymentRepository.GetAllForProperty(context.Source.Id, lastItemFilter.Value)
                :paymentRepository.GetAllForProperty(context.Source.Id);
                });
        }

    }
}