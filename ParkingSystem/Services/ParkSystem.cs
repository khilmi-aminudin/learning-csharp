using ParkingSystem.Models;
namespace ParkingSystem.Services;

public class ParkSystem
{
    private int totalLots;
    private Dictionary<int, Vehicle> parkingLots;


    public ParkSystem(int totalLots)
    {
        this.totalLots = totalLots;
        this.parkingLots = new Dictionary<int, Vehicle>();
    }

    public void CheckIn(string number, string color, string type)
    {
        if ( parkingLots.Count >= totalLots)
        {
            Console.WriteLine("Sorry, parking lot is full");
            return;
        }

        if (type.ToLower() != "motor" && type != "mobil")
        {
            Console.WriteLine("Sorry, vehicle type is not allowed");
            return;
        }

        var vehicle = new Vehicle(number.ToUpper(), color.ToUpper(), type.ToUpper());
        var slotNumber = GetNextAvailableSlot();
        parkingLots.Add(slotNumber, vehicle);
        Console.WriteLine("Allocated slot number: " + slotNumber);
    }

    private int GetNextAvailableSlot()
    {
        for (int i = 1; i <= totalLots; i++)
        {
            if (!parkingLots.ContainsKey(i))
            {
                return i;
            }
        }
        return -1;
    }

    public void CheckOut(int slotNumber)
    {
        if (parkingLots.ContainsKey(slotNumber))
        {
            parkingLots.Remove(slotNumber);
            Console.WriteLine("Slot number " + slotNumber + " is free");
        }
        else
        {
            Console.WriteLine("Invalid slot number");
        }
    }

    public void GetStatus()
    {
        Console.WriteLine("Slot Number\t\tType\t\tVehicle Number\t\tColor");
        foreach (var vehicle in parkingLots)
        {
            int slotNumber = vehicle.Key;
            var item = vehicle.Value;
            Console.WriteLine(slotNumber + "\t\t" + item.Number + "\t\t" + item.Type + "\t\t" + item.Color);
        }
    }

    public void GetNumberOfVehiclesByType(string vehicleType)
    {
        int count = parkingLots.Count(v => v.Value.Type.Equals(vehicleType.ToUpper(), StringComparison.OrdinalIgnoreCase));
        Console.WriteLine("Slot Number\t\tType\t\tVehicle Number\t\tColor");
        foreach (var vehicle in parkingLots)
        {
            int slotNumber = vehicle.Key;
            var item = vehicle.Value;
            if (item.Type == vehicleType.ToUpper())
            {
                Console.WriteLine(slotNumber + "\t\t" + item.Number + "\t\t" + item.Type + "\t\t" + item.Color);
            }
        }
        Console.WriteLine($"Total : {count}");
    }

    public void GetRegistrationNumbersByOddEven(string oddEven)
    {
        List<string> vehicleNumbers = parkingLots.Values
            .Where(v => IsOddEven(GetLastDigit(v.Number)) == oddEven)
            .Select(v => v.Number)
            .ToList();

        Console.WriteLine(string.Join(", ", vehicleNumbers));
    }

    public void GetRegistrationNumbersByColor(string color)
    {
        List<string> vehicleNumbers = parkingLots.Values
            .Where(v => v.Color == color.ToUpper())
            .Select(v => v.Number)
            .ToList();

        Console.WriteLine(string.Join(", ", vehicleNumbers));
    }

    public void GetSlotNumbersByColor(string color)
    {
        var msg = "";
        foreach (var slot in parkingLots)
        {
            if (slot.Value.Color == color.ToUpper())
            {
                msg += $"{slot.Key}, ";
            }
        }
        Console.WriteLine(msg);
    }

    public void GetSlotNumberByRegistrationNumber(string number)
    {
        var slotNumbern = 0;
        foreach (var slot in parkingLots)
        {
            if (slot.Value.Number == number.ToUpper())
            {
                slotNumbern = slot.Key;
            }
        }

        if (slotNumbern == 0)
        {
            Console.WriteLine("Not Found");
        }
        else
        {
            Console.WriteLine(slotNumbern);
        }
    }

    private string IsOddEven(string digit)
    {
        int lastDigit = int.Parse(digit);
        return lastDigit % 2 == 0 ? "Even" : "Odd";
    }

    private string GetLastDigit(string str)
    {
        string[] tmpStr = str.Split('-');
        return tmpStr[1].Substring(tmpStr.Length - 1);
    }
}