using System;
using System.Collections.Generic;
using System.Text;

namespace ProximityTest.PlanetsClient.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public PlanetListViewModel PlanetList { get; set; }

        public MainViewModel()
        {
            this.PlanetList = new PlanetListViewModel();
        }
    }
}
