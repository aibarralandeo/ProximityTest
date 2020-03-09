using ProximityTest.PlanetsClient.ViewModels;

namespace ProximityTest.PlanetsClient.Infrastructure
{
    public class InstanceLocator
    {
        public MainViewModel Main { get; set; }

        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }
    }
}
