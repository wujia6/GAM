using System;
using System.Collections.Generic;
using GAM.Domain.Entities;
using GAM.Domain.IComm;

namespace GAM.Domain.Repository
{
    internal class DepartmentRepository: IDepartmentRepos
    {
        private readonly IRepository<Department> iRepos;

        public DepartmentRepository(IRepository<Department> irepos)
        {
            this.iRepos = irepos;
        }

        public IEnumerable<Department> GetDepartmentUserList()
        {
            throw new NotImplementedException();
        }
    }
}
