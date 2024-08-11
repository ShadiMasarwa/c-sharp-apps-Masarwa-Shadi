using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Masarwa_Shadi.TransportationApp.shared
{
    public interface IPortable
    {
        double GetVolume();
        double GetWeight();
        void PackageItem();
        bool IsPackaged();
        void UnPackage();
        bool IsFragile();
        void SetAsFragile();
        bool IsLoaded();
        StorageStructure GetLocation();

    }
}
