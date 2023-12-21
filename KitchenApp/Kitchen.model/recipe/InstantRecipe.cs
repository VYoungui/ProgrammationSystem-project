namespace model.kitchen;

public class InstantRecipe : Recipe
{
    public InstantRecipe(string name, List<RecipeStep> cookingSteps, double cookingTime, double preparationTime,
        double restTime) : base(name, cookingSteps, cookingTime, preparationTime, restTime)
    {
    }
}