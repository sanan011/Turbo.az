using System;

namespace structrecord
{
    internal class Program
    {
        static void Main(string[] args)
        {
            VehicleController vehicleController = new VehicleController();
            UserController userController = new UserController();

            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Sign In");
                Console.WriteLine("2. Sign Up");
                Console.WriteLine("3. Show All Vehicles");
                Console.WriteLine("4. Add Vehicle");
                Console.WriteLine("5. Remove Vehicle");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");

                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        userController.SignIn();
                        break;
                    case "2":
                        userController.SignUp();
                        break;
                    case "3":
                        vehicleController.ShowAllVehicles();
                        break;
                    case "4":
                        vehicleController.AddVehicle();
                        break;
                    case "5":
                        vehicleController.RemoveVehicle();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}
