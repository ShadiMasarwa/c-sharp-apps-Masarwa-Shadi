﻿using c_sharp_apps_Masarwa_Shadi.TransportationApp.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Masarwa_Shadi.TransportationApp
{
    internal class GeneralItem : Product
    {
        //private string type;

        public GeneralItem(string sku, string name, double width, double height, double length, double weight, bool packaged, bool fragile, bool loaded, StorageStructure location, string type) : base(sku, name, width, height, length, weight, packaged, fragile, loaded, location, type)
        {
           // Type = type;
        }

        //public string Type { get => type; set => type = value; }
    }
}
