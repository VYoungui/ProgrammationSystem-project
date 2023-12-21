namespace model.kitchen;

public class PrecookedRecipe : Recipe
{
    public PrecookedRecipe(string name, List<RecipeStep> cookingSteps, double cookingTime, double preparationTime,
        double restTime) : base(name, cookingSteps, cookingTime, preparationTime, restTime)
    {
    }
}