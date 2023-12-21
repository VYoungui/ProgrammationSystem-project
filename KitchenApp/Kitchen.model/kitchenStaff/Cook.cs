using model.kitchen.KitchenMaterials;

namespace model.kitchen.kitchenStaff;

public class Cook : KitchenStaff
{
    public bool IsWorking;

    public string name;
    public KitchenTask tasksToDo;

    public Cook(string name)
    {
        this.name = name;
    }

    public int runTask()
    {
        IsWorking = true;
        foreach (var e in tasksToDo.stepsToDo)
        {
            Console.WriteLine("je suis " + name + " et je fais: " + e.stepInstruction);
            foreach (var ing in e.ingredients)
            {
                if (!ing.Key.use(ing.Value) && ing.Key.initialQuantity >= ing.Value)
                {
                    Console.WriteLine("Ingrédient " + ing.Key.Name + " Non suffisant");
                    /*while (ing.Key.Quantity<ing.Value)
                    {
                    }*/

                    ing.Key.use(ing.Value);
                }
                else if (ing.Key.initialQuantity < ing.Value)
                {
                    ing.Key.initialQuantity = ing.Value;
                    /*while (ing.Key.Quantity<ing.Value)
                    {
                    }*/

                    ing.Key.use(ing.Value);
                }

                
                
            }

            foreach (var t in e.toolsToUse)
            {
                var tool = (KitchenTools)t.Key;
                // Console.WriteLine("il y'a "+tool.AvailableQuantity+" " +tool.ToolName);


                if (!tool.Use(t.Value))
                {
                    
                    Console.WriteLine(name + " attend des " + tool.ToolName);
                    while (!tool.Use(t.Value)) Thread.Sleep(1000);
                    Console.WriteLine(name + " a eu les " + tool.ToolName);
                }
                
            }

            Thread.Sleep(e.stepDuration);

            foreach (var t in e.toolsToUse)
            {
                var tool = (KitchenTools)t.Key;
                tool.Release(t.Value);
            }
        }

        return 1;
    }

   
}