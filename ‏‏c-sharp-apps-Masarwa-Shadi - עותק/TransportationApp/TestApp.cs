using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using c_sharp_apps_Masarwa_Shadi.TransportationApp.shared;

namespace c_sharp_apps_Masarwa_Shadi.TransportationApp
{
    public class TestApp
    {
        public static void RunTests()
        {
            Console.Clear();
            /////////////////////////////////////////////////
            //           StorageStructure tests            //
            /////////////////////////////////////////////////

            Console.Write("Test 1 - Add port (portA) - ");
            Port portA = new Port("Port A", "Israel", 100, 20, 100, 17800, null);
            if (portA != null)
                Console.WriteLine("Ok");
            else
                Console.WriteLine("Failed!\n Couldn't add prot");

            //Should be Ok because item suites for the size and max weight of port
            Console.Write("Test 2 - Add one product to (portA) - ");
            ElecticDeviceItem electricNewItem1 = new ElecticDeviceItem("TQ987ER", "Samsung", 120, 8, 50, 3.5, false, true, false, portA, "TV", 240);
            if (portA.Load(electricNewItem1))
                Console.WriteLine("Ok");
            else
                Console.WriteLine("Failed!\nCouldn't load product to (protA)");

            //Should be Ok because item exceeds max weight capacity of port
            Console.Write("Test 3 - Add very heavy product to (portA) - ");
            GeneralItem genralProduct1 = new GeneralItem("YY7895I", "Heavy Product", 200.0, 1.0, 180.0, 1470147, false, false, false, portA, "General");
            if (!portA.Load(genralProduct1))
                Console.WriteLine("Ok");
            else
                Console.WriteLine("Failed!\nproduct loaded but it's weight exceeds (protA) capacity");

            //Should be Ok because items suites for the size an max weight of port
            Console.Write("Test 4 - Add list of product to (portA) - ");
            List<IPortable> newList = new List<IPortable>
            {
                new ElecticDeviceItem("TQ987ER", "Samsung", 120, 8, 50, 3.5, false, true, false, portA, "TV", 240),
                new ElecticDeviceItem("TO7123I", "Xiaomi", 150, 6, 60, 2.8, false, true, false, portA, "TV", 240),
                new FurnitureItem("SKU005", "Bookshelf", 80, 20, 40, 30.0, false, true, false, portA, "Storage"),
                new GeneralItem("SKU114", "Cotton Bedsheet", 30.0, 3.0, 25, 1.2, false, false, false, portA, "Textile")
            };
            if (portA.Load(newList))
                Console.WriteLine("Ok");
            else
                Console.WriteLine("Failed!\n0 products loaded to (protA)");

            //Should be Ok because not all items suites for the size an max weight of port, it should load 3 of 4 items
            Console.Write("Test 5 - Add list of products to (portA) with one very heavy item - ");
            int numOfProductsBefore = portA.GetNumOfItemsInStorage();
            List<IPortable> newList2 = new List<IPortable>
            {
                new ElecticDeviceItem("TQ987ER", "Samsung", 120, 8, 50, 100000, false, true, false, portA, "TV", 240),
                new ElecticDeviceItem("TO7123I", "Xiaomi", 150, 6, 60, 2.8, false, true, false, portA, "TV", 240),
                new FurnitureItem("SKU005", "Bookshelf", 80, 20, 40, 30.0, false, true, false, portA, "Storage"),
                new GeneralItem("SKU114", "Cotton Bedsheet", 30.0, 3.0, 25, 1.2, false, false, false, portA, "Textile")
            };
            bool flage = portA.Load(newList2);
            int numOfProductsAfter = portA.GetNumOfItemsInStorage();
            if (!flage && numOfProductsAfter - numOfProductsBefore == 3)
                Console.WriteLine("Ok");
            else
                Console.WriteLine("Failed!\nall products loaded to (protA) although one heavy item exceeds weight capacity");

            //Should be Ok because item exist in port product list
            Console.Write("Test 6 - Remove one product from (portA) - ");
            //ElecticDeviceItem electricNewItem1 = new ElecticDeviceItem("TQ987ER", "Samsung", 120, 8, 50, 3.5, false, true, false, portA, "TV", 240);
            numOfProductsBefore = portA.GetNumOfItemsInStorage();
            portA.Unload(electricNewItem1);
            numOfProductsAfter = portA.GetNumOfItemsInStorage();
            if (numOfProductsBefore - numOfProductsAfter == 1)
                Console.WriteLine("Ok");
            else
                Console.WriteLine("Failed!\nCouldn't remove product to (protA)");

            //Should be Ok because item doesn't exist in port A
            Console.Write("Test 7 - Remove not existing product from (portA) - ");
            genralProduct1 = new GeneralItem("YY7895I", "Not Found Item", 200.0, 1.0, 180.0, 1470147, false, false, false, portA, "Not Found");
            numOfProductsBefore = portA.GetNumOfItemsInStorage();
            portA.Unload(genralProduct1);
            numOfProductsAfter = portA.GetNumOfItemsInStorage();
            if (numOfProductsBefore == numOfProductsAfter)
                Console.WriteLine("Ok");
            else
                Console.WriteLine("Failed!\nRemoved unexisting product product (protA)");

            //Should be Ok because items exist in port
            Console.Write("Test 8 - Remove list of products from (portA) - ");
            newList = new List<IPortable>
            {
                new ElecticDeviceItem("TO7123I", "Xiaomi", 150, 6, 60, 2.8, false, true, false, portA, "TV", 240),
                new GeneralItem("SKU114", "Cotton Bedsheet", 30.0, 3.0, 25, 1.2, false, false, false, portA, "Textile")
            };
            numOfProductsBefore = portA.GetNumOfItemsInStorage();
            portA.Unload(newList);
            numOfProductsAfter = portA.GetNumOfItemsInStorage();
            if (numOfProductsBefore - numOfProductsAfter == 2)
                Console.WriteLine("Ok");
            else
                Console.WriteLine("Failed!\nDidn't Remove all products in list from (protA)");

            //Should be Ok because 1 item exist and 1 items doesn't exist in port
            Console.Write("Test 9 - Remove 2 products from  (portA) while only 1 exist - ");
            newList = new List<IPortable>
            {
                new ElecticDeviceItem("TO7123I", "Xiaomi", 150, 6, 60, 2.8, false, true, false, portA, "TV", 240), //exist
                new GeneralItem("SKU114", "Big Cotton Bedsheet", 200.0, 1.0, 180.0, 1.2, false, false, false, portA, "Textile") //not exist
            };
            numOfProductsBefore = portA.GetNumOfItemsInStorage();
            portA.Unload(newList);
            numOfProductsAfter = portA.GetNumOfItemsInStorage();
            if (numOfProductsBefore - numOfProductsAfter == 1)
                Console.WriteLine("Ok");
            else
                Console.WriteLine("Failed!\nRemoved all products in list from (protA) while 1 not exist");

            /////////////////////////////////////////////////
            //             CargoVehicle tests              //
            /////////////////////////////////////////////////
            //                   Airplane                  //
            /////////////////////////////////////////////////

            Driver driver1 = new Driver("Ross", "Geller", "123456", Driver.License.Airplane);
            Driver driver2 = new Driver("Joey", "Tribbiani", "654321", Driver.License.Ship);
            Driver driver3 = new Driver("Chandler", "Bing", "654123", Driver.License.Train);
            Airplane airplane1 = new Airplane(CargoVehicle.Vehicle.Airplane, 10, 10, 20, 25000, null);
            Ship ship1 = new Ship(CargoVehicle.Vehicle.Ship, 3);
            Train train1 = new Train(CargoVehicle.Vehicle.Train, 2);

            //Should be Ok because driver1 has suitable license for airplain
            Console.Write("Test 10 - Assign driver1 to airplane1 - ");
            airplane1.Driver = driver1;
            if (airplane1.Driver != null)
                Console.WriteLine("OK");
            else
                Console.WriteLine("Failed!\nAssigned unsuitable driver to airplane");

            //Should be Ok because driver2 hasn't suitable license for train
            Console.Write("Test 11 - Assign driver2 to train1 - ");
            train1.Driver = driver2;
            if (train1.Driver == null)
                Console.WriteLine("OK");
            else
                Console.WriteLine("Failed!\nAssigned unsuitable driver to train");

            train1.Driver = driver3;
            ship1.Driver = driver2;

            //Should be Ok because item is not packaged
            Console.Write("Test 12 - Move unpackaged item from portA to airplane - ");
            IPortable newItem = new GeneralItem("SKU114", "Cotton Bedsheet", 30.0, 3.0, 25, 1.2, false, false, false, portA, "Textile");
            if (!portA.MoveItemToVehicle(airplane1, newItem))
                Console.WriteLine("Ok");
            else
                Console.WriteLine($"Failed!\n{portA.Message}");

            //Should be Ok because item is packaged and not loaded
            Console.Write("Test 13 - Move packaged item from portA to airplane - ");
            foreach (List<IPortable> lst in portA.Items)
                foreach (IPortable p in lst)
                    if (p.Equals(newItem))
                        p.PackageItem();
            newItem.PackageItem();

            if (portA.MoveItemToVehicle(airplane1, newItem))
                Console.WriteLine("Ok");
            else
                Console.WriteLine($"Failed!\n{portA.Message}");


            //Should be Ok because 2 items of 3 exist in port A
            Console.Write("Test 14 - Move list of items from portA to airplane - ");
            List<IPortable> productList = new List<IPortable>
            {
                new ElecticDeviceItem("TQ987ER", "Samsung", 120, 8, 50, 3.5, false, true, false, portA, "TV", 240),
                new ElecticDeviceItem("TO7123I", "Xiaomi", 150, 6, 60, 2.8, false, true, false, portA, "TV", 240),
                new FurnitureItem("SKU005", "Bookshelf", 80, 20, 40, 30.0, false, true, false, portA, "Storage"),
            };
            foreach (IPortable pro in productList)
                foreach (List<IPortable> lst in portA.Items)
                    foreach (IPortable p in lst)
                        if (p.Equals(pro))
                        {
                            p.PackageItem();
                            pro.PackageItem();
                        }
            if (!portA.MoveItemToVehicle(airplane1, productList))
                Console.WriteLine("Ok");
            else
                Console.WriteLine($"Failed!\n{portA.Message}");

            StorageStructure w1 = new Warehouse("Warehouse A", "Greece", 200, 20, 200, 80000, null);

            //Should be Ok Driver did not approve execution
            Console.Write("Test 15 - Exectute shipping from portA to w1 with airplane - ");
            if (!airplane1.ExecuteShippingTo(w1))
                Console.WriteLine("Ok");
            else
                Console.WriteLine($"Failed!\nreturn false while driver did approve shipment");

            airplane1.Driver.ApproveShipping = true;

            //Should be Ok Driver did approve execution and print invoice
            //ShippingPriceCalculator.PrintInvoice(airplane1, 2812);
            int fees = ShippingPriceCalculator.CalculateSingleUnitCargoFees(airplane1, 2812);
            Console.Write("Test 16 - Check shipping fees from portA to w1 with airplane - ");
            if (fees == 116535)
                Console.WriteLine("Ok");
            else
                Console.WriteLine($"Failed!\nHas to be 116535 but returned {fees}");

            //Check unloading cargo to w1 from airplain
            Console.Write("Test 17 - Check unload items from airplane to warehouse w1 - ");
            airplane1.ExecuteShippingTo(w1);
            if (w1.GetNumOfItemsInStorage() == 3 && airplane1.Items.Count() == 0)
                Console.WriteLine("Ok");
            else
                Console.WriteLine($"Failed!\n3 item must be in w1 and 0 in airplane");


            /////////////////////////////////////////////////
            //             CargoVehicle tests              //
            /////////////////////////////////////////////////
            //                    Train                    //
            /////////////////////////////////////////////////

            //Add more products to warehouse w1
            List<IPortable> newList3 = new List<IPortable>
            {
                new FurnitureItem("SKU013", "Kitchen Island", 120, 90, 70, 45.0, true, true, false, w1, "Kitchen"),
                new FurnitureItem("SKU014", "Bar Stool", 40, 100, 40, 7.0, true, true, false, w1, "Seating"),
                new FurnitureItem("SKU015", "Electric Fireplace", 100, 120, 40, 30.0, true, true, false, w1, "Entertainment"),

                new GeneralItem("SKU101", "Ceramic Vase", 15.0, 30.0, 15.0, 2.0, true, true, false, w1, "Home Decor"),
                new GeneralItem("SKU102", "Wool Blanket", 30.0, 2.0, 20.0, 1.5, true, false, false, w1, "Textile"),
                new GeneralItem("SKU103", "Porcelain Dinner Set", 50.0, 30.0, 50.0, 10.0, true, true, false, w1, "Kitchenware"),
                new GeneralItem("SKU104", "Stainless Steel Pot", 25.0, 20.0, 25.0, 3.0, true, false, false, w1, "Cookware"),
                new GeneralItem("SKU105", "Leather Wallet", 12.0, 2.0, 10.0, 0.2, true, false, false, w1, "Accessory"),
            };
            w1.Load(newList3);


            //Try to upload 1 very large item (exceeds capacity) from w1 to train1
            GeneralItem temp = new GeneralItem("SKU105", "Leather Wallet", 300.0, 200.0, 510.0, 0.2, true, false, false, w1, "Accessory");
            Console.Write("Test 18 - Try to upload 1 very large item (exceeds capacity) from w1 to train - ");
            if (!w1.MoveItemToVehicle(train1, temp))
                Console.WriteLine("Ok");
            else
                Console.WriteLine($"Failed!\nNo item loaded from w1 to train");

            //Try to upload 1 item from w1 to train1
            temp = new GeneralItem("SKU105", "Leather Wallet", 12.0, 2.0, 10.0, 0.2, true, false, false, w1, "Accessory");
            Console.Write("Test 19 - Try to upload 1 item from w1 to train - ");
            if (w1.MoveItemToVehicle(train1, temp))
                Console.WriteLine("Ok");
            else
                Console.WriteLine($"Failed!\nNo item loaded from w1 to train");

            List<IPortable> lst1 = new List<IPortable>
            {
                new GeneralItem("SKU101", "Ceramic Vase", 15.0, 30.0, 15.0, 2.0, true, true, false, w1, "Home Decor"),
                new GeneralItem("SKU102", "Wool Blanket", 30.0, 2.0, 20.0, 1.5, true, false, false, w1, "Textile"),
                new GeneralItem("SKU103", "Porcelain Dinner Set", 50.0, 30.0, 50.0, 10.0, true, true, false, w1, "Kitchenware"),
                new GeneralItem("SKU104", "Stainless Steel Pot", 25.0, 20.0, 25.0, 3.0, true, false, false, w1, "Cookware"),
            };

            //Try upload list of items from w1 to train
            Console.Write("Test 20 - Try to upload list of items from w1 to train - ");
            if (w1.MoveItemToVehicle(train1, lst1))
                Console.WriteLine("Ok");
            else
                Console.WriteLine($"Failed!\n4 item must be added to train");

            List<IPortable> lst2 = new List<IPortable>
            {
                new GeneralItem("SKU103", "Porcelain Dinner Set", 50.0, 30.0, 50.0, 10.0, true, true, false, w1, "Kitchenware"),
                new GeneralItem("SKU104", "Stainless Steel Pot", 25.0, 20.0, 25.0, 3.0, true, false, false, w1, "Cookware"),
            };

            //
            Console.Write("Test 21 - Try to upload list of items not existing in w1 to train - ");
            if (!w1.MoveItemToVehicle(train1, lst2))
                Console.WriteLine("Ok");
            else
                Console.WriteLine($"Failed!\n0 item must be added to train");

            //
            train1.Driver.ApproveShipping = true;
            Console.Write("Test 22 - Excute Shipment with train from w1 to portA - ");
            if (train1.ExecuteShippingTo(portA))
                Console.WriteLine("Ok");
            else
                Console.WriteLine($"Failed!\nUnloading items from train to portA failed");

            /////////////////////////////////////////////////
            //             CargoVehicle tests              //
            /////////////////////////////////////////////////
            //                    Ship                    //
            /////////////////////////////////////////////////

            portA.Items[1][0].SetWeight(999.9);
            portA.Items[2][0].SetWeight(999.9);
            portA.Items[3][0].SetWeight(990);

            //In portA:
            //Name: Bookshelf - FurnitureItem. Loaded - False. Packaged - False. Weight: 30
            //Name: Leather Wallet -GeneralItem.Loaded - False.Packaged - True.Weight: 999.9
            //Name: Ceramic Vase -GeneralItem.Loaded - False.Packaged - True.Weight: 999.9
            //Name: Wool Blanket -GeneralItem.Loaded - False.Packaged - True.Weight: 990
            //Name: Porcelain Dinner Set - GeneralItem.Loaded - False.Packaged - True.Weight: 10
            //Name: Stainless Steel Pot - GeneralItem.Loaded - False.Packaged - True.Weight: 3
            //
            //max containers: 3
            //max weight in each container: 1000kg
            // ship starts with no containers, and adds containers as needed
            //
            //1st item not packaged - not loded to ship1
            //2nd item takes container 1
            //3rd item has no room in container 1 so it takes container 2
            //4th item has no room int container 1 or 2 so it takes container 2
            //5th item can fit in container 3 (not in 1 or 2) so it is loaded to it.
            //6th item can't fit in any container, and because we used the max 3 containers, it is not loaded

            //So at end we have: 3 containers and 4 items loaded to it
            Console.Write("Test 23 - Try to upload all portA items to ship1 - ");

            int count = 0;
            foreach (List<IPortable> lst in portA.Items)
            {
                if (portA.MoveItemToVehicle(ship1, lst))
                    count++;
            }

            if (count == 4 && ship1.Units.Count == 3)
                Console.WriteLine("Ok");
            else
                Console.WriteLine($"Failed!\n0 item must be added to train");

            Console.ReadKey();
        }


        ////////////////////////////////////////////////////////////

        private static void PrintProductsInStorage(StorageStructure storage)
        {
            Console.WriteLine($"\n\nList of products in {storage.Name}");
            Console.WriteLine("------------------------------------");
            if (storage.Items == null || storage.Items.Count() == 0)
            {
                Console.WriteLine($"{storage.Name} is empty");
                return;
            }

            foreach (List<IPortable> items in storage.Items)
                foreach (IPortable item in items)
                    Console.WriteLine(item.ToString() + " - " + item.GetType().Name + ". Loaded - " + item.IsLoaded() + ". Packaged - " + item.IsPackaged() + ". Weight: " + item.GetWeight());
        }

        private static void PrintProductsInVehicle(CargoVehicle vehicle)
        {
            Console.WriteLine($"\n\nList of products in {vehicle.Type}");
            Console.WriteLine("------------------------------------");
            if (vehicle.Items == null || vehicle.Items.Count() == 0)
            {
                Console.WriteLine($"{vehicle.Type} is empty");
                return;
            }

            foreach (IPortable item in vehicle.Items)
                Console.WriteLine(item.ToString() + " - " + item.GetType().Name + ". Loaded - " + item.IsLoaded() + ". Packaged - " + item.IsPackaged() + ". Weight: " + item.GetWeight());

        }

        private static void PrintProductsInMultiCargo(MultiUnitVehicle vehicle)
        {
            Console.WriteLine($"\n\nList of products in {vehicle.Type}");
            Console.WriteLine("------------------------------------");
            if (vehicle.Units == null || vehicle.Units.Count() == 0)
                Console.WriteLine($"{vehicle.Type} is empty");
            else
            {
                foreach (GeneralContainer container in vehicle.Units)
                    foreach (IPortable item in container.Items)
                        Console.WriteLine(item.ToString() + " - " + item.GetType().Name + ". Loaded - " + item.IsLoaded() + ". Packaged - " + item.IsPackaged() + ". Weight: " + item.GetWeight());

                Console.WriteLine("Units: " + vehicle.Units.Count);

            }

        }
    }
}
