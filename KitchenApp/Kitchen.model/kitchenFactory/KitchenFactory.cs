using model.kitchen.KitchenMaterials;
using model.kitchen.kitchenStaff;

namespace model.kitchen.kitchenFactory;

public class KitchenFactory
{
    public MenuCard _menuCard;
    public Commis commis;

    private readonly List<Recipe> _recipeList = new()
    {
        new Recipe(
            "omelettes",
            40,
            30,
            2
        ),
        new Recipe(
            "ndolet",
            10,
            60,
            5
        ),
        new Recipe(
            "okok",
            10,
            40,
            6
        )
    };

    public List<Cook> Cooks;
    public List<FoodStuff> FoodStuffs;

    public List<SimulationTools> KitchenTools = new()
    {
        new KitchenTools("louche", 6),
        new KitchenTools("Marmite", 6),
        new KitchenTools("poêle", 6)
    };

    public KitchenStaff manager;
    public List<IRecipe> Recipes = new();

    public List<RecipeStep> steps = new()
    {
        new("Casser les oeufs", 10000),
        new("Mettre le sel", 1),
        new("faire cuire", 10),
        new("Bouillir les légumes", 20),
        new("laisser refroidir", 20),
        new("mettre des crevettes", 1),
        new("Mettre les noix", 10),
        new("Mettre du sel", 5),
        new("Laisser cuire", 10)
    };

    public List<List<object>> testSimChoice = new()
    {
        new List<object>()
        {
            0, new List<int> { 0, 1, 2 }, new Dictionary<int, int> { { 0, 3 }, { 1, 4 } },
            new Dictionary<int, int> { { 2, 1 } }
        },
        new List<object>()
        {
            1, new List<int> { 3, 4, 5 }, new Dictionary<int, int> { { 0, 2 }, { 1, 3 } },
            new Dictionary<int, int> { { 1, 4 }, { 2, 6 } }
        },
        new List<object>()
        {
            2, new List<int> { 6, 7, 8 }, new Dictionary<int, int> { { 0, 2 }, { 2, 3 } },
            new Dictionary<int, int> { { 1, 4 }, { 0, 6 } }
        }
    };

    public KitchenFactory()

    {
        Cooks = new List<Cook>
        {
            new("Jean"),
            new("Pierre"),
            new("Victoire")
        };
        manager = new KitchenManager(Cooks);
        commis = new Commis("CommisCuisine");
        

        FoodStuffs = createFoodStuffs();
        foreach (var stuff in FoodStuffs)
        {
            stuff.addSubscriber(commis);
        }
        foreach (var tuple in testSimChoice)
            Recipes.Add(createRecipe((int)tuple[0], (List<int>)tuple[1], (Dictionary<int, int>)tuple[2],
                (Dictionary<int, int>)tuple[3]));

        createMenuCard(Recipes);
    }

    public MenuCard menuCard
    {
        get => _menuCard;
        set => _menuCard = value;
    }


    public IRecipe createRecipe(int recipeIndice, List<int> stepsIndice, Dictionary<int, int> toolsIndices,
        Dictionary<int, int> ingredientsIndices)
    {
        var steps = new List<RecipeStep>();
        foreach (var i in stepsIndice) steps.Add(createStep(i, toolsIndices, ingredientsIndices));

        return new Recipe(_recipeList[recipeIndice].name, steps, _recipeList[recipeIndice]._cookingTime,
            _recipeList[recipeIndice].preparationTime, _recipeList[recipeIndice].restTime);
    }

    public RecipeStep createStep(int stepIndice, Dictionary<int, int> toolsIndices,
        Dictionary<int, int> foodStuffIndices)
    {
        var tools = new Dictionary<SimulationTools, int>();
        foreach (var pair in toolsIndices) tools.Add(KitchenTools[pair.Key], pair.Value);
        var foodStuffs = new Dictionary<FoodStuff, int>();
        foreach (var kv in foodStuffIndices) foodStuffs.Add(FoodStuffs[kv.Key], kv.Value);
        return new RecipeStep(steps[stepIndice].stepInstruction, foodStuffs, steps[stepIndice].stepDuration, tools);
    }


    public List<FoodStuff> createFoodStuffs()
    {
        return new List<FoodStuff>
        {
            new("Tomate", 10),
            new("Igname", 50),
            new("patate", 4)
        };
    }


    public void createMenuCard(List<IRecipe> recipes)
    {
        menuCard = new MenuCard(recipes);
    }
}