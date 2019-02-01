namespace GAM.Domain.Entities.Aggregates.UserAgg
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
