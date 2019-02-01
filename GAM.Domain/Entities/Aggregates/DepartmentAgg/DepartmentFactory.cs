namespace GAM.Domain.Entities.Aggregates.DepartmentAgg
{
    public class DepartmentFactory
    {
        private DepartmentFactory()
        {
            Instance = null ?? new DepartmentFactory();
        }

        public static DepartmentFactory Instance { get; private set; }

        public Department Create()
        {
            return new Department();
        }
    }
}
