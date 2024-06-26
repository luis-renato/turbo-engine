using Swashbuckle.AspNetCore.Annotations;
using turbo_engine.HyperMedia;
using turbo_engine.HyperMedia.Abstract;

namespace turbo_engine.Data.VO
{
    [SwaggerSchema(Required = new[] { "Description" })]
    public class PersonVO : ISupportHyperMedia
    {
        /// <summary>
        /// The sizes the product is available in
        /// </summary>
        /// <example>["Small", "Medium", "Large"]</example>
        public long Id { get; set; }

        [SwaggerSchema("The person identifier")]
        public string FirstName { get; set; }

        [SwaggerSchema("The person identifier")]
        public string LastName { get; set; }

        [SwaggerSchema("The person identifier")]
        public string Address { get; set; }

        [SwaggerSchema("The person identifier")]
        public string Gender { get; set; }

        [SwaggerSchema("The person identifier")]
        public bool Enabled { get; set; }
        [SwaggerSchema("The person identifier")]
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
