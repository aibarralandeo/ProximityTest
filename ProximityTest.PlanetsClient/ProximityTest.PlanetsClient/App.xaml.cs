using ProximityTest.PlanetsClient.Services;
using ProximityTest.PlanetsClient.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProximityTest.PlanetsClient
{
    public partial class App : Application
    {
        private static IRestService service;

        public App()
        {
            DependencyService.Register<RestService>();

            InitializeComponent();
            MainPage = new NavigationPage( new PlanetList());
        }

        public static IRestService Service
        {
            get
            {
                if (service != null) return service;
                service = DependencyService.Get<IRestService>();

                Task.Run(async () =>
                {
                    try
                    {
                        var token = await service.GetTokenAsync();
                        await service.SetTokenAsync(token);
                    }
                    catch (System.Exception e)
                    {

                    }
                }).Wait();

                return service;
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
