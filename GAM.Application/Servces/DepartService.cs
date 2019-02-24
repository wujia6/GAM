using System.Linq;
using GAM.Core.IApi;
using GAM.Core.Models.DepartRoot;
using GAM.Infrastructure.Dtos;
using GAM.Infrastructure.Utilities;
using GAM.Application.IServices;

namespace GAM.Application.Services
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
            var dpt = MapperSupport.MapTo<Depart>(model);
            return iManage.AddOrEditAt(dpt);
        }

        public bool RemoveAt(DepartDTO model)
        {
            var entity = MapperSupport.MapTo<Depart>(model);
            return iManage.RemoveAt(entity);
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