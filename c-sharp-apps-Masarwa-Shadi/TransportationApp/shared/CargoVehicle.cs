using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Masarwa_Shadi.TransportationApp.shared
{
    public abstract class CargoVehicle : IContainable
    {
        public enum Vehicle
        {
            Train,
            Ship,
            Airplane
        }
        private Vehicle type;
        private double width;
        private double height;
        private double length;
        private double maxWeight;
        private List<IPortable> items;
        private Driver driver;
        private string message;
        public CargoVehicle(Vehicle type, double width, double height, double length, double maxWeight, List<IPortable> items)
        {
            this.type = type;
            this.width = width;
            this.height = height;
            this.length = length;
            this.maxWeight = maxWeight;
            this.items = items;
        }

        public CargoVehicle(Vehicle type)
        {
            this.type = type;
        }

        public List<IPortable> Items { get => items; set => items = value; }
        public Vehicle Type { get => type; set => type = value; }
        public double Width { get => width; set => width = value; }
        public double Height { get => height; set => height = value; }
        public double Length { get => length; set => length = value; }
        public double MaxWeight { get => maxWeight; set => maxWeight = value; }
        public Driver Driver { 
            get => driver;
            set => driver = (type.ToString() != value.LicenseSort.ToString()) ? null : value;} 
        public string Message { get => message; set => message = value; }

        public virtual bool Load(IPortable item)
        {
            double volumeOfItem = item.GetVolume();
            double weightOfItem = item.GetWeight();
            double weigthRoomInStorage = MaxWeight - GetWeigthOfItemsInVehicle();
            if (volumeOfItem > GetRoomInVehicle() || weightOfItem > weigthRoomInStorage)
            {
                Message = $"Volume or Weight of {item.Name} exceeds vehicle capacity";
                return false;
            }
            Items.Add(item);
            Message = $"Item ({item.Name}) was loaded to vehicle successfully";
            return true;
        }

        public double GetRoomInVehicle()
        {
            double volumeOfStorage = Width * Height * Length;
            return volumeOfStorage - GetItemsVolumeInVehicle();
        }

        public double GetItemsVolumeInVehicle()
        {
            if (Items == null || Items.Count == 0) return 0;
            double volume = 0;
            foreach (IPortable product in  Items)
                volume += product.GetVolume();
            return volume;
        }

        public double GetWeigthOfItemsInVehicle()
        {
            if (Items == null) return 0;
            double weight = 0;
            foreach (IPortable product in Items)
                weight += product.GetWeight();
            return weight;
        }

        public double GetWeightLeft()
        {
            return maxWeight- GetWeigthOfItemsInVehicle();
        }

        public virtual void Unload(IPortable item)
        {
            Items.Remove(item);
        }

        public virtual bool ExecuteShippingTo(StorageStructure target)
        {
            if (Items == null || Items.Count == 0)
            {
                Message =$"No products loaded to {Type}. Shippment can't be executed!!";
                return false;
            }

            if (!Driver.ApproveShipping)
            {
                Message = $"Driver did not approve execution!!";
                return false;
            }
            int loadedItemsToTarget = 0;
            int initialNumOfItems = Items.Count();
            List<IPortable> newLst = new List<IPortable>(Items);
            foreach(IPortable item in newLst)
            {
                if (target.Load(item)){
                    Items.Remove(item);
                    loadedItemsToTarget++;
                }
            }
            return initialNumOfItems==loadedItemsToTarget;
        }

        public abstract int NumOfItemsInUnits();
    }
}
