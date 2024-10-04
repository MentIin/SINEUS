namespace CodeBase.Infrastructure.Services
{
    public class AllServices
    {
        private static AllServices _instance;
        public static AllServices Container => _instance ?? (_instance = new AllServices());

        public void RegisterSingle<TService>(TService implementation)
        {
            Implementation<TService>.serviceInstance = implementation;
        }

        public TService Single<TService>()
        {
            return Implementation<TService>.serviceInstance;
        }

        private static class Implementation<TService> 
        {
            public static TService serviceInstance;
        }
    }
}