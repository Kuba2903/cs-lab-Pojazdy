using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PojazdyLib
{
    public class WaterVehicle : IVehicles
    {
        public IVehicles.FuelType Fuel => IVehicles.FuelType.oil;
        public IVehicles.Environment environment => IVehicles.Environment.water;

        public IVehicles.State state { get; set; }
        public int Speed { get; set ; }
        public bool IsOn { get; set; }

        public int Displacement { get; }

        public int HorsePower { get; }

        public bool IsMotorEngine { get; }

        public WaterVehicle(int displacement, bool Ismotoengine, int horsePower = 0)
        {
            Displacement = displacement;
            IsMotorEngine = Ismotoengine;
            if(IsMotorEngine)
                HorsePower = horsePower;
        }

        public void Accelerate(int speed)
        {
            if (IsOn && speed > 0)
            {
                int temp = Speed;

                temp += speed;

                if (temp <= 40)
                {
                    Speed = temp;
                    state = IVehicles.State.moving;
                    Console.WriteLine($"The vehicle accelerates {speed} km/h");
                }
            }
        }

        public void SlowDown(int speed)
        {
            if (IsOn && speed < 0)
            {
                int temp = Speed;

                temp -= speed;

                if (temp >= 1)
                {
                    Speed = temp;
                    Console.WriteLine($"The vehicle slows down {speed} km/h");
                }
            }
        }

    }
}
