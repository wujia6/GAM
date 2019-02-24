using System.Linq;
using GAM.Core.Models.DepartRoot;
using GAM.Infrastructure.Dtos;

namespace GAM.Application.IServices
{
    public interface IDepartService : IDependency
    {
         bool AddOrEditAt(DepartDTO model);

        bool RemoveAt(DepartDTO model);

        DepartDTO FindBy(Core.IApi.ISpecification<Depart> ispec);

        IQueryable<DepartDTO> QueryBy(Core.IApi.ISpecification<Depart> ispec);
    }
}