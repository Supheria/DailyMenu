using DailyMenu.IO.UI;
using LocalUtilities.UIUtilities;
using System.Xml;
using System.Xml.Serialization;

namespace DailyMenu.UI.IO;

public abstract class RosterFormDataSerialization<T> : FormDataXmlSerialization<T> where T : RosterFormData
{
    public RosterFormDataSerialization(string localName, T rosterFormData) : base(localName, rosterFormData)
    {
        OnRead += Reading;
        OnWrite += Writing;
    }

    private void Reading(XmlReader reader)
    {
        Source.BackColor = Color.FromName(reader.GetAttribute(nameof(Source.BackColor)) ?? Color.White.Name);
    }

    private void Writing(XmlWriter writer)
    {
        writer.WriteAttributeString(nameof(Source.BackColor), Source.BackColor.Name);
    }
}
