using c_sharp_apps_Masarwa_Shadi.TransportationApp.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Masarwa_Shadi.TransportationApp
{
    public class ShippingPriceCalculator
    {
        //public ShippingPriceCalculator() { }

        private static double totalWeight = 0;
        private static double totalVolume = 0;
        private static double basicFees = 0;
        private static int totalFees = 0;
        private static double units = 0;
        private static string dash = new string('-', 70);

        public static void PrintInvoice(CargoVehicle cargoVehicle, double distance)
        {
            PrintHeader(cargoVehicle);
            if (cargoVehicle.Type == CargoVehicle.Vehicle.Airplane)
            {
                PrintSingleUnitItems(cargoVehicle);
                CalculateSingleUnitCargoFees(cargoVehicle, distance);
            }
            else
            {
                PrintMultiUnitItems((MultiUnitVehicle)cargoVehicle);
                CalculateMulipleUnitCargoFees((MultiUnitVehicle)cargoVehicle, distance);
            }
            PrintFooter();

        }
        public static int CalculateSingleUnitCargoFees(CargoVehicle cargoVehicle, double distance)
        {
            InitializeValues();
            if(cargoVehicle.Items==null || cargoVehicle.Items.Count==0) return 0;
            foreach (IPortable item in cargoVehicle.Items)
            {
                totalWeight += item.GetWeight();
                totalVolume += item.GetVolumeInCm();
                if (item.IsFragile())
                {
                    totalWeight += item.GetWeight();
                    totalVolume += item.GetVolumeInCm();
                }
            }
            basicFees = cargoVehicle.Type == CargoVehicle.Vehicle.Train ? 5 : cargoVehicle.Type == CargoVehicle.Vehicle.Ship ? 20 : 50;
            units = totalVolume / 100 + totalWeight;
            totalFees = (int)Math.Round(units * basicFees);
            return totalFees;
        }

        public static int CalculateMulipleUnitCargoFees(MultiUnitVehicle cargoVehicle, double distance)
        {
            InitializeValues();
            if (cargoVehicle.Units == null) return 0;

            foreach (GeneralContainer unit in cargoVehicle.Units)
                if(unit.Items!=null)
                foreach (IPortable item in unit.Items)
                    {
                        totalWeight += item.GetWeight();
                        totalVolume += item.GetVolumeInCm();
                        if (item.IsFragile())
                        {
                            totalWeight += item.GetWeight();
                            totalVolume += item.GetVolumeInCm();
                        }
                    }
            basicFees = cargoVehicle.Type == CargoVehicle.Vehicle.Train ? 5 : cargoVehicle.Type == CargoVehicle.Vehicle.Ship ? 20 : 50;
            units = totalVolume / 100 + totalWeight;
            totalFees = (int)Math.Round(units * basicFees);
            return totalFees;
        }



        public static void PrintHeader(CargoVehicle cargoVehicle)
        {
            Console.WriteLine($"{"Product",-30}{"Volume",-15}{"Weight",-15}{"Fragil",-10}");
            Console.WriteLine($"{"-------",-30}{"------",-15}{"------",-15}{"------",-10}");
            //if (cargoVehicle.Type == CargoVehicle.Vehicle.Airplane)
            //    PrintSingleUnitItems(cargoVehicle);
            //else
            //    PrintMultiUnitItems((MultiUnitVehicle)cargoVehicle);
        }
        private static void PrintItemDetails(IPortable item)
        {

            Console.WriteLine($"{item.Name,-30}{item.GetVolumeInCm() + " cm3",-15}{item.GetWeight() + " kg",-15}{item.IsFragile(),-10}");
        }

        private static void PrintSingleUnitItems(CargoVehicle cargoVehicle)
        {
            if (cargoVehicle.Items == null || cargoVehicle.Items.Count == 0) return;
            foreach (IPortable item in cargoVehicle.Items)
                PrintItemDetails(item);
        }

        private static void PrintMultiUnitItems(MultiUnitVehicle cargoVehicle)
        {
            foreach (GeneralContainer unit in cargoVehicle.Units)
                foreach (IPortable item in unit.Items)
                    PrintItemDetails(item);
        }

        private static void PrintFooter()
        {

            Console.WriteLine(dash);
            Console.WriteLine($"{"Total Weight (Fragles are doubled):",-40} {totalWeight:#,##0.00} Kg");
            Console.WriteLine($"{"Total Volume (Fragles are doubled):",-40} {totalVolume:#,##0.00} Cm3");
            Console.WriteLine($"{"Total units for calculation:",-40} {units:#,##0.00} units");
            Console.WriteLine($"{"Fees (in US $) for unit:",-40} {basicFees:#,##0.00} $");
            Console.WriteLine($"{"Total Price:",-40} {totalFees:#,##0.00}$");
            Console.WriteLine(dash+"\n");
            //Console.ReadKey();
        }

        private static void InitializeValues()
        {
            totalWeight = 0;
            totalVolume = 0;
            basicFees = 0;
            totalFees = 0;
            units = 0;

    }






    }
}
