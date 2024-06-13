using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using turbo_engine.Model.Base;

namespace turbo_engine.Data.VO
{
    public class PersonVO
    {
        [JsonPropertyName("Code")]
        public long Id { get; set; }
        
        [JsonPropertyName("First Name")]
        public string FirstName { get; set; }
        
        [JsonPropertyName("Last Name")]
        public string LastName { get; set; }
        
        [JsonIgnore]
        public string Address { get; set; }
        
        [JsonPropertyName("Sex")]
        public string Gender { get; set; }
    }
}
