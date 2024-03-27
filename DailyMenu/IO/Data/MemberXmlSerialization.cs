using DailyMenu.Data.Model;
using DailyMenu.Flags;
using LocalUtilities.SerializeUtilities;
using LocalUtilities.StringUtilities;
using System.Xml;
using System.Xml.Serialization;

namespace DailyMenu.IO.Data;

[XmlRoot(nameof(Member))]
public class MemberXmlSerialization : XmlSerialization<Member>
{
    public MemberXmlSerialization() : base(nameof(Member))
    {
    }

    public override void ReadXml(XmlReader reader)
    {
        Source = new(
            reader.GetAttribute(nameof(Source.Name)) ?? "",
            reader.GetAttribute(nameof(Source.Height)).ToFloat() ?? 0f,
            reader.GetAttribute(nameof(Source.Weight)).ToFloat() ?? 0f,
            reader.GetAttribute(nameof(Source.WorkIntensity)).ToEnum<WorkIntensityFlag>()
            );
    }

    public override void WriteXml(XmlWriter writer)
    {
        if (Source is null)
            return;
        writer.WriteAttributeString(nameof(Source.Name), Source.Name);
        writer.WriteAttributeString(nameof(Source.Height), Source.Height.ToString());
        writer.WriteAttributeString(nameof(Source.Weight), Source.Weight.ToString());
        writer.WriteAttributeString(nameof(Source.WorkIntensity), Source.WorkIntensity.ToString());
    }
}
