using Tutorial2.Exceptions;

namespace Tutorial2.Containers;

public abstract class Container
{
    private char TypeCode;
    public double Height { get; }
    private double _tareWeight;
    public double Depth { get; }
    public string SerialNumber { get; }
    public double MaxPayload { get; }
    public double CargoWeight { get; set; }
    
    private static int IDCounter;

    protected Container(char typeCode, double height, double tareWeight, double depth, double maxPayload)
    {
        TypeCode = typeCode;
        Height = height;
        _tareWeight = tareWeight;
        Depth = depth;
        MaxPayload = maxPayload;

        SerialNumber = $"KON-{TypeCode}-{++IDCounter}";
    }
    
    public virtual void LoadCargo(double cargoWeight)
    {
        CargoWeight += cargoWeight;
        if (cargoWeight > MaxPayload)
            throw new OverfillException("The mass of cargo is too large.");
    }

    public virtual void EmptyTheCargo()
    {
        CargoWeight = 0;
    }

    public double TotalMass()
    {
        return CargoWeight+_tareWeight;
    }

    public override string ToString()
    {
        return
            $"Container {SerialNumber}:\nHeight: {Height},\nDepth: {Depth},\nTare Weight: {_tareWeight},\nLoaded Cargo Weight: {CargoWeight},\nMax Payload: {MaxPayload}";
    }
}