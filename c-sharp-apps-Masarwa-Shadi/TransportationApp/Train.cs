using c_sharp_apps_Masarwa_Shadi.TransportationApp.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Masarwa_Shadi.TransportationApp
{
    public class Train : CargoVehicle
    {
        private List<Crone> crones;

        public Train(Vehicle type, int numOfCrones) : base(type)
        {
        }
    }
}
