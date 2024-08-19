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
        //private string type;
        private int wattage;

        public ElecticDeviceItem(string sku, string name, double width, double height, double length, double weight, bool packaged, bool fragile, bool loaded, StorageStructure location, string type, int wattage) : base(sku, name, width, height, length, weight, packaged, fragile, loaded, location, type)
        {
            Wattage = wattage;
        }

        //public string Type { get => type; set => type = value; }
        public new int Wattage { get => wattage; set => wattage = value; }
    }
}
