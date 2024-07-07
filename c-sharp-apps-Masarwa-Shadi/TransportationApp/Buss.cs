using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Masarwa_Shadi.TransportationApp
{
    public class Buss:PublicVehicle
    {
        private readonly int doors=0;
        private bool bellStop = false;

        public bool BellStop { get => bellStop; set => bellStop = value; }

        public int Doors => doors;

        public Buss()
        {
            doors = 0;
            BellStop = false;
        }

       
        public Buss(int line, int id, int maxSpeed, int seats, int doors) : base(line, id, maxSpeed, seats)
        {
            this.doors = doors;
            MaxSpeed=maxSpeed;
        }

        public override int MaxSpeed
        {
            set
            {
                int vehicleMaxSpeed = 120;
                if (value <= vehicleMaxSpeed && value > 0)
                    maxSpeed = value; ;
            }
        }



        public override bool CalculateHasRoom()
        {
            if (Math.Round(Seats * 1.1) > CurrentPassengers)
                return true;
            return false;
        }

        public override void UploadPassengers(int passengers)
        {
            int allSeats = (int)Math.Round(Seats * 1.1);
            if (CalculateHasRoom() == false)
            {
                //Console.WriteLine("Bus if Full!!");
                return;
            }
            if (passengers + CurrentPassengers <= allSeats)
            {
                CurrentPassengers += passengers;
                //Console.WriteLine("All passengers registered successfully!!");
            }
            else
            {
                RejectedPassengers = Math.Abs(Seats - (CurrentPassengers + passengers));
                CurrentPassengers = allSeats;
                //Console.WriteLine($"{passengers- RejectedPassengers} were registred, {RejectedPassengers} were rejected!!");
            }
        }

        public override string ToString()
        {
            return base.ToString()+$", Doors: {Doors}, Bell Stop: {BellStop}";
        }
    }
}
