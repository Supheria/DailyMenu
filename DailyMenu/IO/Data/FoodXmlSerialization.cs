using DailyMenu.Data.Model;
using LocalUtilities.SerializeUtilities;
using System.Resources;
using System.Xml;
using System.Xml.Serialization;

namespace DailyMenu.IO.Data;

public class FoodXmlSerialization() : XmlSerialization<Food>(new Food())
{

    public override string LocalName => throw new NotImplementedException();

    public override void ReadXml(XmlReader reader)
    {
        Source.Signature = reader.GetAttribute(nameof(Source.Signature)) ?? Source.Signature;
        Source.Category = reader.GetAttribute(nameof(Source.Category)) ?? Source.Category;
    }

    public override void WriteXml(XmlWriter writer)
    {
        writer.WriteAttributeString(nameof(Source.Signature), Source.Signature);
        writer.WriteAttributeString(nameof(Source.Category), Source.Category);
    }
}
