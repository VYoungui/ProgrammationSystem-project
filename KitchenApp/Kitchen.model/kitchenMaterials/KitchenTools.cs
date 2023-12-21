using model.kitchen.Observables;

namespace model.kitchen.KitchenMaterials;

public class KitchenTools : KitchenToolsObservable, SimulationTools
{
    public int AvailableQuantity;
    public string? ToolName;


    public KitchenTools(string name, int quantity)
    {
        ToolName = name;
        AvailableQuantity = quantity;
    }

    public bool Use(int quantity)
    {
        if (AvailableQuantity >= quantity)
        {
            AvailableQuantity -= quantity;
            return true;
        }
        else
        {
            return false;
        }
        
    }

    public void Release(int quantity)
    {
        AvailableQuantity += quantity;
    }
}