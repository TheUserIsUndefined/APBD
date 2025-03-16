namespace Tutorial2.Containers;

public class RefrigeratedContainer(double height, double tareWeight, double depth, double maxPayload, string productType, double temperature)
    : Container('C', height, tareWeight, depth, maxPayload)
{
    private Dictionary<string, double> _products = new Dictionary<string, double>
    {
        ["Bananas"] = 13.3,
        ["Chocolate"] = 18,
        ["Fish"] = 2,
        ["Meat"] = -15,
        ["Ice Cream"] = -18,
        ["Frozen pizza"] = -30,
        ["Cheese"] = 7.2,
        ["Sausages"] = 5,
        ["Butter"] = 20.5,
        ["Eggs"] = 19
    };
    
    private string _productType = productType;
    private double _temperature = temperature;

    public override void LoadCargo(double massOfCargo)
    {
        if (_products.ContainsKey(_productType) && _products[_productType] > _temperature)
        {
            Console.WriteLine("The temperature of the container is too low.");
            return;
        }
        
        base.LoadCargo(massOfCargo);
    }
}