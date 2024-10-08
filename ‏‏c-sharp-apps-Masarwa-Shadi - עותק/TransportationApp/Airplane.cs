﻿using c_sharp_apps_Masarwa_Shadi.TransportationApp.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Masarwa_Shadi.TransportationApp
{
    public class Airplane : CargoVehicle
    {
        public Airplane(Vehicle type, double width, double height, double length, double maxWeight, List<IPortable> items) : base(type, width, height, length, maxWeight, items)
        {
        }

        public override int NumOfItemsInUnits()
        {
            if (Items != null)
                return Items.Count;
            else
                return 0;
        }
    }
}
