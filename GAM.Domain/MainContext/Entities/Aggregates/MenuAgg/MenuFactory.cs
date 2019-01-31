namespace GAM.Domain.MainContext.Entities.Aggregates.MenuAgg
{
    public class MenuFactory
    {
        private MenuFactory()
        {
            Instance = null ?? new MenuFactory();
        }

        public static MenuFactory Instance { get; private set; }

        public Menu Create()
        {
            return new Menu();
        }
    }
}
