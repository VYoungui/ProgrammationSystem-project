using model.kitchen.clientOrder;
using model.kitchen.kitchenFactory;
using model.kitchen.kitchenStaff;

namespace model.kitchen;

public class KitchenModel : IKitchenModel
{
    public KitchenFactory factory;
    public KitchenManager manager;
    public MenuCard MenuCard;
    public ClientOrder order;


    public KitchenModel()
    {
        factory = new KitchenFactory();
        manager = (KitchenManager)factory.manager;
        MenuCard = factory.menuCard;
    }
}