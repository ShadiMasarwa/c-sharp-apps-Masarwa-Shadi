using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Masarwa_Shadi.TransportationApp.shared
{
    public abstract class Product : IPortable
    {
        private string sku;
        private string name;
        private double width;
        private double height;
        private double length;
        private double weight;
        private bool packaged;
        private bool fragile = false;
        private bool loaded = false;
        private StorageStructure location;

        public Product(string sku, string name, double width, double height, double length, double weight, bool packaged, bool fragile, bool loaded, StorageStructure location)
        {
            this.sku = sku;
            this.name = name;
            this.width = width;
            this.height = height;
            this.length = length;
            this.weight = weight;
            this.packaged = packaged;
            this.fragile = fragile;
            this.loaded = loaded;
            this.location = location;
        }

        public string Name { get => name; set => name = value; }
        public string Sku { get => sku; set => sku = value; }
        public StorageStructure Location { get => location; set => location = value; }

        public double GetVolume()
        {
            return width/100 * height/100 * length/100;
        }
        public double GetWeight()
        {
            return weight;
        }
        public void PackageItem()
        {
            packaged = true;
        }
        public bool IsPackaged()
        {
            return packaged;
        }
        public void UnPackage()
        {
            packaged = false;
        }
        public bool IsFragile()
        {
            return fragile;
        }
        public void SetAsFragile()
        {
            fragile = true;
        }

        public bool IsLoaded()
        {
            return loaded;
        }

        public override string ToString()
        {
            return "Name: " + name;
        }

        public override bool Equals(object obj)
        {
            return obj is Product product &&
                   sku == product.sku &&
                   name == product.name &&
                   width == product.width &&
                   height == product.height &&
                   length == product.length &&
                   weight == product.weight &&
                   packaged == product.packaged &&
                   fragile == product.fragile &&
                   loaded == product.loaded &&
                   location == product.location;
        }


        //string sku, string name, double width, double height, double length, double weight, bool packaged, bool fragile, bool loaded, StorageStructure location
        //public StorageStructure GetLocation()
        //{
        //    return location;
        //}

        //public void SetLocation(StorageStructure storage)
        //{
        //    location = storage;
        //}
    }
}
