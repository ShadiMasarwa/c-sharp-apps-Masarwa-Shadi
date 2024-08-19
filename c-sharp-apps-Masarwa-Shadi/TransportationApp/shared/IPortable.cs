using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Masarwa_Shadi.TransportationApp.shared
{
    public interface IPortable
    {
        string Name { get; }
        string Sku { get; }
        string Type { get; }
        double Width { get; }
        double Height { get; }
        double Length { get; }
        ElecticDeviceItem Wattage { get; }

        double GetVolumeInCm();
        double GetVolume();
        double GetWeight();
        void SetWeight(double value);
        void PackageItem();
        bool IsPackaged();
        void UnPackage();
        bool IsFragile();
        void SetAsFragile();
        bool IsLoaded();
        void SetAsLoaded();
        void SetAsUnloaded();
        //StorageStructure GetLocation();


    }
}
