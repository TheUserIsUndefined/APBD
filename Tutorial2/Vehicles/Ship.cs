using Tutorial2.Containers;

namespace Tutorial2.Vehicles;

public class Ship(double maxSpeed, int maxNumberOfContainers, double maxWeight) 
    : Vehicle(maxSpeed, maxNumberOfContainers, maxWeight)
{

    public static void TransferContainerBetweenShips(Vehicle shipFrom, Vehicle shipTo, Container container)
    {
        string contNumber = container.SerialNumber;
        if (!shipFrom.LoadedContainers.Contains(container))
        {
            Console.WriteLine($"No container {contNumber} found");
            return;
        }

        if (shipTo.LoadContainer(container, false))
        {
            shipFrom.UnloadContainer(container, false);
            Console.WriteLine($"Container {contNumber} successfully transferred.");
        }

    }
}