using DailyMenu.IO.UI;
using LocalUtilities.UIUtilities;
using System.Xml;
using System.Xml.Serialization;

namespace DailyMenu.UI.IO;

[XmlRoot(nameof(RosterForm))]
public class RosterFormDataSerialization : FormDataXmlSerialization
{
    public RosterFormDataSerialization() : base(nameof(RosterForm))
    {
        OnRead += Reading;
        OnWrite += Writing;
    }

    private void Reading(XmlReader reader)
    {
        var source = new RosterFormData();
        source.BackColor = Color.FromName(reader.GetAttribute(nameof(source.BackColor)) ?? Color.White.Name);
        Source = source;
    }

    private void Writing(XmlWriter writer)
    {
        var source = Source as RosterFormData;
        if (source is not null)
            writer.WriteAttributeString(nameof(source.BackColor), source.BackColor.Name);
    }
}
