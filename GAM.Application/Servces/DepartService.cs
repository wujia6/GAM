using System.Linq;
using GAM.Core.IApi;
using GAM.Core.Models.DepartRoot;
using GAM.Infrastructure.Dtos;
using GAM.Infrastructure.Utilities;
using GAM.Application.IServices;

namespace GAM.Application.Services
{
    internal class DepartService: IDepartService
    {
        private readonly IDepartManage iManage;
        private readonly ISqlLocalContext iSqlContext;

        public DepartService(IDepartManage imanage, ISqlLocalContext icxt)
        {
            this.iManage = imanage;
            this.iSqlContext = icxt;
        }

        public bool AddOrEditAt(DepartDTO model)
        {
            var dpt = MapperSupport.MapTo<Depart>(model);
            return iManage.AddOrEditAt(dpt) ? iSqlContext.SaveChanges() > 0 : false;
        }

        public bool RemoveAt(ISpecification<Depart> ispec)
        {
            return iManage.RemoveAt(ispec) ? iSqlContext.SaveChanges() > 0 : false;
        }

        public DepartDTO FindBy(ISpecification<Depart> ispec)
        {
            var entity = iManage.FindBy(ispec);
            return MapperSupport.MapTo<DepartDTO>(entity);
        }

        public IQueryable<DepartDTO> QueryBy(ISpecification<Depart> ispec)
        {
            IQueryable<Depart> iqs = iManage.QueryBy(ispec);
            return MapperSupport.MapTo<IQueryable<DepartDTO>>(iqs);
        }
    }
}