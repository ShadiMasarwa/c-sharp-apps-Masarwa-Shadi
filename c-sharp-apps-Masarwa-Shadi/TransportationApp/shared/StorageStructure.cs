using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static c_sharp_apps_Masarwa_Shadi.TransportationApp.shared.CargoVehicle;

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
        private List<List<IPortable>> items;
        private string message;

        public StorageStructure(string name, string country, double width, double height, double length, double maxWeight, List<List<IPortable>> items)
        {
            this.name = name;
            this.country = country;
            this.width = width;
            this.height = height;
            this.length = length;
            this.maxWeight = maxWeight;
            this.items = items;
        }

        public List<List<IPortable>> Items { get => items; set => items = value; }
        public string Name { get => name; set => name = value; }
        public string Country { get => country; set => country = value; }
        public double Width { get => width; set => width = value; }
        public double Height { get => height; set => height = value; }
        public double Length { get => length; set => length = value; }
        public double MaxWeight { get => maxWeight; set => maxWeight = value; }
        public string Message { get => message; set => message = value; }

        public double GetStorageVolume()
        {
            return width*height*length;
        }

        public bool Load(IPortable item)
        {
            if (Items==null || Items.Count == 0)
            {
                item.SetAsUnloaded();
                Items = new List<List<IPortable>> { new List<IPortable> { item } };
                Message = $"New item ({item.Name}) successfuly loaded to {name}";
                return true;
            }

            double roomInStorage = GetRoomInStorage();
            double itemVolume = item.GetVolume();
            double itemWeight = item.GetWeight();
            double weightLeftInStorage = GetLeftWeight();
            if (itemVolume > roomInStorage || itemWeight > weightLeftInStorage)
            {
                Message = $"{item.Name} volume or weight exceeds empty space or weight in {name}";
                return false;
            }
           

            foreach (List<IPortable> products in Items)
            {
                foreach (IPortable product in products)
                {
                    if (product.Equals(item))
                    {
                        item.SetAsUnloaded();
                        products.Add(item);
                        Message = $"Item ({item.Name}) successfuly loaded to {name}";
                        return true;
                    }
                    //else
                    //    continue;
                }
            }
            item.SetAsUnloaded();
            List<IPortable> newList = new List<IPortable> { item };
            Items.Add(newList);
            Message= $"New item ({item.Name}) successfuly loaded to {name}";
            return true;
        }

        private double GetLeftWeight()
        {
            double weightOfProductsInStorage = 0;
            double storageMaxWeight = MaxWeight;
            foreach (List<IPortable> products in Items)
            {
                foreach (IPortable product in products)
                {
                    weightOfProductsInStorage += product.GetWeight();
                }
            }
            return storageMaxWeight - weightOfProductsInStorage;
        }

        public double GetRoomInStorage()
        {
            double volumeOfProductsInStorage = 0;
            double storageMaxVolume = GetStorageVolume();
            foreach (List<IPortable> products in Items)
            {
                foreach (IPortable product in products)
                {
                    volumeOfProductsInStorage += product.GetVolume();
                }
            }
            return storageMaxVolume - volumeOfProductsInStorage;
        }

        public bool Load(List<IPortable> lst)
        {
            bool flag = true;
            int countOfUnloadedProducts = 0;
            int countOfProductsInList = 0;
            foreach (IPortable item in lst)
            {
                countOfProductsInList++;
                if (!Load(item))
                {
                    flag = false;
                    countOfUnloadedProducts++;
                }
            }
            if (flag)
                Message = $"All {countOfProductsInList} products were loaded successfully to {name}";
            else
                Message = $"{countOfProductsInList - countOfUnloadedProducts}  products were loaded successfully to {name}";
            return flag;
        }

        public void Unload(IPortable item)
        {
            foreach (List<IPortable> lst in Items)
            {
                foreach (IPortable product in lst)
                {
                    if (product.Equals(item))
                    {
                        lst.Remove(product);
                        if (lst.Count == 0)
                        {
                            Items.Remove(lst);
                        }
                        Message = $"Item {product.Name} was unloaded from {name}";
                        return;
                    }
                }
            }
            Message = $"Item {item.Name} not found in {name}";
        }

        public void Unload(List<IPortable> lst)
        {
            foreach (IPortable item in lst)
            {
                Unload(item);
            }
        }

        public bool MoveItemToVehicleContainers(CargoVehicle vehicle, IPortable itemToMove)
        {
            if (!isExist(itemToMove)) return false;
            if (vehicle.Load(itemToMove))
            {
                itemToMove.SetAsUnloaded();
                foreach (List<IPortable> lst in Items)
                    foreach(IPortable item in lst)
                        if (item.Equals(itemToMove))
                        {
                            lst.Remove(itemToMove);
                            itemToMove.SetAsLoaded();
                            return true;
                        }
            }
            return false;

        }
        public bool MoveItemToVehicleContainers(CargoVehicle vehicle, List<IPortable> itemsToTransfer)
        {
            if (itemsToTransfer == null || itemsToTransfer.Count == 0) return false;
            List<IPortable> itemsCopy = new List<IPortable>(itemsToTransfer);
            int count = 0;
            int numOfItems = itemsCopy.Count;

            foreach (IPortable item in itemsCopy)
            {
                if (MoveItemToVehicleContainers(vehicle, item))
                {
                    count++;
                }
            }

            return count == numOfItems;
        }

        public bool MoveItemToVehicle(CargoVehicle vehicle, IPortable itemToMove)
        {
            if (vehicle.Type != Vehicle.Airplane)
            {
                return MoveItemToVehicleContainers(vehicle, itemToMove);
            }
            if (!isExist(itemToMove)) 
            {
                Message = $"Item ({itemToMove.Name}) not found in {vehicle.Type}";
                return false;
            }
            if(!itemToMove.IsPackaged() || itemToMove.IsLoaded())
            {
                Message = $"Item ({itemToMove.Name}) is not packaged or already loaded to vehicle";
                return false;
            }
            if (itemToMove.GetVolume() > vehicle.GetRoomInVehicle() || itemToMove.GetWeight()>vehicle.MaxWeight)
            {
                Message = $"Item ({itemToMove.Name})'s size or weight exceeds capacity of {vehicle.Type}";
                return false;
            }
            if (vehicle.Items == null)
            {
                Unload(itemToMove);
                itemToMove.SetAsLoaded();
                List<IPortable> lst = new List<IPortable> { itemToMove };
                vehicle.Items = lst;
                Message = $"Item ({itemToMove.Name}) moved from {name} to {vehicle.Type}";
                return true;
            }
            if (vehicle.GetRoomInVehicle()<itemToMove.GetVolume() || vehicle.GetWeightLeft()<itemToMove.GetWeight())
            {
                Message = $"There is no enough room for ({itemToMove.Name}) in {vehicle.Type}";
                return false;
            }
            Unload(itemToMove);
            itemToMove.SetAsLoaded();
            vehicle.Load(itemToMove);
            Message = $"Item ({itemToMove.Name}) moved from {name} to {vehicle.Type}";
            return true;
        }

        public bool MoveItemToVehicle(CargoVehicle vehicle, List<IPortable> itemsToMove)
        {
            if (vehicle.Type != Vehicle.Airplane)
            {
                return MoveItemToVehicleContainers(vehicle, itemsToMove);
            }
            int itemsMoved = 0;
            foreach(IPortable item in itemsToMove)
            {
                if(MoveItemToVehicle(vehicle, item))
                    itemsMoved++;
            }
            Message = $"{itemsMoved} items moved from {name} to {vehicle.Type}";
            if (itemsMoved != itemsToMove.Count())
                return false;
            return true;
        }

        private bool isExist(IPortable item)
        {
            if(Items==null || Items.Count()==0) return false;
            foreach (List<IPortable> products in Items)
            {
                foreach (IPortable product in products)
                {
                    if (product.Equals(item))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public int GetNumOfItemsInStorage()
        {
            int count = 0;
            if (Items == null) return 0;
            foreach (List<IPortable> lst in Items)
                foreach (IPortable item in lst)
                    count++;
            return count;
        }




    }
}
