using c_sharp_apps_Masarwa_Shadi.TransportationApp.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Masarwa_Shadi.TransportationApp
{
    public class Driver
    {
        public enum License
        {
            Train,
            Ship,
            Airplane
        }
        private string fname;
        private string lname;
        private string id;
        private License licenseSort;
        private bool approveShipping;

        public string Fname { get => fname; set => fname = value; }
        public string Lname { get => lname; set => lname = value; }
        public string Id { get => id; set => id = value; }
        public License LicenseSort { get => licenseSort; set => licenseSort = value; }
        public bool ApproveShipping { get => approveShipping; set => approveShipping = value; }

        public Driver(string fname, string lname, string id, License licenseSort)
        {
            Fname = fname;
            Lname = lname;
            Id = id;
            LicenseSort = licenseSort;
        }
    }
}
