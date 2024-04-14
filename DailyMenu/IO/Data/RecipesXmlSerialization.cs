using DailyMenu.Data.Model;
using LocalUtilities.Serializations;
using LocalUtilities.SerializeUtilities;
using System.Xml.Serialization;

namespace DailyMenu.IO.Data;

public class RecipesXmlSerialization() : RosterXmlSerialization<Recipes, string, Recipe>(new(), new RecipeXmlSerialization())
{
    public override string LocalName => nameof(Recipes);
}
