namespace model.kitchen.clientOrder;

public class ClientOrder
{
    public OrderStatus OrderStatus;
    public List<IRecipe> recipes;

    public ClientOrder(List<IRecipe> recipes)
    {
        this.recipes = recipes;
        OrderStatus = OrderStatus.start;
    }
}