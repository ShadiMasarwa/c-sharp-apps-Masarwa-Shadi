using c_sharp_apps_Masarwa_Shadi.TransportationApp.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Masarwa_Shadi.TransportationApp
{
    public class Port : StorageStructure
    {
        public Port(string name, string country, double width, double height, double length, double maxWeight, List<IPortable> items) : base(name, country, width, height, length, maxWeight, items)
        {
        }

        
    }
}
