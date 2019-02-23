using System.Linq;
using AutoMapper;
using GAM.Core.IApi;
using GAM.Core.Models.DepartRoot;

namespace GAM.Application.DepartApp
{
    public class DepartService: IDepartService
    {
        private readonly IDepartManage iManage;

        public DepartService(IDepartManage imanage)
        {
            this.iManage = imanage;
        }

        public bool AddOrEditAt(DepartDTO model)
        {
            var dpt = Mapper.Map<Depart>(model);
            return iManage.AddOrEditAt(dpt);
        }

        public bool RemoveAt(DepartDTO model)
        {
            var entity = Mapper.Map<Depart>(model);
            return iManage.RemoveAt(entity);
        }

        public DepartDTO FindBy(ISpecification<Depart> ispec)
        {
            var entity = iManage.FindBy(ispec);
            return Mapper.Map<DepartDTO>(entity);
        }

        public IQueryable<DepartDTO> QueryBy(ISpecification<Depart> ispec)
        {
            IQueryable<Depart> iqs = iManage.QueryBy(ispec);
            return Mapper.Map<IQueryable<DepartDTO>>(iqs);
        }
    }
}
