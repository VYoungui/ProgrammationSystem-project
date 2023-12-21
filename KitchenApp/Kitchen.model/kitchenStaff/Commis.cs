using model.kitchen.Observers;

namespace model.kitchen.kitchenStaff;


public class Commis: ClientOrderObserver, FoodStuffObserver
{
    public FoodStuff ingredients;
    public String Name;
    private Object lockd = new();
    
    
    public Commis(String name)
    {
        this.Name = name;
    }

    public void updateFoodStuff(FoodStuff foodStuff)
    {
        lock (lockd)
        {
            Console.WriteLine("Le "+this.Name+" réapprovisionne "+ foodStuff.Name);
            Thread.Sleep(2000);
            foodStuff.Reset();
        }
        
    }

  
}