using System;
using System.Collections.Generic;

namespace structrecord
{
    public class VehicleController
    {
        private List<IVehicle> vehicles = new List<IVehicle>();

        public void ShowAllVehicles()
        {
            if (vehicles.Count == 0)
            {
                Console.WriteLine("No vehicles available.");
                return;
            }

            for (int i = 0; i < vehicles.Count; i++)
            {
                Console.WriteLine($"{i}. {vehicles[i].GetInfo()}");
            }
        }

        public void AddVehicle()
        {
            Console.Write("Enter brand: ");
            string brand = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(brand))
            {
                Console.WriteLine("Brand cannot be empty.");
                return;
            }

            Console.Write("Enter model: ");
            string model = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(model))
            {
                Console.WriteLine("Model cannot be empty.");
                return;
            }

            Console.Write("Enter price: ");
            string priceInput = Console.ReadLine();
            if (!decimal.TryParse(priceInput, out decimal price) || price < 0)
            {
                Console.WriteLine("Invalid price. Please enter a valid decimal value.");
                return;
            }

            Console.Write("Enter km: ");
            string kmInput = Console.ReadLine();
            if (!int.TryParse(kmInput, out int km) || km < 0)
            {
                Console.WriteLine("Invalid km. Please enter a non-negative integer.");
                return;
            }

            vehicles.Add(new Car(brand, model, price, km));
            Console.WriteLine("Vehicle added successfully.");
        }

        public void RemoveVehicle()
        {
            if (vehicles.Count == 0)
            {
                Console.WriteLine("No vehicles to remove.");
                return;
            }

            ShowAllVehicles();
            Console.Write($"Enter the index of the vehicle to remove (0 to {vehicles.Count - 1}): ");
            string indexInput = Console.ReadLine();

            if (!int.TryParse(indexInput, out int index))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return;
            }

            if (index < 0 || index >= vehicles.Count)
            {
                Console.WriteLine("Invalid index. Please enter a number within the range.");
                return;
            }

            vehicles.RemoveAt(index);
            Console.WriteLine("Vehicle removed successfully.");
        }
    }
}
