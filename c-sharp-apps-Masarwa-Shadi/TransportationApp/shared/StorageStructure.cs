using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Masarwa_Shadi.TransportationApp.shared
{
    public abstract class StorageStructure : IContainable
    {
        protected string name;
        private string country;
        private double width;
        private double height;
        private double length;
        private double maxWeight;
        private List<IPortable> items;

        public StorageStructure(string name, string country, double width, double height, double length, double maxWeight, List<IPortable> items)
        {
            this.name = name;
            this.country = country;
            this.width = width;
            this.height = height;
            this.length = length;
            this.maxWeight = maxWeight;
            this.items = items;
        }

        public List<IPortable> Items { get => items; set => items = value; }
        public string Name { get => name; set => name = value; }
        public string Country { get => country; set => country = value; }
        public double Width { get => width; set => width = value; }
        public double Height { get => height; set => height = value; }
        public double Length { get => length; set => length = value; }
        public double MaxWeight { get => maxWeight; set => maxWeight = value; }
        public bool Load(IPortable item)
        {
            double volumeOfItem = item.GetVolume();
            double volumeOfStorage = Width * Height * Length;
            double volumeRoomInStorage = volumeOfStorage - GetItemsVolumeInStorage();
            double weightOfItem = item.GetWeight();
            double weigthRoomInStorage = MaxWeight - GetWeigthOfItemsInStorage();
            if (volumeOfItem > volumeRoomInStorage || weightOfItem > weigthRoomInStorage)
                return false;
            Items.Add(item);
            return true;
        }

        private double GetItemsVolumeInStorage()
        {
            double volume = 0;
            foreach (IPortable product in Items)
                volume += product.GetVolume();
            return volume;
        }

        private double GetWeigthOfItemsInStorage()
        {
            double weight = 0;
            foreach (IPortable product in Items)
                weight += product.GetWeight();
            return weight;
        }

        public void Unload(IPortable item)
        {
            Items.Remove(item);
        }
    }
}
