using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Masarwa_Shadi.TransportationApp
{
    public class Crone
    {
        private readonly int rows, columns;

        public int Rows => rows;

        public int Columns => columns;

        public Crone(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
        }

        public Crone(Crone crone)
        {
            rows = crone.rows;
            columns = crone.columns;
        }

        public int GetSeats()
        {
            return Rows * Columns;
        }

        public int GetExtras()
        {
            return 2 * Rows;
        }
    }
}
