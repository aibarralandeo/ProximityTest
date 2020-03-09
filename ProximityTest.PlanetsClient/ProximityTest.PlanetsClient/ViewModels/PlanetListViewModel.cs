using ProximityTest.PlanetsClient.Helpers;
using ProximityTest.PlanetsClient.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms.Internals;

namespace ProximityTest.PlanetsClient.ViewModels
{
    public class PlanetListViewModel : BaseViewModel
    {
        private ObservableCollection<Planet> planetList;
        private bool isRefreshing = false;

        public ObservableCollection<Planet> PlanetList
        {
            get { return planetList; }
            set { this.SetProperty(ref this.planetList, value); }
        }

        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set { this.SetProperty(ref this.isRefreshing, value); }
        }

        public ICommand RefreshCommand { get; set; }

        public PlanetListViewModel()
        {
            this.PlanetList = new ObservableCollection<Planet>();
            this.RefreshCommand = new RelayCommand(CallService);
            CallService();
        }

        private void CallService()
        {
            if (ConnectivityStatus.IsConnected())
            {
                var online = RefreshData();
                PlanetList = new ObservableCollection<Planet>(online);
                this.IsRefreshing = false;
            }
        }

        public IEnumerable<Planet> RefreshData()
        {
            var planets = new List<Planet>();

            if (ConnectivityStatus.IsConnected())
            {
                this.IsRefreshing = true;

                Task.Run(async () => await App.Service.GetPlanetsAsync().ContinueWith(taskResult =>
                {
                    if(taskResult.IsCompleted && !taskResult.IsFaulted)
                    {
                        taskResult.Result.ForEach(e => planets.Add(new Planet { Name = e.Name, Picture = e.Picture }));
                    }
                })).Wait();
            }

            return planets;
        }
    }
}
