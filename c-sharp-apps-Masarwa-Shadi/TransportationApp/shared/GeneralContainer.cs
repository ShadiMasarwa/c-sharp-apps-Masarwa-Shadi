using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Masarwa_Shadi.TransportationApp.shared
{
    public class GeneralContainer
    {
        private List<IPortable> items;
        private double width;
        private double height;
        private double length;
        private double maxWeight;

        public GeneralContainer(List<IPortable> items, double width, double height, double length, double maxWeight)
        {
            this.items = items;
            this.width = width;
            this.height = height;
            this.length = length;
            this.maxWeight = maxWeight;
        }

        public List<IPortable> Items { get => items; set => items = value; }
        public double Width { get => width; set => width = value; }
        public double Height { get => height; set => height = value; }
        public double Length { get => length; set => length = value; }
        public double MaxWeight { get => maxWeight; set => maxWeight = value; }

        public double GetRoomVolume()
        {
            double volumeOfItems = 0;
            double croneStorageVolume = Width * Height * Length;
            if (Items == null || Items.Count == 0)
                return croneStorageVolume;
            foreach (IPortable item in Items)
                volumeOfItems += item.GetVolume();
            return croneStorageVolume - volumeOfItems;
        }
    }
}
