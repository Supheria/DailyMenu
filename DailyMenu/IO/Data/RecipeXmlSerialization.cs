using DailyMenu.Data.Model;
using LocalUtilities.SerializeUtilities;
using System.Xml;
using System.Xml.Serialization;

namespace DailyMenu.IO.Data;

public class RecipeXmlSerialization() : XmlSerialization<Recipe>(new())
{
    public override string LocalName => nameof(Recipe);

    public override void ReadXml(XmlReader reader)
    {
        var signature = reader.GetAttribute(nameof(Source.Signature)) ?? "";
        var recipe = new Dictionary<string, float>();
        recipe.ReadXmlCollection(reader, LocalName, new RecipeItemXmlSerialization());
        Source = new(signature, recipe);
    }

    public override void WriteXml(XmlWriter writer)
    {
        writer.WriteAttributeString(nameof(Source.Signature), Source.Signature);
        Source.RecipeList.WriteXmlCollection(writer, new RecipeItemXmlSerialization());
    }
}
