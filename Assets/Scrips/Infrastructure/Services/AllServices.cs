namespace Scripts.CodeBase.Infractructure
{
    public class AllServices
    {
        private static AllServices _container;

        public static AllServices Container => _container ?? (_container = new AllServices());

        public void Register<TService>(TService implementation) where TService : IService
        {
            Implementation<TService>.Service = implementation;
        }

        public TService Get<TService>() where TService : IService
        {
            return Implementation<TService>.Service;
        }

        private static class Implementation<TService> where TService : IService
        {
            public static TService Service;
        }
    }
}