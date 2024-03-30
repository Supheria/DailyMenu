using DailyMenu.IO.UI;
using LocalUtilities.SerializeUtilities;
using LocalUtilities.StringUtilities;
using System.Xml;
using System.Xml.Serialization;

namespace DailyMenu.UI.IO;

[XmlRoot(nameof(MemberForm))]
public class RosterFormDataSerialization : XmlSerialization<RosterFormData>
{
    public RosterFormDataSerialization() : base(nameof(MemberForm))
    {
    }

    public override void ReadXml(XmlReader reader)
    {
        var size = reader.GetAttribute(nameof(Source.Size)).ToArray();
        var location = reader.GetAttribute(nameof(Source.Location)).ToArray();
        Source = new()
        {
            Size = size.Length > 1
            ? new(size[0].ToInt() ?? 0, size[1].ToInt() ?? 0)
            : new(),
            Location = location.Length > 1
            ? new(location[0].ToInt() ?? 0, location[1].ToInt() ?? 0)
            : new(),
            WindowState = reader.GetAttribute(nameof(Source.WindowState)).ToEnum<FormWindowState>(),
        };
    }

    public override void WriteXml(XmlWriter writer)
    {
        if (Source is null)
            return;
        writer.WriteAttributeString(nameof(Source.Size),
            StringSimpleTypeConverter.ToArrayString(Source.Size.Width, Source.Size.Height));
        writer.WriteAttributeString(nameof(Source.Location),
            StringSimpleTypeConverter.ToArrayString(Source.Location.X, Source.Location.Y));
        writer.WriteAttributeString(nameof(Source.WindowState), Source.WindowState.ToString());
    }
}
