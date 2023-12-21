using System.Runtime.InteropServices.JavaScript;
using model.kitchen.Observables;
using model.kitchen.Observers;

namespace model.kitchen;

public class FoodStuff: FoodStuffsObservable
{
    public List<FoodStuffObserver> Observers;
    public string Name;
    public int initialQuantity;
    public int Quantity;
    private Object verrou = new();

    public FoodStuff(string name, int quantity)
    {
        Observers = new List<FoodStuffObserver>();
        Name = name;
        initialQuantity = quantity;
        Quantity = quantity;
    }

    public bool use(int quantity)
    {
        lock (verrou)
        {
            
            if(this.Quantity >= quantity){
                this.Quantity -= quantity;
                return true;
            }
            else
            {
                
                notifyAll();
                return false;
                
            }
        }
       
    }

    public void Reset()
    {
        lock (verrou)
        {
            Quantity = initialQuantity;
        }
        
    }
    

    public void addSubscriber(FoodStuffObserver o)
    {
        Observers.Add(o);
    }

    public void notifyAll()
    {
        foreach (var observer in Observers)
        {
            observer.updateFoodStuff(this);
        }
    }
}