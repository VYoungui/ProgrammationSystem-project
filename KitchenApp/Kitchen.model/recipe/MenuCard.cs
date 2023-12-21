namespace model.kitchen;

public class MenuCard
{
    public List<IRecipe> choosenRecipes = new();

    private List<int> recipeIndices;

    public MenuCard(List<IRecipe> recipes)
    {
        setSimRecipes(recipes);
    }

    // Définit la liste des recettes de la simulation: Elle seront présentes sur la carte
    public void setSimRecipes(List<IRecipe> recipes)
    {
        choosenRecipes = recipes;
    }

    public void afficherCarte()
    {
        foreach (Recipe recette in choosenRecipes) recette.afficher();
    }

    public List<IRecipe> order(List<int> recipesIndices)
    {
        List<IRecipe> recipes = new List<IRecipe>();
        foreach (var i in recipesIndices)
        {
            recipes.Add((Recipe)choosenRecipes[i]);
        }
        Console.WriteLine("Le client passe une commande...");
        Thread.Sleep(5000);

        return recipes;
    }
}