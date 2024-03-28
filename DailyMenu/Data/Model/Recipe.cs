using LocalUtilities.Interface;

namespace DailyMenu.Data.Model;

public class Recipe(string title, Dictionary<string, uint> recipe) : IRosterItem
{
    public string Name => _title;

    string _title = title;

    public string Title => _title;

    Dictionary<string, uint> _recipe = recipe;

    public KeyValuePair<string, uint>[] RecipeList => _recipe.ToArray();

    public uint this[string foodName]
    {
        get
        {
            uint copies = _recipe.TryGetValue(foodName, out var c) ? c : 0;
            return copies;
        }
        set => _recipe[foodName] = value;
    }
}
