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
            Console.ForegroundColor = ConsoleColor.White;
            string dash = new string('-', 50);
            bool finish = false;
            while (!finish)
            {
                Console.Clear();
                Console.WriteLine(dash);
                Console.WriteLine("          Transportation - Cargo App");
                FColorChange("blue");
                Console.WriteLine("                   Main Menu");
                FColorChange("white");
                Console.WriteLine(dash);
                Console.WriteLine($"1. Manage vehicles ({vehicles.Count} Exist)");
                Console.WriteLine($"2. Manage warehouses ({warehouses.Count} Exist)");
                Console.WriteLine($"3. Manage products ({products.Count} Exist)");
                Console.WriteLine($"4. Manage drivers ({drivers.Count} Exist)\n");
                Console.WriteLine("0. Exit app");
                Console.WriteLine(dash);
                Console.Write("Enter choice: ");
                char ch = Console.ReadKey().KeyChar;
                Console.WriteLine();
                int choice = ch - 48;
                switch (choice)
                {
                    case 1:
                        ManageVehicles();
                        break;
                    case 2:
                        ManageWarehouses();
                        break;
                    case 3:
                        ManageProducts();
                        break;
                    case 4:
                        ManageDrivers();
                        break;
                    case 5:
                        break;
                    case 0:
                        finish = true;
                        break;

                }
            }

        }
        

        

        private static void ManageProducts()
        {

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
            string dash = new string('-', 50);
            bool finish = false;
            while (!finish)
            {
                Console.Clear();
                Console.WriteLine(dash);
                Console.WriteLine("          Transportation - Cargo App");
                FColorChange("blue");
                Console.WriteLine("                Manage Storages");
                FColorChange("white");
                Console.WriteLine(dash);
                Console.WriteLine($"\n1. Add new port storage ({numPort} Exist)");
                Console.WriteLine($"2. Add new warehouse storage ({numWarehouse} Exist)");
                Console.WriteLine($"3. Display storages details ");
                Console.WriteLine($"4. Add products to storage");
                Console.WriteLine("\n0. Exit\n");
                Console.WriteLine(dash);
                Console.Write("Enter choice: ");
                char ch = Console.ReadKey().KeyChar;
                Console.WriteLine();
                int choice = ch - 48;
                switch (choice)
                {
                    case 1:
                        AddPort();
                        numPort++;
                        break;
                    case 2:
                        AddWareHouse();
                        numWarehouse++;
                        break;
                    case 3:
                        DisplayStorageDetails();
                        break;
                    case 4:
                        AddProductsToStorage();
                        break;
                    //case 5:
                    //    break;
                    case 0:
                        finish = true;
                        break;

                }
            }
        }

        private static void AddPort()
        {
            string dash = new string('-', 50);
            Console.Clear();
            Console.WriteLine(dash);
            Console.WriteLine("          Transportation - Cargo App");
            FColorChange("blue");
            Console.WriteLine("                    Add Port");
            FColorChange("white");
            Console.WriteLine(dash+"\n");
            Console.Write("Enter port name (max 20 chars): ");
            string portName = Console.ReadLine();
            if (portName.Length > 20)
                portName = portName.Substring(0, 20);
            Console.Write("Enter port country (max 20 chars): ");
            string portCountry = Console.ReadLine();
            if (portCountry.Length > 20)
                portCountry = portCountry.Substring(0, 20);


            bool isValidInput = false;
            double width=0;
            while (!isValidInput)
            {
                Console.Write("\nEnter Width of port (meters): ");
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
                Console.Write("Enter Length of port (meters): ");
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
                Console.Write("Enter Height of port (meters): ");
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
                Console.Write("Enter Max Weight Capacity of port (Kg): ");
                string input = Console.ReadLine();
                if (double.TryParse(input, out maxWeightCapacity))
                {
                    isValidInput = true;
                }
            }

            Port port = new Port(portName, portCountry, width, height, length, maxWeightCapacity, null);
            warehouses.Add(port);
            FColorChange("green");
            Console.WriteLine($"\n\nPort ({portName} in {portCountry}) was added successfully...");
            FColorChange("white");
            Console.ReadKey();

        }

        private static void AddWareHouse()
        {
            string dash = new string('-', 50);
            Console.Clear();
            Console.WriteLine(dash);
            Console.WriteLine("          Transportation - Cargo App");
            FColorChange("blue");
            Console.WriteLine("                 Add Warehouse");
            FColorChange("white");
            Console.WriteLine(dash + "\n");
            Console.Write("Enter warehouse name (max 20 chars): ");
            string warehouseName = Console.ReadLine();
            if (warehouseName.Length > 20)
                warehouseName = warehouseName.Substring(0, 20);
            Console.Write("Enter warehouse country (max 20 chars): ");
            string warehouseCountry = Console.ReadLine();
            if (warehouseCountry.Length > 20)
                warehouseCountry = warehouseCountry.Substring(0, 20);

            bool isValidInput = false;
            double width = 0;
            while (!isValidInput)
            {
                Console.Write("\nEnter Width of warehouse (meters): ");
                string input = Console.ReadLine();
                if (double.TryParse(input, out width))
                {
                    isValidInput = true;
                }
            }
            isValidInput = false;
            double length = 0;
            while (!isValidInput)
            {
                Console.Write("Enter Length of warehouse (meters): ");
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
                Console.Write("Enter Height of warehouse (meters): ");
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
                Console.Write("Enter Max Weight Capacity of warehouse (Kg): ");
                string input = Console.ReadLine();
                if (double.TryParse(input, out maxWeightCapacity))
                {
                    isValidInput = true;
                }
            }

            Warehouse warehouse = new Warehouse(warehouseName, warehouseCountry, width, height, length, maxWeightCapacity, null);
            warehouses.Add(warehouse);
            FColorChange("green");
            Console.WriteLine($"\n\nWarehouse ({warehouseName} in {warehouseCountry}) was added successfully...");
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
            string dash = new string('-', 50);
            Console.Clear();
            Console.WriteLine(dash);
            Console.WriteLine("          Transportation - Cargo App");
            FColorChange("blue");
            Console.WriteLine("                Display Storages");
            FColorChange("white");
            Console.WriteLine(dash + "\n");
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
            string dash = new string('-', 50);
            Console.Clear();
            Console.WriteLine(dash);
            Console.WriteLine("          Transportation - Cargo App");
            FColorChange("blue");
            Console.WriteLine("            Add Products To Storage");
            FColorChange("white");
            Console.WriteLine(dash + "\n");
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
            Console.WriteLine($"\n{dash}\n");
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
            string dash = new string('-', 50);
            Console.Clear();
            Console.WriteLine(dash);
            Console.WriteLine("          Transportation - Cargo App");
            FColorChange("blue");
            string str = $"Add Products To { storage.Name}";
            int space = (50 - str.Length) / 2;
            Console.WriteLine($"{str.PadLeft(space + str.Length)}");
            FColorChange("white");
            Console.WriteLine(dash + "\n");
            Console.WriteLine("1) Add Products Manually");
            Console.WriteLine("2) Add Products From Database");
            Console.WriteLine("\n0) Exit");
            Console.WriteLine(dash);

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
                            break;
                        case 2:
                            List<List<IPortable>> items = Data.GetInitialData(storage);
                            storage.Items = items;
                            FColorChange("green");
                            Console.WriteLine($"\n\nInitial items were loaded to {storage.Name} successfully...");
                            FColorChange("white");
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

        /////////////////////////////////////////////////////
        //               Manage driver section             //
        /////////////////////////////////////////////////////

        private static void ManageDrivers()
        {
            string dash = new string('-', 50);
            bool finish = false;
            while (!finish)
            {
                Console.Clear();
                Console.WriteLine(dash);
                Console.WriteLine("          Transportation - Cargo App");
                FColorChange("blue");
                Console.WriteLine("                Manage Drivers");
                FColorChange("white");
                Console.WriteLine(dash + "\n");
                Console.WriteLine("1. Add New Driver");
                Console.WriteLine("2. Display Drivers\n");
                Console.WriteLine("0. Exit");
                Console.WriteLine(dash);
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
            string dash = new string('-', 50);
            Console.Clear();
            Console.WriteLine(dash);
            Console.WriteLine("          Transportation - Cargo App");
            FColorChange("blue");
            Console.WriteLine("                  Add Driver");
            FColorChange("white");
            Console.WriteLine(dash + "\n");
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
            string dash = new string('-', 50);
            Console.Clear();
            Console.WriteLine(dash);
            Console.WriteLine("          Transportation - Cargo App");
            FColorChange("blue");
            Console.WriteLine("                Display Drivers");
            FColorChange("white");
            Console.WriteLine(dash + "\n");
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
            string dash = new string('-', 50);
            bool finish = false;
            while (!finish)
            {
                Console.Clear();
                Console.WriteLine(dash);
                Console.WriteLine("          Transportation - Cargo App");
                FColorChange("blue");
                Console.WriteLine("               Manage Vehicles");
                FColorChange("white");
                Console.WriteLine(dash);
                Console.WriteLine($"1. Add vehicle ({vehicles.Count} Exist)");
                Console.WriteLine($"2. Display vehicles Info ({vehicles.Count} Exist)");
                Console.WriteLine($"3. List of items on vehicle");
                Console.WriteLine($"4. Assign driver to vehicle\n");
                Console.WriteLine("0. Exit menu");
                Console.WriteLine(dash);
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
            string dash = new string('-', 50);
            Console.Clear();
            Console.WriteLine(dash);
            Console.WriteLine("          Transportation - Cargo App");
            FColorChange("blue");
            Console.WriteLine("                 List of Items");
            FColorChange("white");
            Console.WriteLine(dash + "\n");
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
            string dash = new string('-', 50);
            Console.Clear();
            Console.WriteLine(dash);
            Console.WriteLine("          Transportation - Cargo App");
            FColorChange("blue");
            Console.WriteLine("                 Add Vehicles");
            FColorChange("white");
            Console.WriteLine(dash);
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
            string dash = new string('-', 50);
            Console.Clear();
            Console.WriteLine(dash);
            Console.WriteLine("          Transportation - Cargo App");
            FColorChange("blue");
            Console.WriteLine("               Display Vehicles");
            FColorChange("white");
            Console.WriteLine(dash + "\n");
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

            string dash = new string('-', 50);
            Console.Clear();
            Console.WriteLine(dash);
            Console.WriteLine("          Transportation - Cargo App");
            FColorChange("blue");
            Console.WriteLine("                 Assign Driver");
            FColorChange("white");
            Console.WriteLine(dash + "\n");
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

            Console.Clear();
            Console.WriteLine(dash);
            Console.WriteLine("          Transportation - Cargo App");
            FColorChange("blue");
            Console.WriteLine("                 Assign Driver");
            FColorChange("white");
            Console.WriteLine(dash + "\n");
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
    }
}
