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
        private List<List<IPortable>> items;

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
        

        public double GetStorageVolume()
        {
            return width*height*length;
        }

        public bool Load(IPortable item)
        {
            double roomInStorage = GetRoomInStorage();
            double itemVolume = item.GetVolume();
            double itemWeight = item.GetWeight();
            double weightLeftInStorage = GetLeftWeight();
            if (itemVolume > roomInStorage || itemWeight > weightLeftInStorage)
            {
                Console.WriteLine($"{item.Name} volume or weight exceeds empty space or weight in {name}");
                return false;
            }

            foreach (List<IPortable> products in Items)
            {
                foreach (IPortable product in products)
                {
                    if (product.Equals(item))
                    {
                        products.Add(item);
                        Console.WriteLine($"Item ({item.Name}) successfuly loaded to {name}");
                        return true;
                    }
                    else
                        continue;
                }
            }
            List<IPortable> newList = new List<IPortable> { item };
            Items.Add(newList);
            Console.WriteLine($"New item ({item.Name}) successfuly loaded to {name}");
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
                Console.WriteLine($"All {countOfProductsInList} products were loaded successfully to {name}");
            else
                Console.WriteLine($"{countOfProductsInList - countOfUnloadedProducts}  products were loaded successfully to {name}");
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
                        Console.WriteLine($"Item {product.Name} was unloaded from {name}");
                        return;
                    }
                }
            }
            Console.WriteLine($"Item {item.Name} not found in {name}");
        }

        public void Unload(List<IPortable> lst)
        {
            foreach (IPortable item in lst)
            {
                Unload(item);
            }
        }

        
    }
}
