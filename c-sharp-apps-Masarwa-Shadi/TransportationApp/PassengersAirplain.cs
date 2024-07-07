using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Masarwa_Shadi.TransportationApp
{
    public class PassengersAirplain:PublicVehicle
    {
        private int enginesNum;
        private int wingLength;
        private int rows;
        private int columns;

        public int EnginesNum { get => enginesNum; set => enginesNum = value; }
        public int WingLength { get => wingLength; set => wingLength = value; }
        public int Rows { get => rows; set => rows = value; }
        public int Columns { get => columns; set => columns = value; }
        public override int MaxSpeed
        {
            set
            {
                int vehicleMaxSpeed = 1000;
                if (value <= vehicleMaxSpeed && value > 0)
                    maxSpeed = value; ;
            }
        }
        public PassengersAirplain()
        {
            EnginesNum = 0;
            WingLength = 0;
            Rows = 0;
            Columns = 0;
        }

        public PassengersAirplain(int enginesNum, int wingLength, int rows, int columns, int line, int id):base(line, id)
        {
            EnginesNum = enginesNum;
            WingLength = wingLength;
            Rows = rows;
            Columns = columns;
            Seats = rows * columns;
        }

        public override bool CalculateHasRoom()
        {
            if (Seats - 7 > CurrentPassengers)
                return true;
            return false;
        }

        public override void UploadPassengers(int passengers)
        {
            int allSeats = Seats - 7;
            if (CalculateHasRoom() == false)
            {
                //Console.WriteLine("Airplaine if Full!!");
                return;
            }
            if (passengers + CurrentPassengers <= allSeats)
            {
                CurrentPassengers += passengers;
                //Console.WriteLine("All passengers registered successfully!!");
            }
            else
            {
                RejectedPassengers = CurrentPassengers + passengers - allSeats;
                CurrentPassengers = allSeats;
                //Console.WriteLine($"{passengers - RejectedPassengers} were registred, {RejectedPassengers} were rejected!!");
            }
        }
        public override string ToString()
        {
            return base.ToString() + $", Engines: {EnginesNum}, Wing Length: {WingLength}, Rows:{Rows}, Columns: {Columns}";
        }
    }
}
