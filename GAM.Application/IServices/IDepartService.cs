using System.Linq;
using GAM.Application.DTO;

namespace GAM.Application.IServices
{
    public interface IDepartService
    {
        bool AddOrEditAt(DepartDTO model);

        bool RemoveAt(DepartDTO model);

        DepartDTO FindBy(Core.IApi.ISpecification<DepartDTO> ispec);

        IQueryable<DepartDTO> QueryBy(Core.IApi.ISpecification<DepartDTO> ispec);
    }
}
