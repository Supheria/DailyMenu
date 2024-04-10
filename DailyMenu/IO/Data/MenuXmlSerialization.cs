using DailyMenu.Data.Model;
using LocalUtilities.SerializeUtilities;
using System.Xml;
using System.Xml.Serialization;

namespace DailyMenu.IO.Data;

[XmlRoot(nameof(Menu))]
public class MenuXmlSerialization : XmlSerialization<Menu>
{
    public MenuXmlSerialization() : base(nameof(Menu))
    {
    }

    public override void ReadXml(XmlReader reader)
    {
        var date = reader.GetAttribute(nameof(Source.Date)) ?? "";
        var menu = new Dictionary<string, uint>();
        menu.ReadXmlCollection(reader, LocalRootName, new MenuItemXmlSerialization());
        Source = new(date, menu);
    }

    public override void WriteXml(XmlWriter writer)
    {
        if (Source is null)
            return;
        writer.WriteAttributeString(nameof(Source.Date), Source.Date);
        Source.MenuList.WriteXmlCollection(writer, new MenuItemXmlSerialization());
    }
}
