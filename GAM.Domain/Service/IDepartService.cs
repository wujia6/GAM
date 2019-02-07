using GAM.Domain.Entities.Aggregates.DepartAgg;

namespace GAM.Domain.Service
{
    public interface IDepartService
    {
        Depart FindByID(int dpeartId);

        //bool SaveDepartUsers();
    }
}
