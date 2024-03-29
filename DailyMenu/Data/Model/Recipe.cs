using LocalUtilities.Interface;

namespace DailyMenu.Data.Model;

public class Recipe(string title, Dictionary<string, float> recipe) : IRosterItem
{
    public string Name => _title;

    string _title = title;

    public string Title => _title;

    Dictionary<string, float> _recipe = recipe;

    public KeyValuePair<string, float>[] RecipeList => _recipe.ToArray();

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
            var food = FoodRoster.Roster[foodItem.Key];
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
