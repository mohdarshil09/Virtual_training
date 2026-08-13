using System;

namespace Lab4
{
    // Base vehicle interface
    public interface IVehicle
    {
        string Model { get; }

        void Drive();
    }

    // Electric vehicle capabilities
    public interface IElectric
    {
        int BatteryPercent { get; set; }

        void Charge();
    }

    // Combines both interfaces
    public interface IElectricVehicle : IVehicle, IElectric
    {
    }

    // Implements the combined interface
    public class ElectricCar : IElectricVehicle
    {
        // Model can only be assigned during object initialization
        public string Model { get; init; }

        private int _batteryPercent;

        // Battery value is always kept between 0 and 100
        public int BatteryPercent
        {
            get
            {
                return _batteryPercent;
            }
            set
            {
                if (value < 0)
                    _batteryPercent = 0;
                else if (value > 100)
                    _batteryPercent = 100;
                else
                    _batteryPercent = value;
            }
        }

        // Reduce battery by 10%, minimum 0
        public void Drive()
        {
            BatteryPercent -= 10;
        }

        // Fully charge battery
        public void Charge()
        {
            BatteryPercent = 100;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Create ElectricCar
            ElectricCar car = new ElectricCar
            {
                Model = "Tesla Model 3",
                BatteryPercent = 100
            };

            // Drive three times
            car.Drive();
            Console.WriteLine($"Battery after drive 1: {car.BatteryPercent}%");

            car.Drive();
            Console.WriteLine($"Battery after drive 2: {car.BatteryPercent}%");

            car.Drive();
            Console.WriteLine($"Battery after drive 3: {car.BatteryPercent}%");

            // Charge
            car.Charge();
            Console.WriteLine($"Battery after charge: {car.BatteryPercent}%");

            // Use object through IVehicle interface
            IVehicle vehicle = car;

            Console.WriteLine(
                $"As IVehicle - Model: {vehicle.Model}"
            );

            // Use object through IElectric interface
            IElectric electric = car;

            Console.WriteLine(
                $"As IElectric - BatteryPercent: {electric.BatteryPercent}"
            );
        }
    }
}
