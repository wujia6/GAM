namespace GAM.Domain.MainContext.Entities.Aggregates.UserAgg
{
    public class UserFactory
    {
        private UserFactory()
        {
            Instance = null ?? new UserFactory();
        }

        public static UserFactory Instance { get; private set; }

        public User Create()
        {
            return new User();
        }
    }
}
