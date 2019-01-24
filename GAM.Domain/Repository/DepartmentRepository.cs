using System;
using System.Collections.Generic;
using System.Text;
using GAM.Domain.Entities;
using GAM.Domain.IRepository;

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
