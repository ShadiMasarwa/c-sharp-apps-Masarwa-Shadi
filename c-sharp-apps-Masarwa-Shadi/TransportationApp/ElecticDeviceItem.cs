using c_sharp_apps_Masarwa_Shadi.TransportationApp.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Masarwa_Shadi.TransportationApp
{
    public class ElecticDeviceItem : Product
    {
        private string type;
        private int watt;

        public ElecticDeviceItem(string sku, string name, double width, double height, double length, double weight, bool packaged, bool fragile, bool loaded, StorageStructure location, string type, int watt) : base(sku, name, width, height, length, weight, packaged, fragile, loaded, location)
        {
            Type = type;
            Watt = watt;
        }

        public string Type { get => type; set => type = value; }
        public int Watt { get => watt; set => watt = value; }
    }
}
