using model.kitchen;
using model.kitchen.clientOrder;
using model.kitchen.kitchenStaff;

namespace controller.kitchen;

public class KitchenController
{
    public KitchenModel KitchenModel;
    //la carte de menus
    public MenuCard MenuCard;
    //L'objet commande
    public ClientOrder Order;
    //le chef de cuisine
    public KitchenManager Manager;
    //La liste des tâches données par le chef aux cuisiniers
    Dictionary<Cook, KitchenTask> tasks;
    
        
        
        
    public KitchenController(IKitchenModel kitchenModel)
    {
        KitchenModel =(KitchenModel)  kitchenModel;
        MenuCard = KitchenModel.MenuCard;
        Manager = KitchenModel.manager;
    }

    public void play()
    {
        // MenuCard.afficherCarte();
        
        //Le client commande un menu de recette de la carte
        Order = new ClientOrder(MenuCard.order(new List<int>()
        {
            0,1,2
        }));
        Console.WriteLine("La commandes est prise et envoyée au chef de cuisine...");
        //Le chef de cuisine reçoit la commande
        Manager.OrderToManage = Order;
        Thread.Sleep(1000);
        
        //Le chef assigne les tâches
        Console.WriteLine("Le chef a reçu la commande, il assigne les tâches");
        tasks = Manager.AssignTask(Manager.CooksToManage, Manager.OrderToManage);
        
        //Le chef lance l'exécution des tâches par les cuisiniers dans un thread séparé
        Manager.PendingOrders.Add(Manager.OrderToManage);
        int pendingOrderID = 0;
        pendingOrderID = Manager.PendingOrders.IndexOf(Manager.OrderToManage);
        
        Manager.LaunchTasks(tasks, pendingOrderID);

        



    }
}

