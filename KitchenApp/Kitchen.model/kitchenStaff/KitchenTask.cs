namespace model.kitchen.kitchenStaff;

public class KitchenTask
{
    public int ClientOrderPosition;
    public bool Status;
    public List<RecipeStep> stepsToDo;


    public KitchenTask(List<RecipeStep> stepsToDo)
    {
        this.stepsToDo = stepsToDo;
    }
}