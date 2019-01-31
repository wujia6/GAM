namespace GAM.Domain.MainContext.Entities
{
    public abstract class BaseEntity
    {
        public int ID { get; set; }

        public string Remarks { get; set; }
    }
}
