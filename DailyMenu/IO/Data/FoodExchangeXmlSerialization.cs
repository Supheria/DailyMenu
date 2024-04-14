using DailyMenu.Data.Model;
using LocalUtilities.SerializeUtilities;
using LocalUtilities.StringUtilities;
using System.Xml;
using System.Xml.Serialization;


namespace DailyMenu.IO.Data;

public class FoodExchangeXmlSerialization() : XmlSerialization<FoodExchange>(new())
{

    public override string LocalName => nameof(FoodExchange);

    public override void ReadXml(XmlReader reader)
    {
        Source.Signature = reader.GetAttribute(nameof(Source.Signature)) ?? Source.Signature;
        Source.Mass = reader.GetAttribute(nameof(Source.Mass)).ToUint() ?? Source.Mass;
        Source.Protein = reader.GetAttribute(nameof(Source.Protein)).ToFloat() ?? Source.Protein;
        Source.Fat = reader.GetAttribute(nameof(Source.Fat)).ToFloat() ?? Source.Fat;
        Source.Carbo = reader.GetAttribute(nameof(Source.Carbo)).ToFloat() ?? Source.Carbo;
    }

    public override void WriteXml(XmlWriter writer)
    {
        writer.WriteAttributeString(nameof(Source.Signature), Source.Signature);
        writer.WriteAttributeString(nameof(Source.Mass), Source.Mass.ToString());
        writer.WriteAttributeString(nameof(Source.Protein), Source.Protein.ToString());
        writer.WriteAttributeString(nameof(Source.Fat), Source.Fat.ToString());
        writer.WriteAttributeString(nameof(Source.Carbo), Source.Carbo.ToString());
    }
}
