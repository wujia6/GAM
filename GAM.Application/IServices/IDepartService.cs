using System.Linq;
using GAM.Core.IApi;
using GAM.Core.Models.DepartRoot;
using GAM.Infrastructure.Dtos;

namespace GAM.Application.IServices
{
    public interface IDepartService
    {
        bool AddOrEditAt(DepartDTO model);

        bool RemoveAt(ISpecification<Depart> ispec);

        DepartDTO FindBy(ISpecification<Depart> ispec);

        IQueryable<DepartDTO> QueryBy(ISpecification<Depart> ispec);
    }
}