using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Masarwa_Shadi.TransportationApp.shared
{
    // Containers including train crones
    public class MultiUnitVehicle:CargoVehicle
    {
        private List<GeneralContainer> units;
        private int maxNumOfUnits;
        private int numOfUnits = 0;
        private double unitWidth = 3;
        private double unitHeight = 2;
        private double unitLength = 5;
        private double unitMaxWeight = 1000;

        public MultiUnitVehicle(Vehicle type, int maxNumOfUnits) : base(type)
        {
            this.maxNumOfUnits = maxNumOfUnits;
        }

        public int MaxNumOfUnits { get => maxNumOfUnits; set => maxNumOfUnits = value; }
        public int NumOfUnits { get => numOfUnits; set => numOfUnits = value; }
        public List<GeneralContainer> Units { get => units; set => units = value; }

        public override bool Load(IPortable item)
        {
            if (!item.IsPackaged())
            {
                Message = $"Item {item.Name} is not packaged and can't be loaded";
                return false;
            }
            if (item.IsLoaded())
            {
                Message = $"Item {item.Name} configured as loaded and can't be loaded";
                return false;
            }
            if (item.GetVolume()>unitWidth*unitLength*unitHeight || item.GetWeight() > unitMaxWeight)
            {
                Message = $"Item {item.Name}'s volume or weight exceeds Container/Crone capacity";

            }

            int numOfUnitWithRoom = NumOfUnitWithRoom(item);
            if (numOfUnitWithRoom == -1)
            {
                if (numOfUnits == maxNumOfUnits)
                {
                    Message = $"Containers/Crones are full. Item ({item.Name}) was not loaded";
                    return false;
                }
                item.SetAsLoaded();
                List<IPortable> newLst = new List<IPortable> { item };
                GeneralContainer newUnit = new GeneralContainer(newLst, unitWidth, unitHeight, unitLength, unitMaxWeight);
                if (Units == null)
                {
                    Units = new List<GeneralContainer>();
                }
                Units.Add(newUnit);
                numOfUnits++;
                return true;
            }
            item.SetAsLoaded();
            Units[numOfUnitWithRoom].Items.Add(item);
            Message = $"Item ({item.Name}) was loaded successfully to {Type}";
            return true;
        }

        public bool Load(List<List<IPortable>> items)
        {
            int unloadedCount = 0;
            foreach (List<IPortable> lst in items)
                foreach (IPortable item in lst)
                {
                    if (!Load(item))
                        unloadedCount++;
                }
            return unloadedCount == 0;
        }

        public override void Unload(IPortable item)
        {
            bool success = false;
            foreach (GeneralContainer unit in Units)
                foreach (IPortable product in unit.Items)
                    if (product.Equals(item))
                    {
                        unit.Items.Remove(item);
                        success = true;
                        Message = $"Item ({item.Name}) removed successfully from {Type}";
                    }
            if (!success)
                Message = $"Item ({item.Name}) not found on {Type}";
        }

        private int NumOfUnitWithRoom(IPortable item)
        {
            if (Units == null) return -1;
            int num = -1;
            foreach (GeneralContainer unit in Units)
            {
                num++;
                if (unit.GetRoomVolume() >= item.GetVolume() && item.GetWeight()<=GetLeftWeightInUnit(unit))
                    return num;
            }
            return -1;
        }

        private double GetLeftWeightInUnit(GeneralContainer unit)
        {
            double itemsWeight = 0;
            foreach (IPortable item in unit.Items)
                itemsWeight += item.GetWeight();
            return unit.MaxWeight-itemsWeight;
        }

        public override bool ExecuteShippingTo(StorageStructure target)
        {
            if (Units == null || NumOfItemsInUnits() == 0)
            {
                Message = $"No products loaded to {Type}. Shippment can't be executed!!";
                return false;
            }

            if (!Driver.ApproveShipping)
            {
                Message = $"Driver did not approve execution!!";
                return false;
            }
            int loadedItemsToTarget = 0;
            int initialNumOfItems = NumOfItemsInUnits();
            foreach (GeneralContainer container in Units)
                foreach (IPortable item in container.Items)
                {
                    if (target.Load(item))
                        loadedItemsToTarget++;
                }
            Units = new List<GeneralContainer>();
            return initialNumOfItems == loadedItemsToTarget;
        }

        private int NumOfItemsInUnits()
        {
            int count = 0;
            if (Units == null) return 0;
            foreach (GeneralContainer container in Units)
                foreach (IPortable item in container.Items)
                    count++;

            return count;
        }


        private GeneralContainer CreateNewContainersInfo()
        {
            string cargo = Vehicle.Ship == Type ? "Container" : "Crone";
            Console.WriteLine("\n---------------------------");
            Console.WriteLine($"   Create new {cargo}");
            Console.WriteLine("---------------------------");
            Console.Write($"Enter width of {cargo} (meters): ");
            double w = int.Parse(Console.ReadLine());
            Console.Write($"Enter length of {cargo} (meters): ");
            double l = int.Parse(Console.ReadLine());
            Console.Write($"Enter height of {cargo} (meters): ");
            double h = int.Parse(Console.ReadLine());
            Console.Write($"Enter max cargo weight of {cargo} (kg): ");
            double mw = int.Parse(Console.ReadLine());
            GeneralContainer container = new GeneralContainer(null, w, h, l, mw);
            return container;
        }
    }
}
