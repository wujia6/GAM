namespace GAM.Domain.Entities
{
    public interface IEntity
    {
        int ID { get; set; }

        string Remarks { get; set; }
    }
}
