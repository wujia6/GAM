using System.Linq;
using GAM.Core.Models.UserRoot;

namespace GAM.Core.Models.DepartRoot
{
    public class Depart:BaseEntity,IAggregateRoot
    {
        public string Name { get; set; }
        public string Manager { get; set; }

        public virtual IQueryable<User> Users { get; set; }
    }
}
