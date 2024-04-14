using LocalUtilities.Interface;

namespace DailyMenu.Data.Model;

public class Recipe(string signature, Dictionary<string, float> recipe) : RosterItem<string>(signature)
{

    Dictionary<string, float> _recipe { get; } = recipe;

    public KeyValuePair<string, float>[] RecipeList => _recipe.ToArray();

    public Recipe() : this("", [])
    {

    }

    public float this[string foodName]
    {
        get
        {
            var copies = _recipe.TryGetValue(foodName, out var c) ? c : 0f;
            return copies;
        }
        set => _recipe[foodName] = value;
    }

    public Nutrient? GetContent(uint copies)
    {
        Nutrient? content = null;
        foreach (var foodItem in _recipe)
        {
            var food = Rosters.Foods[foodItem.Key];
            if (food is null)
                continue;
            var foodContent = food.GetContent(foodItem.Value);
            if (foodContent is null)
                continue;
            content ??= new(0f, 0f, 0f, 0f);
            content += foodContent * copies;
        }
        return content;
    }
}
