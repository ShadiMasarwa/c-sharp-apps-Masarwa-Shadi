using c_sharp_apps_Masarwa_Shadi.TransportationApp.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Masarwa_Shadi.TransportationApp
{
    public class Crone : CargoVehicle
    {
        public Crone(Vehicle type, double width, double height, double length, double maxWeight, List<IPortable> items) : base(type, width, height, length, maxWeight, items)
        {
        }
    }
}
