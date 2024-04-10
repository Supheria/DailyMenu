using DailyMenu.Data.Model;
using LocalUtilities.SerializeUtilities;
using System.Xml.Serialization;

namespace DailyMenu.IO.Data;

[XmlRoot(nameof(Recipes))]
public class RecipesXmlSerialization : RosterXmlSerialization<Recipes, Recipe>
{
    public RecipesXmlSerialization() : base(nameof(Recipes), new RecipeXmlSerialization(), new())
    {

    }
}
