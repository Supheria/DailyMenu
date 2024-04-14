using LocalUtilities.Interface;

namespace DailyMenu.Data.Model;

public class Menu(string signature, Dictionary<string, uint> menu) : RosterItem<string>(signature)
{
    Dictionary<string, uint> _menu { get; } = menu;

    public KeyValuePair<string, uint>[] MenuList => _menu.ToArray();

    public Menu() : this("", [])
    {

    }

    public uint this[string recipeTitle]
    {
        get
        {
            uint copies = _menu.TryGetValue(recipeTitle, out var c) ? c : 0;
            return copies;
        }
        set => _menu[recipeTitle] = value;
    }

    public Nutrient GetContent()
    {
        var content = new Nutrient(0f, 0f, 0f, 0f);
        foreach (var recipeItem in _menu)
        {
            var recipe = Rosters.Recipes[recipeItem.Key];
            if (recipe is null)
                continue;
            var recipeContent = recipe.GetContent(recipeItem.Value);
            if (recipeContent is null)
                continue;
            content += recipeContent;
        }
        return content;
    }
}
