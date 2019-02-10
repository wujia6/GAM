using System;
using System.Collections.Generic;
using System.Text;

namespace GAM.Infrastructure.DTO
{
    abstract class DTO_BaseModel
    {
        public int ID { get; set; }

        public string Remarks { get; set; }
    }
}
