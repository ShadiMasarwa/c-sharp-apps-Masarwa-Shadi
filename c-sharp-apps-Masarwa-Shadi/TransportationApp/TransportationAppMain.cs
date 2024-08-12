using c_sharp_apps_Masarwa_Shadi.TransportationApp.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Masarwa_Shadi.TransportationApp
{
    public class TransportationAppMain
    {
        public static void MainEntry()
        {
            List<List<IPortable>> portItems = null;
            Port portA = new Port("Port A", "Israel", 10, 2, 10, 17800, portItems);
            List<List<IPortable>> products = GetProducts(portA);
            portA.Items = products;

            Console.Clear();
            if (portA.Items.Count == 0)
                Console.WriteLine($"{portA.Name} is empty");
            

            Console.WriteLine("\nAdd one product"); 
            ElecticDeviceItem electricNewItem = new ElecticDeviceItem("TQ987ER", "Samsung", 120, 8, 50, 3.5, false, true, false, portA, "TV", 240);
            portA.Load(electricNewItem);
            PrintProductsInStorage(portA);

            Console.WriteLine("\nAdd list of products"); 
            List<IPortable> newList = new List<IPortable>
            {
                new ElecticDeviceItem("TQ987ER", "Samsung", 120, 8, 50, 3.5, false, true, false, portA, "TV", 240),
                new ElecticDeviceItem("TO7123I", "Xiaomi", 150, 6, 60, 2.8, false, true, false, portA, "TV", 240),
                new FurnitureItem("SKU005", "Bookshelf", 80, 200, 40, 30.0, false, false, false, portA, "Storage"),
                new GeneralItem("SKU114", "Cotton Bedsheet", 200.0, 1.0, 180.0, 1.2, true, false, false, portA, "Textile")
            };
            portA.Load(newList);
            PrintProductsInStorage(portA);

            Console.WriteLine("\n Remove one product");
            portA.Unload(electricNewItem);
            PrintProductsInStorage(portA);

            Console.WriteLine("\nRemove list of products");
            List<IPortable> newList2 = new List<IPortable>
            {
                new ElecticDeviceItem("TO7123I", "Xiaomi", 150, 6, 60, 2.8, false, true, false, portA, "TV", 240),
                new ElecticDeviceItem("TO7123I", "Xiaomi", 150, 6, 60, 2.8, false, true, false, portA, "TV", 240),
                new FurnitureItem("SKU005", "Bookshelf", 80, 200, 40, 30.0, false, false, false, portA, "Storage"),
                new GeneralItem("SKU114", "Cotton Bedsheet", 200.0, 1.0, 180.0, 1.2, true, false, false, portA, "Textile")
            };
            portA.Unload(newList2);
            PrintProductsInStorage(portA);

            


        }

        private static void PrintProductsInStorage(StorageStructure storage)
        {
            Console.WriteLine($"\nList of products in {storage.Name}");
            foreach (List<IPortable> items in storage.Items)
                foreach (IPortable item in items)
                    Console.WriteLine(item.ToString() + " - " + item.GetType().Name);
            Console.ReadLine();
        }

            //Warehouse w1 = new Warehouse("Warehouse A", "Israel", 80 * 100, 10 * 100, 100 * 100, 178000, portItems);



        private static List<IPortable> MultiplyProduct(IPortable product, int qnt)
            {
                List<IPortable> lst = new List<IPortable>();
                for (int i = 0; i < qnt; i++)
                {
                    lst.Add(product);
                }
                return lst;
            }

            private static List<List<IPortable>> GetProducts(StorageStructure location)
            {
                List<List<IPortable>> products = new List<List<IPortable>>();

                //IPortable product = new ElecticDeviceItem("TQ987ER", "Samsung", 120, 8, 50, 3.5, false, true, false, location, "TV", 240);
                //products.Add(MultiplyProduct(product, 1));
                //product = new ElecticDeviceItem("TO7123I", "Xiaomi", 150, 6, 60, 2.8, false, true, false, location, "TV", 240);
                //products.Add(MultiplyProduct(product, 1));
                //product = new ElecticDeviceItem("WY0187O", "Samsung", 60, 1.3, 60, 56, false, true, false, location, "Washing Machine", 240);
                //products.Add(MultiplyProduct(product, 1));
                //product = new ElecticDeviceItem("CF5974P", "Hp", 35, 3, 25, 1, false, true, false, location, "Computer", 240);
                //products.Add(MultiplyProduct(product, 1));
                //product = new ElecticDeviceItem("CI4921M", "Asus", 32, 3, 23, 1.1, false, true, false, location, "Computer", 240);
                //products.Add(MultiplyProduct(product, 1));
                //product = new ElecticDeviceItem("XY453PL", "LG", 45, 30, 30, 2.3, true, false, true, location, "Microwave", 700);
                //products.Add(MultiplyProduct(product, 1));
                //product = new ElecticDeviceItem("KL234RT", "Sony", 85, 10, 55, 4.8, false, true, false, location, "Sound System", 120);
                //products.Add(MultiplyProduct(product, 1));
                //product = new ElecticDeviceItem("MN786YU", "Dyson", 25, 40, 25, 1.8, true, false, true, location, "Vacuum Cleaner", 600);
                //products.Add(MultiplyProduct(product, 1));
                //product = new ElecticDeviceItem("PQ098OI", "Philips", 20, 15, 25, 1.2, true, false, true, location, "Coffee Maker", 50);
                //products.Add(MultiplyProduct(product, 1));
                //product = new ElecticDeviceItem("RT123GH", "Panasonic", 60, 20, 40, 3.2, true, true, false, location, "Air Purifier", 45);
                //products.Add(MultiplyProduct(product, 1));
                //product = new ElecticDeviceItem("UW345JK", "Apple", 30, 30, 20, 1.5, true, true, false, location, "iPad", 18);
                //products.Add(MultiplyProduct(product, 1));
                //product = new ElecticDeviceItem("VC987LP", "Canon", 35, 25, 15, 2.1, true, true, true, location, "Camera", 15);
                //products.Add(MultiplyProduct(product, 1));
                //product = new ElecticDeviceItem("BN654QW", "Whirlpool", 120, 90, 65, 60.5, false, false, false, location, "Refrigerator", 150);
                //products.Add(MultiplyProduct(product, 1));
                //product = new ElecticDeviceItem("DF345ZX", "Samsung", 80, 10, 45, 5.0, false, true, false, location, "Monitor", 65);
                //products.Add(MultiplyProduct(product, 1));
                //product = new ElecticDeviceItem("GH456CV", "Bose", 20, 15, 20, 0.9, true, true, false, location, "Bluetooth Speaker", 20);
                //products.Add(MultiplyProduct(product, 1));

                //product = new FurnitureItem("SKU001", "Modern Sofa", 200, 80, 90, 45.0, true, false, false, location, "Seating");
                //products.Add(MultiplyProduct(product, 1));
                //product = new FurnitureItem("SKU002", "Wooden Dining Table", 150, 75, 150, 35.0, true, false, false, location, "Table");
                //products.Add(MultiplyProduct(product, 1));
                //product = new FurnitureItem("SKU003", "Glass Coffee Table", 120, 40, 60, 20.0, true, true, false, location, "Table");
                //products.Add(MultiplyProduct(product, 1));
                //product = new FurnitureItem("SKU004", "Office Chair", 70, 120, 70, 15.0, false, false, false, location, "Seating");
                //products.Add(MultiplyProduct(product, 1));
                //product = new FurnitureItem("SKU005", "Bookshelf", 80, 200, 40, 30.0, false, false, false, location, "Storage");
                //products.Add(MultiplyProduct(product, 1));
                //product = new FurnitureItem("SKU006", "Queen Bed Frame", 160, 40, 200, 40.0, true, false, false, location, "Bed");
                //products.Add(MultiplyProduct(product, 1));
                //product = new FurnitureItem("SKU007", "Dresser", 120, 100, 50, 50.0, true, false, false, location, "Storage");
                //products.Add(MultiplyProduct(product, 1));
                //product = new FurnitureItem("SKU008", "Nightstand", 50, 60, 40, 10.0, false, false, false, location, "Storage");
                //products.Add(MultiplyProduct(product, 1));
                //product = new FurnitureItem("SKU009", "Recliner", 80, 100, 120, 35.0, true, false, true, location, "Seating");
                //products.Add(MultiplyProduct(product, 1));
                //product = new FurnitureItem("SKU010", "Patio Set", 150, 100, 150, 50.0, true, false, false, location, "Outdoor");
                //products.Add(MultiplyProduct(product, 1));
                //product = new FurnitureItem("SKU011", "TV Stand", 120, 50, 40, 25.0, true, false, false, location, "Entertainment");
                //products.Add(MultiplyProduct(product, 1));
                //product = new FurnitureItem("SKU012", "Wardrobe", 150, 220, 60, 75.0, false, false, false, location, "Storage");
                //products.Add(MultiplyProduct(product, 1));
                //product = new FurnitureItem("SKU013", "Kitchen Island", 120, 90, 70, 45.0, true, false, false, location, "Kitchen");
                //products.Add(MultiplyProduct(product, 1));
                //product = new FurnitureItem("SKU014", "Bar Stool", 40, 100, 40, 7.0, false, false, false, location, "Seating");
                //products.Add(MultiplyProduct(product, 1));
                //product = new FurnitureItem("SKU015", "Electric Fireplace", 100, 120, 40, 30.0, true, true, false, location, "Entertainment");
                //products.Add(MultiplyProduct(product, 1));

                //product = new GeneralItem("SKU101", "Ceramic Vase", 15.0, 30.0, 15.0, 2.0, true, true, false, location, "Home Decor");
                //products.Add(MultiplyProduct(product, 1));
                //product = new GeneralItem("SKU102", "Wool Blanket", 200.0, 2.0, 150.0, 1.5, true, false, false, location, "Textile");
                //products.Add(MultiplyProduct(product, 1));
                //product = new GeneralItem("SKU103", "Porcelain Dinner Set", 50.0, 30.0, 50.0, 10.0, true, true, false, location, "Kitchenware");
                //products.Add(MultiplyProduct(product, 1));
                //product = new GeneralItem("SKU104", "Stainless Steel Pot", 25.0, 20.0, 25.0, 3.0, true, false, false, location, "Cookware");
                //products.Add(MultiplyProduct(product, 1));
                //product = new GeneralItem("SKU105", "Leather Wallet", 12.0, 2.0, 10.0, 0.2, true, false, false, location, "Accessory");
                //products.Add(MultiplyProduct(product, 1));
                //product = new GeneralItem("SKU106", "Glass Water Bottle", 8.0, 25.0, 8.0, 0.5, true, true, false, location, "Drinkware");
                //products.Add(MultiplyProduct(product, 1));
                //product = new GeneralItem("SKU107", "Plastic Storage Bin", 60.0, 40.0, 40.0, 2.5, true, false, false, location, "Storage");
                //products.Add(MultiplyProduct(product, 1));
                //product = new GeneralItem("SKU108", "Cotton Bath Towel", 70.0, 1.0, 140.0, 0.5, true, false, false, location, "Textile");
                //products.Add(MultiplyProduct(product, 1));
                //product = new GeneralItem("SKU109", "Yoga Mat", 180.0, 0.5, 60.0, 1.0, true, false, false, location, "Fitness");
                //products.Add(MultiplyProduct(product, 1));
                //product = new GeneralItem("SKU110", "Canvas Backpack", 30.0, 45.0, 20.0, 1.2, true, false, false, location, "Bag");
                //products.Add(MultiplyProduct(product, 1));
                //product = new GeneralItem("SKU111", "Ceramic Mug", 10.0, 12.0, 10.0, 0.3, true, true, false, location, "Drinkware");
                //products.Add(MultiplyProduct(product, 1));
                //product = new GeneralItem("SKU112", "Wooden Cutting Board", 40.0, 2.0, 30.0, 1.8, true, false, false, location, "Kitchenware");
                //products.Add(MultiplyProduct(product, 1));
                //product = new GeneralItem("SKU113", "Steel Thermos", 10.0, 30.0, 10.0, 0.6, true, false, false, location, "Drinkware");
                //products.Add(MultiplyProduct(product, 1));
                //product = new GeneralItem("SKU114", "Cotton Bedsheet", 200.0, 1.0, 180.0, 1.2, true, false, false, location, "Textile");
                //products.Add(MultiplyProduct(product, 1));
                //product = new GeneralItem("SKU115", "Wicker Basket", 35.0, 25.0, 35.0, 0.8, true, false, false, location, "Home Decor");
                //products.Add(MultiplyProduct(product, 1));

                return products;
            }
        }
    }
