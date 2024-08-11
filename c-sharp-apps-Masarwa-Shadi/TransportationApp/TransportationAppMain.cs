using c_sharp_apps_Masarwa_Shadi.TransportationApp.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Masarwa_Shadi.TransportationApp
{
    public class TransportationAppMain
    {
        public static void MainEntry()
        {
            List<IPortable> portItems = new List<IPortable>();
            Port portA = new Port("Port A", "Israel", 100 * 100, 25 * 100, 200 * 100, 178000, portItems);
            List<ElecticDeviceItem> electricDevices = GetElectricDevices(portA);

            //private List<FurnitureItem> furnitureItems;
            //private List<GeneralItem> generalItems;

            //private static ;

            //
            //private Warehouse w1 = new Warehouse("Warehouse A", "Israel", 80 * 100, 10 * 100, 100 * 100, 178000, portItems);

            //private ElecticDeviceItem electric1 = new ElecticDeviceItem("BQ987ER", "Samsung", 120, 8, 50, 3.5, false, true, false, portA, "TV", 240);
            //private ElecticDeviceItem electric2 = new ElecticDeviceItem("PO7123I", "Xiaomi", 150, 6, 60, 2.8, false, true, false, portA, "TV", 240);
        }

        private List<ElecticDeviceItem> GetElectricDevices(StorageStructure location)
        {
            List<ElecticDeviceItem> electicDeviceItems = new List<ElecticDeviceItem>
            {
                new ElecticDeviceItem("TQ987ER", "Samsung", 120, 8, 50, 3.5, false, true, false, location, "TV", 240),
                new ElecticDeviceItem("TO7123I", "Xiaomi", 150, 6, 60, 2.8, false, true, false, location, "TV", 240),
                new ElecticDeviceItem("WY0187O", "Samsung", 60, 1.3, 60, 56, false, true, false, location, "Washing Machine", 240),
                new ElecticDeviceItem("CF5974P", "Hp", 35, 3, 25, 1, false, true, false, location, "Computer", 240),
                new ElecticDeviceItem("CI4921M", "Asus", 32, 3, 23, 1.1, false, true, false, location, "Computer", 240),
                new ElecticDeviceItem("XY453PL", "LG", 45, 30, 30, 2.3, true, false, true, location, "Microwave", 700),
                new ElecticDeviceItem("KL234RT", "Sony", 85, 10, 55, 4.8, false, true, false, location, "Sound System", 120),
                new ElecticDeviceItem("MN786YU", "Dyson", 25, 40, 25, 1.8, true, false, true, location, "Vacuum Cleaner", 600),
                new ElecticDeviceItem("PQ098OI", "Philips", 20, 15, 25, 1.2, true, false, true, location, "Coffee Maker", 1000),
                new ElecticDeviceItem("RT123GH", "Panasonic", 60, 20, 40, 3.2, true, true, false, location, "Air Purifier", 45),
                new ElecticDeviceItem("UW345JK", "Apple", 30, 30, 20, 1.5, true, true, false, location, "iPad", 18),
                new ElecticDeviceItem("VC987LP", "Canon", 35, 25, 15, 2.1, true, true, true, location, "Camera", 15),
                new ElecticDeviceItem("BN654QW", "Whirlpool", 120, 90, 65, 60.5, false, false, false, location, "Refrigerator", 150),
                new ElecticDeviceItem("DF345ZX", "Samsung", 80, 10, 45, 5.0, false, true, false, location, "Monitor", 65),
                new ElecticDeviceItem("GH456CV", "Bose", 20, 15, 20, 0.9, true, true, false, location, "Bluetooth Speaker", 20)

            };
            return electicDeviceItems;
        }


    }
}
