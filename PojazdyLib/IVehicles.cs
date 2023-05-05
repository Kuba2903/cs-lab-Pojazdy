using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PojazdyLib
{
    public interface IVehicles
    {
        enum Environment { land, water, air}
        public IVehicles.Environment environment { get; }
        enum FuelType { gas, oil, lpg}
        public IVehicles.FuelType Fuel { get; }
        enum State { moving,standing}
        public IVehicles.State state {get; set;}
        public int Speed { get; set; }

        public bool IsOn { get; set; }

        public int HorsePower { get; }

        public bool IsMotorEngine { get; }

        void Run()
        {
            IsOn = true;
            state = State.standing;
            Console.WriteLine("The vehicle is on");
        }

        void TurnOff()
        {
            IsOn = false;
            state = State.standing;
            Console.WriteLine("The vehicle is off");
        }

        void Stop()
        {
            Speed = 0;
            state = State.standing;
            Console.WriteLine("The vehicle stops");
        }

    }
}
