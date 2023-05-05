using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PojazdyLib.IVehicles;

namespace PojazdyLib
{
    public class AirVehicle : IVehicles
    {
        public IVehicles.FuelType Fuel {get; set;}

        public IVehicles.State state { get; set; }
        public IVehicles.Environment environment => IVehicles.Environment.air;

        public int Speed { get; set; }
        public bool IsOn { get; set ; }

        public bool InAir { get; private set; }

        public int HorsePower { get; }

        public bool IsMotorEngine { get; }

        public AirVehicle(FuelType fuel, bool isMotorEngine, int horsePower = 0)
        {
            Fuel = fuel;
            IsMotorEngine = isMotorEngine;
            if(IsMotorEngine)
                HorsePower = horsePower;
        }

        public void Accelerate(int speed)
        {
            if (IsOn && speed > 0)
            {
                int temp = Speed;

                temp += speed;

                if (temp <= 200)
                {
                    Speed = temp;
                    state = IVehicles.State.moving;
                    Console.WriteLine($"The vehicle accelerates {speed} m/s");
                }
            }
        }

        public void SlowDown(int speed)
        {
            if (IsOn && speed < 0)
            {
                int temp = Speed;

                temp -= speed;

                if (temp >= 20)
                {
                    Speed = temp;
                    Console.WriteLine($"The vehicle slows down {speed} m/s");
                }
            }
        }

        public void FromLandToAir()
        {
            if(Speed >= 20)
            {
                InAir = true;
                Console.WriteLine("The vehicle flyes");
            }
        }

        public void FromAirToLand()
        {
            if(Speed == 20)
            {
                InAir = false;
                Console.WriteLine("The vehicle is landing");
            }
        }

        public void Stop()
        {
            if (!InAir)
            {
                Speed = 0;
                state = State.standing;
                Console.WriteLine("The vehicle stops");
            }
        }
    }
}
