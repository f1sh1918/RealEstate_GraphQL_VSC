using System;
using Newtonsoft.Json.Linq;

namespace RealEstateManager.Utilities
{
    public class GraphQLQuery
    {
        // Name of the Operation
        public string OperationName { get; set; }
        // Body of the Operation
        public string Query { get; set; }
        public JObject Variables {get;set;}
    }
}