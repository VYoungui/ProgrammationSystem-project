namespace model.kitchen;

public class RecipeStep
{
    //Liste d'ingrédient nécessaire pour l'étape
    public Dictionary<FoodStuff, int> ingredients;

    // Durée de la simulation de l'étape en millisecondes
    public int stepDuration;

    //Une instruction pour l'étape
    public string stepInstruction;

    //Liste du matériel à utiliser pour l'étape
    public Dictionary<SimulationTools, int> toolsToUse;


    //Etape avec denrée alimentaire à fournir
    public RecipeStep(string stepInstruction, Dictionary<FoodStuff, int> ingredients, int stepDuration,
        Dictionary<SimulationTools, int> toolsToUse)
    {
        this.stepInstruction = stepInstruction;
        this.stepDuration = stepDuration;
        this.toolsToUse = toolsToUse;
        this.ingredients = ingredients;
    }


    //étape simple
    public RecipeStep(string stepInstruction, int stepDuration)
    {
        this.stepInstruction = stepInstruction;
        this.stepDuration = stepDuration;
        toolsToUse = toolsToUse;
    }
}