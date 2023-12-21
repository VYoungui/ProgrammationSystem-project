using model.kitchen.clientOrder;

namespace model.kitchen.kitchenStaff;

public class KitchenManager : KitchenStaff
{
    public Dictionary<Cook, KitchenTask> AssignedTaskList = new();
    public List<Cook> CooksToManage;
    public ClientOrder OrderToManage;
    public List<ClientOrder> PendingOrders = new();

    public KitchenManager(List<Cook> cooksToManage)
    {
        CooksToManage = cooksToManage;
    }

    public Dictionary<Cook, KitchenTask> AssignTask(List<Cook> cooks, ClientOrder order)
    {
        var counter = 0;
        var tasks = new Dictionary<Cook, KitchenTask>();


        var assignation = new Dictionary<Cook, List<RecipeStep>>();

        foreach (Recipe recette in order.recipes)
        foreach (var step in recette.CookingSteps)
        {
            Thread.Sleep(250);
            counter %= cooks.Count;
            if (assignation.ContainsKey(cooks[counter]))
            {
                assignation[cooks[counter]].Add(step);
            }
            else
            {
                if (!cooks[counter].IsWorking) assignation.Add(cooks[counter], new List<RecipeStep> { step });
            }

            counter++;
        }

        foreach (var element in assignation)
            tasks.Add(
                element.Key,
                new KitchenTask(assignation[element.Key])
            );


        return tasks;
    }


    public bool LaunchTasks(Dictionary<Cook, KitchenTask> assignedTaskList, int pendingOrderID)
    {
        ClientOrder order = PendingOrders[pendingOrderID];
        int counter=0;
        Semaphore semaphore = new Semaphore(1,1);
        Console.WriteLine("Le chef de cuisine lance les tâches");

        order.OrderStatus = OrderStatus.pending;
        List<Thread> threads = new List<Thread>();
        
        
        foreach (var e in assignedTaskList)
        {
            e.Key.tasksToDo = e.Value;
            var t = new Thread(() =>
            {
                int returned=0;
                returned = e.Key.runTask();
                semaphore.WaitOne();
                counter += returned;
                semaphore.Release();
            });
            threads.Add(t);
            t.Start();
            // t.Join();
            
        }

        while (counter!=threads.Count)
        {
            
        }

        order.OrderStatus = OrderStatus.completed;
        Console.WriteLine(order.OrderStatus);

        return true;
    }
}