﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Masarwa_Shadi.TransportationApp.shared
{
    public interface IShippingPriceCalculator
    {
        int PrintInvoice(CargoVehicle cargoVehicle, double distance);
    }
}
