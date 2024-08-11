using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Masarwa_Shadi.TransportationApp.shared
{
    public class AddData
    {
        private List<ElecticDeviceItem> electricDevices = new List<ElecticDeviceItem>();
        //private List<FurnitureItem> furnitureItems;
        //private List<GeneralItem> generalItems;

        private static List<IPortable> portItems;
        public Port portA = new Port("Port A", "Israel", 100 * 100, 25 * 100, 200 * 100, 178000, portItems);
        //public Warehouse w1 = new Warehouse("Warehouse A", "Israel", 80 * 100, 10 * 100, 100 * 100, 178000, portItems);
        
        public void AddToProducts()
        {
            public ElecticDeviceItem electric1 = new ElecticDeviceItem("BQ987ER", "Samsung", 120, 8, 50, 3.5, false, true, false, portA, "TV", 240);
            public ElecticDeviceItem electric2 = new ElecticDeviceItem("PO7123I", "Xiaomi", 150, 6, 60, 2.8, false, true, false, portA, "TV", 240);
            electricDevices.Add(electic1);
        }
    }
}
