using Tutorial2.Interfaces;

namespace Tutorial2.Containers;

public class GasContainer(double height, double tareWeight, double depth, double maxPayload, double pressure)
    : Container('G', height, tareWeight, depth, maxPayload), IHazardNotifier
{
    public double Pressure { get; } = pressure;
    
    public override void EmptyTheCargo()
    {
        CargoWeight *= 0.05;
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"Hazard situation occured on {SerialNumber} container. Message:\n{message}");
    }
}