using model.kitchen.KitchenMaterials;

namespace model.kitchen;

public class Recipe : IRecipe
{
    //temps de cuisson: au feu en minutes
    public double _cookingTime;

    //étapes de préparation
    public List<RecipeStep>? CookingSteps;

    //intitulé
    public string name;

    //temps de préparation:
    public double preparationTime;

    //Temps de repos
    public double restTime;


    public Recipe(string name, double cookingTime, double preparationTime, double restTime)
    {
        this.name = name;
        _cookingTime = cookingTime;
        this.preparationTime = preparationTime;
        this.restTime = restTime;
    }


    public Recipe(string name, List<RecipeStep> cookingSteps, double cookingTime, double preparationTime,
        double restTime)
    {
        this.name = name;
        CookingSteps = cookingSteps;
        _cookingTime = cookingTime;
        this.preparationTime = preparationTime;
        this.restTime = restTime;
    }


    public void afficher()
    {
        foreach (var cookingStep in CookingSteps)
        foreach (var ingredient in cookingStep.ingredients)
        foreach (var tool in cookingStep.toolsToUse)
        {
            var tl = (KitchenTools)tool.Key;
            Console.WriteLine(name + " " + _cookingTime + " " + preparationTime + " " + cookingStep.stepInstruction +
                              " " + ingredient.Value + " " + ingredient.Key.Name + " " + tool.Value + " " +
                              tl.ToolName);
        }
    }
}