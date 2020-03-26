using System;
using Newtonsoft.Json.Linq;

namespace RealEstateManager.Utilities {
    // Request Model
    public class GraphQLQuery {
        // Name of the Query
        public string OperationName { get; set; }
        // Body of the Request
        public string Query { get; set; }
        // Variables passed by the user
        public JObject Variables { get; set; }
    }
}