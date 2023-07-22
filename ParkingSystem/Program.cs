namespace ParkingSystem;

using ParkingSystem.Models;
using ParkingSystem.Services;

public class Program
{
    public static void Main()
    {
        ParkSystem parkSystem = null;

        while (true)
        {
            string command = Console.ReadLine();
            string[] args = command.Split(' ');

            switch (args[0])
            {
                case "create_parking_lot":
                    int totalLots = int.Parse(args[1]);
                    parkSystem = new ParkSystem(totalLots);
                    Console.WriteLine($"Created a parking lot with { totalLots } slots");
                    Console.WriteLine();
                    break;
                case "park":
                    string registrationNumber = args[1];
                    string color = args[2];
                    string vehicleType = args[3];
                    parkSystem.CheckIn(registrationNumber, color, vehicleType);
                    Console.WriteLine();
                    break;
                case "leave":
                    int lotNumber = int.Parse(args[1]);
                    parkSystem.CheckOut(lotNumber);
                    Console.WriteLine();
                    break;
                case "status":
                    parkSystem.GetStatus();
                    Console.WriteLine();
                    break;
                case "type_of_vehicles":
                    parkSystem.GetNumberOfVehiclesByType(args[1]);
                    Console.WriteLine();
                    break;
                case "registration_numbers_for_vehicles_with_odd_plate":
                    parkSystem.GetRegistrationNumbersByOddEven("Odd");
                    Console.WriteLine();
                    break;
                case "registration_numbers_for_vehicles_with_even_plate":
                    parkSystem.GetRegistrationNumbersByOddEven("Even");
                    Console.WriteLine();
                    break;
                case "registration_numbers_for_vehicles_with_color":
                    parkSystem.GetRegistrationNumbersByColor(args[1]);
                    Console.WriteLine();
                    break;
                case "slot_numbers_for_vehicles_with_color":
                    string colorArg2 = args[1];
                    parkSystem.GetSlotNumbersByColor(colorArg2);
                    Console.WriteLine();
                    break;
                case "slot_number_for_registration_number":
                    string vehicleNumber = args[1];
                    parkSystem.GetSlotNumberByRegistrationNumber(vehicleNumber);
                    Console.WriteLine();
                    break;
                case "exit":
                    return;
                default:
                    Console.WriteLine("Invalid command");
                    Console.WriteLine();
                    break;
            }
        }
    }
}
