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

        public PassengersAirplain(int line, int id, int enginesNum, int wingLength, int rows, int columns):base(line, id)
        {
            EnginesNum = enginesNum;
            WingLength = wingLength;
            Rows = rows;
            Columns = columns;
            Seats = rows * columns;
        }

        public override void CalculateHasRoom()
        {
            if (Seats - 7 > CurrentPassengers)
                HasRoom = true;
            else
                HasRoom = false;
        }

        public override void UploadPassengers(int passengers)
        {
            CalculateHasRoom();
            int availableSeats = Seats - 7 - CurrentPassengers;
            if (!HasRoom)
            {
                //Console.WriteLine("Airplaine if Full!!");
                return;
            }
            if (passengers <= availableSeats)
            {
                CurrentPassengers += passengers;
                //Console.WriteLine("All passengers registered successfully!!");
            }
            else
            {
                RejectedPassengers = passengers-availableSeats;
                CurrentPassengers = Seats-7;
                //Console.WriteLine($"{passengers - RejectedPassengers} were registred, {RejectedPassengers} were rejected!!");
            }
            if (CurrentPassengers == Seats - 7)
                HasRoom = false;
        }
        public override string ToString()
        {
            return base.ToString() + $", Engines: {EnginesNum}, Wing Length: {WingLength}, Rows: {Rows}, Columns: {Columns}";
        }
    }
}
