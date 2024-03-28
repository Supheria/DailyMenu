using DailyMenu.Data.Model;
using LocalUtilities.SerializeUtilities;
using LocalUtilities.StringUtilities;
using System.Xml;
using System.Xml.Serialization;


namespace DailyMenu.IO.Data;

[XmlRoot(nameof(FoodExchange))]
public class FoodExchangeXmlSerialization : XmlSerialization<FoodExchange>
{
    public FoodExchangeXmlSerialization() : base(nameof(FoodExchange))
    {
    }

    public override void ReadXml(XmlReader reader)
    {
        Source = new(
            reader.GetAttribute(nameof(Source.Category)) ?? string.Empty,
            reader.GetAttribute(nameof(Source.Mass)).ToInt() ?? 0,
            reader.GetAttribute(nameof(Source.Protein)).ToFloat() ?? 0f,
            reader.GetAttribute(nameof(Source.Fat)).ToFloat() ?? 0f,
            reader.GetAttribute(nameof(Source.Carbo)).ToFloat() ?? 0f
            );
    }

    public override void WriteXml(XmlWriter writer)
    {
        if (Source is null)
            return;
        writer.WriteAttributeString(nameof(Source.Category), Source.Category);
        writer.WriteAttributeString(nameof(Source.Mass), Source.Mass.ToString());
        writer.WriteAttributeString(nameof(Source.Protein), Source.Protein.ToString());
        writer.WriteAttributeString(nameof(Source.Fat), Source.Fat.ToString());
        writer.WriteAttributeString(nameof(Source.Carbo), Source.Carbo.ToString());
    }
}
