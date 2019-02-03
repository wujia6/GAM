namespace GAM.Domain.Entities.Aggregates.DepartAgg
{
    public class DepartFactory
    {
        private DepartFactory()
        {
            Instance = null ?? new DepartFactory();
        }

        public static DepartFactory Instance { get; private set; }

        public Depart Create()
        {
            return new Depart();
        }
    }
}
