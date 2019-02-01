using System;
using System.Collections.Generic;
using System.Text;

namespace GAM.Domain.Entities.Aggregates.RoleAgg
{
    public class RoleFactory
    {
        private RoleFactory()
        {
            Instance = null ?? new RoleFactory();
        }

        public static RoleFactory Instance { get; private set; }

        public Role Create()
        {
            return new Role();
        }
    }
}
