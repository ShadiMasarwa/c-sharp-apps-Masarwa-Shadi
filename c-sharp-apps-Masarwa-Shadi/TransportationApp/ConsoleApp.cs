using c_sharp_apps_Masarwa_Shadi.BankApp;
using c_sharp_apps_Masarwa_Shadi.DraftApp;
using c_sharp_apps_Masarwa_Shadi.SportApp;
using c_sharp_apps_Masarwa_Shadi.StockDemo;
using c_sharp_apps_Masarwa_Shadi.TransportationApp.shared;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static c_sharp_apps_Masarwa_Shadi.TransportationApp.shared.CargoVehicle;

namespace c_sharp_apps_Masarwa_Shadi.TransportationApp
{
    public class ConsoleApp
    {
        private static List<IPortable> products = new List<IPortable>();
        private static List<CargoVehicle> vehicles = new List<CargoVehicle>();
        private static List<StorageStructure> warehouses = new List<StorageStructure>();
        private static List<Driver> drivers = new List<Driver>();
        


        public static void RunApp()
        {
            ImportInitialInfo(warehouses, vehicles, drivers);
            Console.ForegroundColor = ConsoleColor.White;
            bool finish = false;
            while (!finish)
            {
                PrintHeader("Main Menu");
                Console.WriteLine($"1. Manage warehouses ({warehouses.Count} Exist)");
                Console.WriteLine($"2. Manage vehicles ({vehicles.Count} Exist)");
                //Console.WriteLine($"3. Manage products ({products.Count} Exist)");
                Console.WriteLine($"3. Manage drivers ({drivers.Count} Exist)\n");
                Console.WriteLine("4. Process Shipment");
                Console.WriteLine("\n0. Exit app");
                Dash();
                Console.Write("Enter choice: ");
                char ch = Console.ReadKey().KeyChar;
                Console.WriteLine();
                int choice = ch - 48;
                switch (choice)
                {
                    case 1:
                        ManageWarehouses();
                        break;
                    case 2:
                        ManageVehicles();
                        break;
                    case 3:
                        ManageDrivers();
                        break;
                    case 4:
                        ProcessShipment();
                        break;
                    case 0:
                        finish = true;
                        break;

                }
            }

        }

        /////////////////////////////////////////////////////
        //              Process shipment section           //
        /////////////////////////////////////////////////////

        private static void ProcessShipment()
        {
            List<string> problems = new List<string>();
            PrintHeader("Process Shipment");
            if(warehouses.Count<2)
                problems.Add($"System must have 2 storages at least (Source and Target).Found - {warehouses.Count}");
            if (vehicles.Count < 1)
                problems.Add($"System must have 1 vehicle at least to process shipment. Found - {vehicles.Count}");
            if(drivers.Count<1)
                problems.Add($"System must have 1 vehicle driver at least to drive vehicle. Found - {drivers.Count}");
            bool hasProducts = false;
            foreach (StorageStructure storage in warehouses)
                if (storage.GetNumOfItemsInStorage() != 0)
                    hasProducts = true;
            if (!hasProducts)
                problems.Add("There are no products in any of the storages.");

            if (problems.Count != 0)
            {
                FColorChange("green");
                Console.WriteLine("\n\nPlease Correct these problems to proceed shipment");
                Console.WriteLine("-------------------------------------------------");
                FColorChange("white");
                int num = 0;
                foreach (string problem in problems)
                {
                    num++;
                    FColorChange("red");
                    Console.Write(num);
                    FColorChange("white");
                    Console.WriteLine(") " + problem);
                }
                Console.ReadKey();
                return;
            }
            bool finish = false;
            bool stage1 = false, stage2 = false, stage3 = false, stage4 = false;
            StorageStructure source = null;
            StorageStructure target = null;
            CargoVehicle vehicle = null;

            while (!finish)
            {
                PrintHeader("Process Shipment");
                Console.Write("1. Choose Source Storage - ");
                if (source == null)
                {
                    FColorChange("red");
                    Console.WriteLine("Not Compleated");
                    FColorChange("white");
                }
                else
                {
                    Console.Write($" (");
                    FColorChange("yellow");
                    Console.Write($"{ source.Name}");
                    FColorChange("white");
                    Console.Write(") - ");
                    FColorChange("green");
                    Console.WriteLine("Compleated");
                    FColorChange("white");
                    stage1 = true;
                }

                Console.Write("2. Choose Destination Storage - ");
                if (target == null)
                {
                    FColorChange("red");
                    Console.WriteLine("Not Compleated");
                    FColorChange("white");
                }
                else
                {
                    Console.Write($" (");
                    FColorChange("yellow");
                    Console.Write($"{target.Name}");
                    FColorChange("white");
                    Console.Write(") - ");
                    FColorChange("green");
                    Console.WriteLine("Compleated");
                    FColorChange("white");
                    stage2 = true;
                }
                Console.Write("3. Choose a Vehicle for shipment - ");
                if (vehicle == null)
                {
                    FColorChange("red");
                    Console.WriteLine("Not Compleated");
                    FColorChange("white");
                }
                else
                {
                    Console.Write($" (");
                    FColorChange("yellow");
                    Console.Write($"{vehicle.Type}");
                    FColorChange("white");
                    Console.Write(") - ");
                    FColorChange("green");
                    Console.WriteLine("Compleated");
                    FColorChange("white");
                    stage3 = true;
                }
                Console.Write("4. Move packaged products from storage to vehicle - ");
                if (vehicle == null || vehicle.Items == null || vehicle.Items.Count==0)
                {
                    FColorChange("red");
                    Console.WriteLine("Not Compleated");
                    FColorChange("white");
                }
                else
                {
                    Console.Write($" (");
                    FColorChange("yellow");
                    Console.Write($"{vehicle.Items.Count}");
                    FColorChange("white");
                    Console.Write(" Products) - ");
                    FColorChange("green");
                    Console.WriteLine("Compleated");
                    FColorChange("white");
                    stage4 = true;
                }
                if (stage1 && stage2 && stage3 && stage4)
                {
                    FColorChange("green");
                    Console.WriteLine("\n5. Process Shipment");
                    FColorChange("white");
                }
                else
                {
                    FColorChange("red");
                    Console.WriteLine("\n5. Process Shipment"); 
                    FColorChange("white");
                }
                Console.WriteLine("\n0. Exit");
                Dash();
                Console.Write("\nEnter Choice: ");

                int choice = Console.ReadKey().KeyChar;
                switch (choice - 48)
                {
                    case 1:
                        source = ChooseSourceStorage();
                        if(target!=null && source.Equals(target))
                        {
                            FColorChange("red");
                            Console.WriteLine("\n\nSource and Destination can't be the same!");
                            FColorChange("white");
                            source= null;
                            Console.ReadKey();
                        }
                        break;
                    case 2:
                        target = ChooseDestinationStorage();
                        if (source != null && source.Equals(target))
                        {
                            FColorChange("red");
                            Console.WriteLine("\n\nSource and Destination can't be the same!");
                            FColorChange("white");
                            target= null;
                            Console.ReadKey();
                        }
                        break;
                    case 3:
                        vehicle = ChooseVehicle();
                        break;
                    case 4:
                        if (source == null || vehicle == null)
                            break;
                        if(MoveProducts(source, ref vehicle))
                        {
                            FColorChange("green");
                            Console.WriteLine($"\n\nAll products from {source.Name} were moved to {vehicle.Type}");
                            FColorChange("white");
                            Console.ReadKey();
                        }
                        else
                        {
                            FColorChange("red");
                            Console.WriteLine($"\n\nNot All products from {source.Name} were moved to {vehicle.Type}");
                            FColorChange("white");
                            Console.ReadKey();
                        }
                        break;
                    case 5:
                        ShipProducts(source, target, vehicle);
                        break;
                    case 0:
                        finish = true;
                        break;
                }
            }
        }

        private static void ShipProducts(StorageStructure source, StorageStructure target, CargoVehicle vehicle)
        {
            PrintHeader("Ship Product");
            Console.Write($"Enter distance between ({source.Name}) to ({target.Name}): ");
            int distance = int.Parse(Console.ReadLine());
            Console.Write($"Do Driver approve shipment (Y/N): ");
            string approve = Console.ReadLine().ToUpper();
            if (approve == "Y")
            {
                vehicle.Driver.ApproveShipping = true;
            }
            else
                return;
            ShippingPriceCalculator.PrintInvoice(vehicle, distance);
            Console.ReadKey();

            if (vehicle.ExecuteShippingTo(target))
            {
                FColorChange("green");
                Console.WriteLine($"\n\nSipment from {source.Name} to {target.Name} using {vehicle.Type} was successfull...");
                FColorChange("white");
                Console.ReadKey();
            }
            else
            {
                FColorChange("red");
                Console.WriteLine($"\n\nSipment from {source.Name} to {target.Name} using {vehicle.Type} was failed!!");
                FColorChange("white");
                Console.ReadKey();
            }
        }

        private static bool MoveProducts(StorageStructure source, ref CargoVehicle vehicle)
        {
            vehicle.Items = new List<IPortable>();
            bool allMoved = true;
            if (source.GetType().Name == "Airplane")
            {
                foreach (List<IPortable> lst in source.Items)
                {
                    if (!source.MoveItemToVehicle(vehicle, lst))
                        allMoved = false;
                }
            }
            else
            {
                foreach (List<IPortable> lst in source.Items)
                {
                    if (!source.MoveItemToVehicleContainers(vehicle, lst))
                        allMoved = false;
                }
            }
            return allMoved;
        }


        private static StorageStructure ChooseSourceStorage()
        {
            PrintHeader("Choose Source Storage");
            StorageStructure storageToSend=null;
            Console.WriteLine("Choose Source Storage:");
            Console.WriteLine("----------------------");
            int num = 0;
            foreach (StorageStructure storage in warehouses)
            {
                num++;
                Console.Write($"{num}) {storage.Name} (Type: ");
                FColorChange("green");
                Console.Write($"{storage.GetType().Name}");
                FColorChange("white");
                Console.WriteLine(")");
            }
            Console.WriteLine("\n0) Back");
            Dash();
            bool finish = false;
            while (!finish)
            {
                Console.Write("Enter choise: ");
                int choice = Console.ReadKey().KeyChar;
                choice = choice - 48;
                if (choice == 0)
                    finish = true;
                else
                {
                    if (!(choice < 0 || choice > num))
                    {
                        if (warehouses[choice - 1].Items == null || warehouses[choice - 1].GetNumOfItemsInStorage() == 0)
                        {
                            FColorChange("red");
                            Console.WriteLine("\n\nYou Choosed a storage with no products as source.\nPlease choose again...\n\n");
                            FColorChange("white");
                        }
                        else
                        {
                            storageToSend = (StorageStructure)warehouses[choice - 1];
                            finish = true;
                        }
                    }
                }
               
            }
            return storageToSend;
        }
        public static StorageStructure ChooseDestinationStorage()
        {
            PrintHeader("Choose Destination Storage");
            StorageStructure storageToSend = null;
            Console.WriteLine("Choose Destination Storage:");
            Console.WriteLine("----------------------");
            int num = 0;
            foreach (StorageStructure storage in warehouses)
            {
                num++;
                Console.Write($"{num}) {storage.Name} (Type: ");
                FColorChange("green");
                Console.Write($"{storage.GetType().Name}");
                FColorChange("white");
                Console.WriteLine(")");
            }
            Console.WriteLine("\n0) Back");
            Dash();
            bool finish = false;
            while (!finish)
            {
                Console.Write("Enter choise: ");
                int choice = Console.ReadKey().KeyChar;
                choice = choice - 48;
                if (choice == 0)
                    finish = true;
                else
                {
                    if (!(choice < 0 || choice > num))
                    {
                            storageToSend = (StorageStructure)warehouses[choice - 1];
                            finish = true;
                    }
                }

            }
            return storageToSend;
        }

        private static CargoVehicle ChooseVehicle()
        {
            PrintHeader("Choose Vehicle");
            Console.WriteLine("List of available vehicles");
            Console.WriteLine("--------------------------");

            int vehicleNum = 0, num = 0, airplane = 0, train = 0, ship = 0;
            foreach (CargoVehicle vehicle in vehicles)
            {
                num++;
                string driverName;
                if (vehicle.Driver == null)
                    driverName = "Not Assigned";
                else
                    driverName = vehicle.Driver.Fname + " " + vehicle.Driver.Lname;
                if (vehicle.Type == CargoVehicle.Vehicle.Airplane)
                {
                    airplane++;
                    Console.WriteLine($"{num}) {vehicle.Type} ({airplane}) - Driver ({driverName})");
                }
                if (vehicle.Type == CargoVehicle.Vehicle.Train)
                {
                    train++;
                    Console.WriteLine($"{num}) {vehicle.Type} ({train}) - Driver ({driverName})");
                }
                if (vehicle.Type == CargoVehicle.Vehicle.Ship)
                {
                    ship++;
                    Console.WriteLine($"{num}) {vehicle.Type} ({ship}) - Driver ({driverName})");
                }
            }
            Console.WriteLine();
            bool finish = false;
            int choice;
            while (!finish)
            {
                FColorChange("yellow");
                Console.Write("Please enter vehicle number (0 to exit): ");
                FColorChange("white");
                string input = Console.ReadLine();
                if (int.TryParse(input, out choice))
                {
                    if (choice == 0) return null;
                    if (!(choice < 1 || choice > num))
                    {
                        vehicleNum = choice - 1;
                        finish = true;
                    }
                }
            }
            if (vehicles[vehicleNum].Driver == null)
            {
                FColorChange("red");
                Console.WriteLine("\n\nVehicle you choosed has no drive!\nAssign driver to veicle before continue!");
                FColorChange("white");
                Console.ReadKey();
                return null;
            }
            return vehicles[vehicleNum];
        }

        /////////////////////////////////////////////////////
        //               Manage storage section            //
        /////////////////////////////////////////////////////

        private static void ManageWarehouses()
        {
            int numPort = 0, numWarehouse = 0;
            foreach (StorageStructure storage in warehouses)
            {
                if (storage.GetType().Name == "Port")
                    numPort++;
                else
                    numWarehouse++;
            }
            bool finish = false;
            while (!finish)
            {
                PrintHeader("Manage Storages");
                Console.WriteLine($"1. Add new port storage ({numPort} Exist)");
                Console.WriteLine($"2. Add new warehouse storage ({numWarehouse} Exist)");
                Console.WriteLine($"3. Display storages details ");
                Console.WriteLine($"4. Add products to storage");
                Console.WriteLine($"5. Display products in storage");
                Console.WriteLine("\n0. Exit");
                Dash();
                Console.Write("Enter choice: ");
                char ch = Console.ReadKey().KeyChar;
                Console.WriteLine();
                int choice = ch - 48;
                switch (choice)
                {
                    case 1:
                        AddStorage("Port");
                        numPort++;
                        break;
                    case 2:
                        AddStorage("Warehouse");
                        numWarehouse++;
                        break;
                    case 3:
                        DisplayStorageDetails();
                        break;
                    case 4:
                        AddProductsToStorage();
                        break;
                    case 5:
                        DisplayProductsInStorage();
                        break;
                    case 0:
                        finish = true;
                        break;

                }
            }
        }

        private static void AddStorage(string portType)
        {
            PrintHeader($"Add {portType}");
            Console.Write($"Enter {portType} name (max 20 chars): ");
            string portName = Console.ReadLine();
            if (portName.Length > 20)
                portName = portName.Substring(0, 20);
            Console.Write($"Enter {portType} country (max 20 chars): ");
            string portCountry = Console.ReadLine();
            if (portCountry.Length > 20)
                portCountry = portCountry.Substring(0, 20);


            bool isValidInput = false;
            double width=0;
            while (!isValidInput)
            {
                Console.Write($"\nEnter Width of {portType} (meters): ");
                string input = Console.ReadLine();
                if (double.TryParse(input, out width))
                {
                    isValidInput = true;
                }
            }
            isValidInput = false;
            double length=0;
            while (!isValidInput)
            {
                Console.Write($"Enter Length of {portType} (meters): ");
                string input = Console.ReadLine();
                if (double.TryParse(input, out length))
                {
                    isValidInput = true;
                }
            }
            isValidInput = false;
            double height = 0;
            while (!isValidInput)
            {
                Console.Write($"Enter Height of {portType} (meters): ");
                string input = Console.ReadLine();
                if (double.TryParse(input, out height))
                {
                    isValidInput = true;
                }
            }
            isValidInput = false;
            double maxWeightCapacity = 0;
            while (!isValidInput)
            {
                Console.Write($"Enter Max Weight Capacity of {portType} (Kg): ");
                string input = Console.ReadLine();
                if (double.TryParse(input, out maxWeightCapacity))
                {
                    isValidInput = true;
                }
            }
            StorageStructure port;
            if(portType=="Port")
                port = new Port(portName, portCountry, width, height, length, maxWeightCapacity, null);
            else
                port = new Warehouse(portName, portCountry, width, height, length, maxWeightCapacity, null);

            warehouses.Add(port);
            FColorChange("green");
            Console.WriteLine($"\n\n{portType} ({portName} in {portCountry}) was added successfully...");
            FColorChange("white");
            Console.ReadKey();

        }

        private static void DisplayStorageDetails()
        {
            if (warehouses.Count == 0)
            {
                FColorChange("red");
                Console.WriteLine("\nNo ports or warehouses found in system!");
                FColorChange("white");
                Console.ReadKey();
                return;
            }
            
            PrintHeader("Display Storages");
            FColorChange("blue");
            Console.WriteLine($"{"   Type   ",-15}{"   Name  ",-21}{"  Country ",-21}{"Width",-10}{"Length",-10}{"Height",-10}{"Weight Capacity",-20}{" Has Products",-10} ");
            FColorChange("red");
            Console.WriteLine($"{"----------",-15}{"---------",-21}{"----------",-21}{"-----",-10}{"------",-10}{"------",-10}{"---------------",-20}{"-------------",-10}");
            FColorChange("white");

            foreach (StorageStructure storage in warehouses)
            {
                string hasItems = (storage.Items == null || storage.Items.Count==0) ? "No" : "Yes";
                Console.WriteLine($"{storage.GetType().Name,-15}{storage.Name,-21}{storage.Country,-21}{storage.Width,-10}{storage.Length,-10}{storage.Height,-10}{storage.MaxWeight,-20}{hasItems,-10} ");
            }
            Console.ReadKey();
        }

        private static void AddProductsToStorage()
        {
            if (warehouses.Count == 0)
            {
                FColorChange("red");
                Console.WriteLine("\nNo ports or warehouses found in system!");
                Console.WriteLine("Products must be loaded to a port or warehouse!");
                FColorChange("white");
                Console.ReadKey();
                return;
            }
            
            PrintHeader("Add Products To Storage");
            FColorChange("yellow");
            Console.WriteLine("Choose Storage To Add Products To:");
            Console.WriteLine("---------------------------------");
            FColorChange("white");
            int num = 0;
            foreach (StorageStructure storage in warehouses)
            {
                num++;
                Console.Write($"{num}) {storage.Name} (Type: ");
                FColorChange("green");
                Console.Write($"{storage.GetType().Name}");
                FColorChange("white");
                Console.WriteLine(")");
            }
            Console.WriteLine("\n0) Back");
            Dash();
            bool finish = false;
            while (!finish)
            {
                Console.Write("Enter choise: ");
                int choice = Console.ReadKey().KeyChar;
                choice = choice - 48;
                if (choice == 0)
                    finish = true;
                else
                    if (!(choice <0 || choice > num))
                {
                    AddProductsToStorage(warehouses[choice-1]);
                    finish = true;
                    num = 0;
                }
            }
            
        }

        private static void AddProductsToStorage(StorageStructure storage)
        {
            
            PrintHeader($"Add Products To { storage.Name}");
            Console.WriteLine("1) Add Products Manually");
            Console.WriteLine("2) Add Products From Database");
            Console.WriteLine("\n0) Exit");
            Dash();

            bool finish = false;
            while (!finish)
            {
                Console.Write("Enter choise: ");
                int choice = Console.ReadKey().KeyChar;
                choice = choice - 48;
                if (choice == 0)
                    finish = true;
                else
                    if (!(choice < 0 || choice > 2))
                {
                    switch (choice)
                    {
                        case 1:
                            AddManualProductToStorage(storage);
                            finish = true;
                            break;
                        case 2:
                            List<List<IPortable>> items = Data.GetInitialData(storage);
                            if (storage.Load(items))
                            {
                                FColorChange("green");
                                Console.WriteLine($"\n\nInitial items were loaded to {storage.Name} successfully...");
                                FColorChange("white");
                            }
                            else
                            {
                                FColorChange("red");
                                Console.WriteLine($"\n\n{storage.Message}...");
                                FColorChange("white");
                            }
                            Console.ReadKey();
                            finish = true;
                            break;
                        case 0:
                            finish = true;
                            break;
                    }
                }
            }

        }

        private static void AddManualProductToStorage(StorageStructure storage)
        {
            PrintHeader($"Add product manually to {storage.Name}");
           
            bool finish = false;
            int classType = 0;
            while (!finish)
            {
                Console.Write("Enter Type (");
                FColorChange("green");
                Console.Write("1. Electric Device, 2. Furniture, 3. General Product");
                FColorChange("white");
                Console.Write("): ");
                int choice = Console.ReadKey().KeyChar;
                choice = choice - 48;
                    if (!(choice <= 0 || choice > 3))
                {
                    classType = choice;
                    finish = true;
                }
                Console.WriteLine();
            }
            Console.Write("Enter Sku: ");
            string sku = Console.ReadLine();
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            
            finish = false;
            double width = 0;
            while (!finish)
            {
                Console.Write("Enter Width (cm): ");
                string input = Console.ReadLine();
                if (double.TryParse(input, out width))
                        finish = true;
            }
            finish = false;
            double length = 0;
            while (!finish)
            {
                Console.Write("Enter Length (cm): ");
                string input = Console.ReadLine();
                if (double.TryParse(input, out length))
                    finish = true;
            }
            finish = false;
            double height = 0;
            while (!finish)
            {
                Console.Write("Enter Height (cm): ");
                string input = Console.ReadLine();
                if (double.TryParse(input, out height))
                    finish = true;
            }
            finish = false;
            double weight = 0;
            while (!finish)
            {
                Console.Write("Enter Weight (kg): ");
                string input = Console.ReadLine();
                if (double.TryParse(input, out weight))
                    finish = true;
            }
            string fragil = "";
            while (fragil!="Y" && fragil != "N")
            {
                Console.Write("Product is fragile (Y/N)?: ");
                fragil = Console.ReadLine().ToUpper();
            }
            string packaged = "";
            while (packaged != "Y" && packaged != "N")
            {
                Console.Write("Product is packaged (Y/N)?: ");
                packaged = Console.ReadLine().ToUpper();
            }
            Console.Write("Enter Product Type: ");
            string type = Console.ReadLine();
            int wattage = 0;
            if (classType == 1)
            {
                finish = false;
                while (!finish)
                {
                    Console.Write("Enter Wattage: ");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out wattage))
                        finish = true;
                }
            }
            bool fragileProduct = fragil == "Y" ? true : false;
            bool packagedProduct = packaged == "Y" ? true : false; 
            
            IPortable product;
            if (classType == 1)
                product = new ElecticDeviceItem(sku, name, width, height, length, weight, packagedProduct, fragileProduct, false, storage, type, wattage);
            else if(classType == 2)
                product = new FurnitureItem(sku, name, width, height, length, weight, packagedProduct, fragileProduct, false, storage, type);
            else 
                product = new GeneralItem(sku, name, width, height, length, weight, packagedProduct, fragileProduct, false, storage, type);
            if (storage.Load(product))
            {
                FColorChange("green");
                Console.WriteLine($"\n\nProduct was added to {storage.Name} successfully...");
                FColorChange("white");
            }
            else
            {
                FColorChange("red");
                Console.WriteLine($"\n\nProduct volume or weight exceeds {storage.Name} capacity!!!");
                Console.WriteLine("Product was not loaded!!!");
                FColorChange("white");
            }
            Console.ReadKey();
        }

        private static void DisplayProductsInStorage()
        {
            PrintHeader("Display Products in Storage");
            if (warehouses.Count == 0)
            {
                FColorChange("red");
                Console.WriteLine("\nNo ports or warehouses found in system!");
                Console.WriteLine("Products must be loaded to a port or warehouse!");
                FColorChange("white");
                Console.ReadKey();
                return;
            }
            
            FColorChange("yellow");
            Console.WriteLine("Choose Storage To Display Products:");
            Console.WriteLine("-----------------------------------");
            FColorChange("white");
            int num = 0;
            foreach (StorageStructure storage in warehouses)
            {
                num++;
                Console.Write($"{num}) {storage.Name} (Type: ");
                FColorChange("green");
                Console.Write($"{storage.GetType().Name}");
                FColorChange("white");
                Console.WriteLine(")");
            }
            Console.WriteLine("\n0) Back");
            Dash();
            bool finish = false;
            while (!finish)
            {
                Console.Write("Enter choise: ");
                int choice = Console.ReadKey().KeyChar;
                choice = choice - 48;
                if (choice == 0)
                    finish = true;
                else
                    if (!(choice < 0 || choice > num))
                {
                    DisplayProductsInStorage(warehouses[choice - 1]);
                    finish = true;
                    num = 0;
                }
            }
        }

        private static void DisplayProductsInStorage(StorageStructure storage)
        {
            if(storage.Items==null || storage.Items.Count == 0)
            {
                FColorChange("red");
                Console.WriteLine($"\n\nNo products in {storage.Name}!");
                FColorChange("white");
                Console.ReadKey();
                return;
            }
            double totalWeight = 0, totalVolume = 0;
            PrintHeader($"Display products in {storage.Name}");
            PrintProductDetailsHeader();
            foreach (List<IPortable> lst in storage.Items)
                foreach (IPortable item in lst)
                {
                    PrintProductDetails(item);
                    totalWeight += item.GetWeight();
                    totalVolume += item.GetVolume();
                }
            Console.Write($"\nTotal Prodcts weight: ");
            FColorChange("green");
            Console.WriteLine($"{totalWeight} Kg");
            FColorChange("white");
            Console.Write($"Total Prodcts volume: ");
            FColorChange("green");
            Console.WriteLine($"{ totalVolume} Cube");
            FColorChange("white");

            Console.ReadKey();
        }

        private static void PrintProductDetails(IPortable item)
        {
            string fragile = item.IsFragile() ? "Yes" : "No";
            string packaged = item.IsPackaged() ? "Yes" : "No";
            Console.WriteLine($"{item.Name,-20}{item.Type,-20}{item.Sku,-10}{item.Width+" cm",-10}{item.Length + " cm",-10}{item.Height + " cm",-10}{item.GetWeight()+" kg",-10}{fragile,-10}{packaged,-10}");
           
        }

        private static void PrintProductDetailsHeader()
        {
            FColorChange("blue");
            Console.WriteLine($"{" Name ",-20}{" Type ",-20}{" SKU ",-10}{" Width ",-10}{" Length ",-10}{" Height ",-10}{" Weight ",-10}{" Fragile ",-10}{" Packaged ",-10}");
            FColorChange("red");
            Console.WriteLine($"{"------",-20}{"------",-20}{"-----",-10}{"-------",-10}{"--------",-10}{"--------",-10}{"--------",-10}{"---------",-10}{"----------",-10}");
            FColorChange("white");
            
        }



        /////////////////////////////////////////////////////
        //               Manage driver section             //
        /////////////////////////////////////////////////////

        private static void ManageDrivers()
        {
            bool finish = false;
            while (!finish)
            {
               PrintHeader("Manage Drivers");
                Console.WriteLine("1. Add New Driver");
                Console.WriteLine("2. Display Drivers");
                Console.WriteLine("\n0. Exit");
                Dash();
                FColorChange("yellow");
                Console.Write("Please enter choice: ");
                FColorChange("white");
                char ch = Console.ReadKey().KeyChar;
                Console.WriteLine();
                int choice = ch - 48;
                switch (choice)
                {
                    case 1:
                        AddNewDriver();
                        break;
                    case 2:
                        DisplayDrivers();
                        break;
                    case 0:
                        finish = true;
                        break;
                }

            }
        }
        private static void AddNewDriver()
        {
            PrintHeader("Add Driver");
            Console.Write("Enter first name: ");
            string fname = Console.ReadLine();
            Console.Write("Enter last name:  ");
            string lname = Console.ReadLine();
            Console.Write("Enter driver ID:  ");
            string id = Console.ReadLine();

            char ch = '4';
            while (ch - 48 < 1 || ch - 48 > 3)
            {
                Console.Write("License Type (");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("1. Airplane, 2. Train, 3. Ship");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("): ");

                ch = Console.ReadKey().KeyChar;
                Console.WriteLine("\n");
            }
            Driver.License license = ch == '1' ? Driver.License.Airplane : ch == '2' ? Driver.License.Train : Driver.License.Ship;
            Driver driver = new Driver(fname, lname, id, license);
            drivers.Add(driver);
            FColorChange("green");
            Console.WriteLine($"\n\nDriver ({fname} {lname}) was added successfully...");
            FColorChange("white");
            Console.ReadKey();

        }

        private static void DisplayDrivers()
        {
            PrintHeader("Display Drivers");
            if (drivers.Count == 0)
            {
                FColorChange("red");
                Console.WriteLine("\nNo drivers found");
                FColorChange("white");
                Console.ReadKey();
                return;
            }
            FColorChange("blue");
            Console.WriteLine($"{"First Name",-20}{"Last Name",-20}{"    ID    ",-20}{"License Type",-20}");
            FColorChange("red");
            Console.WriteLine($"{"----------",-20}{"---------",-20}{"----------",-20}{"------------",-20}");
            FColorChange("white");
            foreach (Driver driver in drivers)
            {
                Console.WriteLine($"{driver.Fname,-20}{driver.Lname,-20}{driver.Id,-20}{driver.LicenseSort,-20}");
            }
            Console.ReadKey();

        }

        /////////////////////////////////////////////////////
        //               Manage vehicle section            //
        /////////////////////////////////////////////////////

        private static void ManageVehicles()
        {
            bool finish = false;
            while (!finish)
            {
                PrintHeader("Manage Vehicles");
                Console.WriteLine($"1. Add vehicle ({vehicles.Count} Exist)");
                Console.WriteLine($"2. Display vehicles Info ({vehicles.Count} Exist)");
                Console.WriteLine($"3. List of items on vehicle");
                Console.WriteLine($"4. Assign driver to vehicle");
                Console.WriteLine("\n0. Exit menu");
                Dash();
                Console.Write("Enter choice: ");
                char ch = Console.ReadKey().KeyChar;
                Console.WriteLine();
                int choice = ch - 48;
                switch (choice)
                {
                    case 1:
                        AddVehicle();
                        break;
                    case 2:
                        DisplayVehicles();
                        break;
                    case 3:
                        ListItems();
                        break;
                    case 4:
                        AssignDriver();
                        break;
                    case 0:
                        finish = true;
                        break;
                }
            }

        }
        private static void ListItems()
        {
            PrintHeader("List of Items in vehicles");
            Console.WriteLine("List of available vehicles");
            Console.WriteLine("--------------------------");
            if (vehicles.Count == 0)
            {
                FColorChange("red");
                Console.WriteLine("\nNo vehicles found");
                FColorChange("white");
                Console.ReadKey();
                return;
            }
            int num = 0, airplane = 0, train = 0, ship = 0;
            foreach (CargoVehicle vehicle in vehicles)
            {
                num++;
                if (vehicle.Type == CargoVehicle.Vehicle.Airplane)
                {
                    airplane++;
                    Console.WriteLine($"{num}) {vehicle.Type} ({airplane})");
                }
                if (vehicle.Type == CargoVehicle.Vehicle.Train)
                {
                    train++;
                    Console.WriteLine($"{num}) {vehicle.Type} ({train})");
                }
                if (vehicle.Type == CargoVehicle.Vehicle.Ship)
                {
                    ship++;
                    Console.WriteLine($"{num}) {vehicle.Type} ({ship})");
                }
            }
            Console.WriteLine();
            bool finish = false;
            int choice = 0;
            while (!finish)
            {
                FColorChange("yellow");
                Console.Write("Please enter vehicle number: ");
                FColorChange("white");
                string input = Console.ReadLine();
                if (int.TryParse(input, out choice))
                {
                    if (!(choice < 1 || choice > num))
                        finish = true;
                }
            }
            Console.WriteLine();
            PrintItemsInVehicle(vehicles[choice - 1]);
        }

        private static void PrintItemsInVehicle(CargoVehicle vehicle)
        {
            if (vehicle is MultiUnitVehicle multiUnitVehicle)
            {
                if (multiUnitVehicle.NumOfUnits == 0)
                {
                    FColorChange("red");
                    Console.WriteLine($"\nNo items found in {vehicle.Type}");
                    FColorChange("white");
                    Console.ReadKey();
                    return;
                }
                foreach (GeneralContainer unit in multiUnitVehicle.Units)
                {
                    foreach (IPortable item in unit.Items)
                    {
                        Console.WriteLine($"Item: {item.Name}");
                    }
                }
            }
            else
            {
                if (vehicle.Items == null || vehicle.Items.Count == 0)
                {
                    FColorChange("red");
                    Console.WriteLine($"\nNo items found in {vehicle.Type}");
                    FColorChange("white");
                    Console.ReadKey();
                    return;
                }
                foreach (IPortable item in vehicle.Items)
                {
                    Console.WriteLine($"Item: {item.Name}");
                }
            }
            Console.ReadKey();
        }

        private static void AddVehicle()
        {
            PrintHeader("Add Vehicles");
            char ch = '0';
            while (!(ch - 48 > 0 && ch - 48 < 4))
            {
                Console.Write("Veicle Type (");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("1. Airplane, 2. Train, 3. Ship");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("): ");

                ch = Console.ReadKey().KeyChar;
                Console.WriteLine("\n\n");
            }

            double width = 0, length = 0, height = 0, maxWeight = 0;
            int maxUnits = 0;
            if (ch - 48 == 1)
            {
                bool isValidInput = false;

                while (!isValidInput)
                {
                    Console.Write("Width of vehicle (meters): ");
                    string input = Console.ReadLine();
                    if (double.TryParse(input, out width))
                    {
                        isValidInput = true;
                    }
                }

                isValidInput = false;
                while (!isValidInput)
                {
                    Console.Write("Length of vehicle (meters): ");
                    string input = Console.ReadLine();
                    if (double.TryParse(input, out length))
                    {
                        isValidInput = true;
                    }
                }
                isValidInput = false;
                while (!isValidInput)
                {
                    Console.Write("Height of vehicle (meters): ");
                    string input = Console.ReadLine();
                    if (double.TryParse(input, out height))
                    {
                        isValidInput = true;
                    }
                }
                isValidInput = false;
                while (!isValidInput)
                {
                    Console.Write("Max vehicle cargo weight (Kg): ");
                    string input = Console.ReadLine();
                    if (double.TryParse(input, out maxWeight))
                    {
                        isValidInput = true;
                    }
                }
            }
            else
            {
                bool isValidInput = false;
                while (!isValidInput)
                {
                    Console.Write("Max number of Containers/Crones: ");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out maxUnits))
                    {
                        isValidInput = true;
                    }
                }

            }
            CargoVehicle cargoVehicle;
            switch (ch - 48)
            {
                case 1:
                    cargoVehicle = new Airplane(CargoVehicle.Vehicle.Airplane, width, height, length, maxWeight, null);
                    break;
                case 2:
                    cargoVehicle = new Train(CargoVehicle.Vehicle.Train, maxUnits);
                    break;
                default:
                    cargoVehicle = new Ship(CargoVehicle.Vehicle.Ship, maxUnits);
                    break;
            }

            vehicles.Add(cargoVehicle);
            FColorChange("green");
            Console.WriteLine($"\n\n{cargoVehicle.Type} was added successfully...");
            FColorChange("white");
            Console.ReadKey();
        }

        private static void DisplayVehicles()
        {
            PrintHeader("Display Vehicles");
            if (vehicles.Count == 0)
            {
                FColorChange("red");
                Console.WriteLine("\n\nNo veicles in system yet!!!");
                FColorChange("white");
                Console.ReadKey();
                return;
            }

            int airplane = 0, train = 0, ship = 0;

            foreach (CargoVehicle vehicle in vehicles)
            {
                if (vehicle is MultiUnitVehicle multiUnitVehicle)
                {
                    if (multiUnitVehicle.Type == CargoVehicle.Vehicle.Train)
                    {
                        train++;
                        Console.Write("Train (");
                        FColorChange("red");
                        Console.Write($"{train}");
                        FColorChange("white");
                        Console.Write(")\tMax Num Of Crones: ");
                        FColorChange("red");
                        Console.Write($"{multiUnitVehicle.MaxNumOfUnits}");
                        FColorChange("white");
                        Console.Write("\tNum Of Crones used: ");
                        FColorChange("red");
                        Console.WriteLine($"{multiUnitVehicle.NumOfUnits}");
                        FColorChange("white");
                    }
                    else
                    {
                        ship++;
                        Console.Write("Ship (");
                        FColorChange("red");
                        Console.Write($"{ship}");
                        FColorChange("white");
                        Console.Write(")\tMax Num Of Containers: ");
                        FColorChange("red");
                        Console.Write($"{multiUnitVehicle.MaxNumOfUnits}");
                        FColorChange("white");
                        Console.Write("\tNum Of Containers used: ");
                        FColorChange("red");
                        Console.WriteLine($"{multiUnitVehicle.NumOfUnits}");
                        FColorChange("white");
                    }
                }
                else
                {
                    airplane++;
                    Console.Write("Airplane (");
                    FColorChange("red");
                    Console.Write(airplane);
                    FColorChange("white");
                    Console.Write(")\tWidth: ");
                    FColorChange("red");
                    Console.Write(vehicle.Width);
                    FColorChange("white");
                    Console.Write("(m) \tLength: ");
                    FColorChange("red");
                    Console.Write(vehicle.Length);
                    FColorChange("white");
                    Console.Write("(m)\tHeight: ");
                    FColorChange("red");
                    Console.Write(vehicle.Height);
                    FColorChange("white");
                    Console.Write("(m)\tMax Cargo Weight: ");
                    FColorChange("red");
                    Console.Write(vehicle.MaxWeight);
                    FColorChange("white");
                    Console.WriteLine("(kg)");
                }
            }
            Console.ReadKey();
        }

        private static void AssignDriver()
        {
            if (vehicles.Count == 0)
            {
                FColorChange("red");
                Console.WriteLine("\nNo vehicles found");
                FColorChange("white");
                Console.ReadKey();
                return;
            }
            
            if (drivers.Count == 0)
            {
                FColorChange("red");
                Console.WriteLine("\nNo drivers found in system!\nPlease add drivers first from main menu");
                FColorChange("white");
                Console.ReadKey();
                return;
            }

            PrintHeader("Assign Driver");
            Console.WriteLine("List of available vehicles");
            Console.WriteLine("--------------------------");

            int vehicleNum = 0, num=0, airplane = 0, train = 0, ship = 0;
            foreach (CargoVehicle vehicle in vehicles)
            {
                num++;
                string driverName;
                if (vehicle.Driver == null)
                    driverName = "Not Assigned";
                else
                    driverName = vehicle.Driver.Fname + " " + vehicle.Driver.Lname;
                if (vehicle.Type == CargoVehicle.Vehicle.Airplane)
                {
                    airplane++;
                    Console.WriteLine($"{num}) {vehicle.Type} ({airplane}) - Driver ({driverName})");
                }
                if (vehicle.Type == CargoVehicle.Vehicle.Train)
                {
                    train++;
                    Console.WriteLine($"{num}) {vehicle.Type} ({train}) - Driver ({driverName})");
                }
                if (vehicle.Type == CargoVehicle.Vehicle.Ship)
                {
                    ship++;
                    Console.WriteLine($"{num}) {vehicle.Type} ({ship}) - Driver ({driverName})");
                }
            }
            Console.WriteLine();
            bool finish = false;
            int choice;
            while (!finish)
            {
                FColorChange("yellow");
                Console.Write("Please enter vehicle number (0 to exit): ");
                FColorChange("white");
                string input = Console.ReadLine();
                if (int.TryParse(input, out choice))
                {
                    if (choice == 0) return;
                    if (!(choice < 1 || choice > num))
                    {
                        vehicleNum = choice-1;
                        finish = true;
                    }
                }
            }

            PrintHeader("Assign Driver");
            Console.WriteLine("List of available drivers");
            Console.WriteLine("--------------------------");
            Console.WriteLine();

            int driverNum=0;
            num = 0;

            foreach (Driver driver in drivers)
            {
                num++;
                Console.Write($"{num}) {driver.Fname} {driver.Lname} - (");
                FColorChange("Green");
                Console.Write($"{driver.LicenseSort} driver");
                FColorChange("white");
                Console.WriteLine(")");

            }
            Console.WriteLine();
            finish = false;
            while (!finish)
            {
                FColorChange("yellow");
                Console.Write("Please enter driver number (0 to exit): ");
                FColorChange("white");
                string input = Console.ReadLine();
                if (int.TryParse(input, out choice))
                {
                    if (choice == 0) return;
                    if (!(choice < 1 || choice > num))
                    {
                        driverNum = choice - 1;
                        finish = true;
                    }
                }
            }
            Console.WriteLine();

            if (drivers[driverNum].LicenseSort.ToString() != vehicles[vehicleNum].Type.ToString())
            {
                FColorChange("red");
                Console.WriteLine($"\nCan't assign {drivers[driverNum].LicenseSort} driver to {vehicles[vehicleNum].Type} vehicle!!");
                FColorChange("white");
                Console.ReadKey();
                return;
            }
            else
            {
                vehicles[vehicleNum].Driver = drivers[driverNum];
                FColorChange("green");
                Console.WriteLine($"\nDriver {drivers[driverNum].Fname} {drivers[driverNum].Lname} was assign to {vehicles[vehicleNum].Type} successfully!!");
                FColorChange("white");
            }
            Console.ReadKey();

        }


        private static void PrintHeader(string header)
        {
            Console.Clear();
            string dash = new string('-', 50);
            Console.WriteLine(dash); ;
            string constant = "Transportation - Cargo App";
            int space = (50 - constant.Length) / 2;
            Console.WriteLine($"{constant.PadLeft(space + constant.Length)}");
            FColorChange("blue");
            space = (50 - header.Length) / 2;
            Console.WriteLine($"{header.PadLeft(space + header.Length)}");
            FColorChange("white");
            Console.WriteLine(dash);
        }

        private static void Dash()
        {
            string dash = new string('-', 50);
            Console.WriteLine(dash);
            Console.WriteLine();
        }
        private static void FColorChange(string color)
        {
            switch (color)
            {
                case "red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "white":
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case "blue":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case "yellow":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
            }
        }
        private static void ImportInitialInfo(List<StorageStructure> storages, List<CargoVehicle> vehicles, List<Driver> drivers)
        {
            Port port = new Port("Port A", "Israel", 10, 10, 10, 10000, null);
            Warehouse warehouse = new Warehouse("Warehouse A", "Greece", 10, 10, 10, 10000, null);
            port.Items = Data.GetInitialData(port);
            storages.Add(port);
            storages.Add(warehouse);
            Driver driver1 = new Driver("Ross", "Geller", "123", Driver.License.Train);
            Driver driver2 = new Driver("Chandler", "Bing", "456", Driver.License.Airplane);
            drivers.Add(driver1);
            drivers.Add(driver2);
            Train train = new Train(Vehicle.Train, 25);
            train.Driver = driver1;
            Airplane airplane = new Airplane(Vehicle.Airplane, 5, 5, 100, 10000, null);
            airplane.Driver = driver2;
            vehicles.Add(train);
            vehicles.Add(airplane);
        }
    }

    
}
