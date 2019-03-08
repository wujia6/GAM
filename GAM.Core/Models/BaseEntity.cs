using System;

namespace GAM.Core.Models
{
    public abstract class BaseEntity
    {
        public Guid ID { get; set; }

        public string Remarks { get; set; }
    }
}
