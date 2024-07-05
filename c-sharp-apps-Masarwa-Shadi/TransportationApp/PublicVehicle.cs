using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Masarwa_Shadi.TransportationApp
{
    public class PublicVehicle
    {
        private int line=0;
        private int id=0;
        protected int maxSpeed=0;
        private int seats= 0;
        private int currentPassengers = 0;
        private int rejrejecetedPassengers;
        private bool hasRoom = true;

        public PublicVehicle()
        {
        }

        public PublicVehicle(int line, int id)
        {
            this.line = line;
            this.id = id;
        }
        public PublicVehicle(int line, int id, int maxSpeed, int seats)
        {
            this.line = line;
            this.id = id;
            this.maxSpeed = maxSpeed;
            this.seats = seats;
        }

        public int Line { get => line; set => line = value; }
        public int Id { get => id; set => id = value; }
        public int MaxSpeed { get => maxSpeed; }
        public int Seats { get => seats; set => seats = value; }
        public int CurrentPassengers { get => currentPassengers; set => currentPassengers = value; }
        public int RejrejecetedPassengers { get => rejrejecetedPassengers; set => rejrejecetedPassengers = value; }
        public bool HasRoom { get => hasRoom; set => hasRoom = value; }

        public virtual void SetMaxSpeed(int value)
        {
            if (value <= 40 && value > 0)
                maxSpeed = value;
        }

        public virtual bool CalculateHasRoom()
        {
            if (seats < currentPassengers)
                return true;
            return false;
        }

        public virtual void UploadPassengers(int passengers)
        {
            if (CalculateHasRoom() == false)
                return;
            if (passengers + currentPassengers <= seats)
                currentPassengers += passengers;
            else
            {
                rejrejecetedPassengers = Math.Abs(seats - (currentPassengers + passengers));
                currentPassengers = seats;
            }
        }

        public override string ToString()
        {
            return $"Line:{line}, Id:{id}, MaxSpead:{maxSpeed}, Seats:{seats}";
        }
    }
}
