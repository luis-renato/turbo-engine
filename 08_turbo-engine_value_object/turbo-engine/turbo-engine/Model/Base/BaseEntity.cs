using System.ComponentModel.DataAnnotations.Schema;

namespace turbo_engine.Model.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }
    }
}
