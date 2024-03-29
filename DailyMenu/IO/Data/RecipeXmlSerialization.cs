using DailyMenu.Data.Model;
using LocalUtilities.SerializeUtilities;
using System.Xml;
using System.Xml.Serialization;

namespace DailyMenu.IO.Data;

[XmlRoot(nameof(Recipe))]
public class RecipeXmlSerialization : XmlSerialization<Recipe>
{
    public RecipeXmlSerialization() : base(nameof(Recipe))
    {
    }

    public override void ReadXml(XmlReader reader)
    {
        var title = reader.GetAttribute(nameof(Source.Title)) ?? "";
        var recipe = new Dictionary<string, float>();
        recipe.ReadXmlCollection(reader, LocalRootName, new RecipeItemXmlSerialization());
        Source = new(title, recipe);
    }

    public override void WriteXml(XmlWriter writer)
    {
        if (Source is null)
            return;
        writer.WriteAttributeString(nameof(Source.Title), Source.Title);
        Source.RecipeList.WriteXmlCollection(writer, new RecipeItemXmlSerialization());
    }
}
