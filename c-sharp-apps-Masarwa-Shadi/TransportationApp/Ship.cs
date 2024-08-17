using c_sharp_apps_Masarwa_Shadi.TransportationApp.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static c_sharp_apps_Masarwa_Shadi.TransportationApp.shared.CargoVehicle;

namespace c_sharp_apps_Masarwa_Shadi.TransportationApp
{
    public class Ship : MultiUnitVehicle
    {
        public Ship(Vehicle type, int maxNumOfContainers) : base(type, maxNumOfContainers)
        {
        }
    }
}
