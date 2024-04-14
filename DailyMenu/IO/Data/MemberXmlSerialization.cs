using DailyMenu.Data.Model;
using DailyMenu.Flags;
using LocalUtilities.SerializeUtilities;
using LocalUtilities.StringUtilities;
using System.Xml;
using System.Xml.Serialization;

namespace DailyMenu.IO.Data;

public class MemberXmlSerialization() : XmlSerialization<Member>(new())
{
    public override string LocalName => nameof(Member);

    public override void ReadXml(XmlReader reader)
    {
        Source.Signature = reader.GetAttribute(nameof(Source.Signature)) ?? Source.Signature;
        Source.Height = reader.GetAttribute(nameof(Source.Height)).ToFloat() ?? Source.Height;
        Source.Weight = reader.GetAttribute(nameof(Source.Weight)).ToFloat() ?? Source.Weight;
        Source.WorkIntensity = reader.GetAttribute(nameof(Source.WorkIntensity)).ToEnum<WorkIntensityFlag>();
    }

    public override void WriteXml(XmlWriter writer)
    {
        writer.WriteAttributeString(nameof(Source.Signature), Source.Signature);
        writer.WriteAttributeString(nameof(Source.Height), Source.Height.ToString());
        writer.WriteAttributeString(nameof(Source.Weight), Source.Weight.ToString());
        writer.WriteAttributeString(nameof(Source.WorkIntensity), Source.WorkIntensity.ToString());
    }
}
