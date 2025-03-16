using Tutorial2.Exceptions;
using Tutorial2.Interfaces;

namespace Tutorial2.Containers;

public class LiquidContainer(double height, double tareWeight, double depth, double maxPayload, bool isHazardous)
    : Container('L', height, tareWeight, depth, maxPayload), IHazardNotifier
{
    private bool _isHazardous = isHazardous;
    
    public override void LoadCargo(double cargoWeight)
    {
        CargoWeight += cargoWeight;
        if (CargoWeight > (_isHazardous ? MaxPayload * 0.5 : MaxPayload * 0.9))
        {
            if (_isHazardous)
                NotifyHazard("Hazardous cargo limit exceeded");
            throw new OverfillException();
        }
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"Hazard situation occured on {SerialNumber} container. Message:\n{message}");
    }
}