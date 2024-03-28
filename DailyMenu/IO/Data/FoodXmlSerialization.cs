using DailyMenu.Data.Model;
using LocalUtilities.SerializeUtilities;
using System.Xml;
using System.Xml.Serialization;

namespace DailyMenu.IO.Data;

[XmlRoot(nameof(Food))]
public class FoodXmlSerialization : XmlSerialization<Food>
{
    public FoodXmlSerialization() : base(nameof(Food))
    {
    }

    public override void ReadXml(XmlReader reader)
    {
        Source = new(
            reader.GetAttribute(nameof(Source.Name)) ?? "",
            reader.GetAttribute(nameof(Source.Category)) ?? ""
            );
    }

    public override void WriteXml(XmlWriter writer)
    {
        if (Source is null)
            return;
        writer.WriteAttributeString(nameof(Source.Name), Source.Name);
        writer.WriteAttributeString(nameof(Source.Category), Source.Category);
    }
}
