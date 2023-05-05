namespace PojazdyLib
{
    public class LandVehicles : IVehicles
    {
        public int Speed { get; set; }
        public bool IsOn { get; set; }
        public int WheelNum { get; }
        public IVehicles.State state { get; set; }
        public IVehicles.FuelType Fuel { get; set; }
        public IVehicles.Environment environment => IVehicles.Environment.land;

        public int HorsePower { get; }

        public bool IsMotorEngine { get; }

        public LandVehicles(int wheelNum, IVehicles.FuelType fuel, bool isMotorEngine, int horsePower = 0)
        {
            WheelNum = wheelNum;
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

                if(temp <= 350)
                {
                    Speed = temp;
                    state = IVehicles.State.moving;
                    Console.WriteLine($"The vehicle accelerates {speed} km/h");
                }
            }
        }

        public void SlowDown(int speed)
        {
            if(IsOn && speed < 0)
            {
                int temp = Speed;

                temp -= speed;

                if(temp >= 1)
                {
                    Speed = temp;
                    Console.WriteLine($"The vehicle slows down {speed} km/h");
                }
            }
        }
    }
}