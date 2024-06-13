using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using turbo_engine.Model.Base;

namespace turbo_engine.Data.VO
{
    public class BookVO
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public decimal Price { get; set; }

        public DateTime LaunchDate { get; set; }
    }
}