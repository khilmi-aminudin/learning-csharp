namespace ParkingSystem.Models;

public class Vehicle
{
    private string _number;
    private string _color;
    private string _type;

    public Vehicle(string number, string color, string type)
    {
        _number = number;
        _color = color;
        _type = type;
    }

    public String Number { get => _number; }
    public String Color { get => _color; }
    public String Type { get => _type; }
}