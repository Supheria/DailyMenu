using DailyMenu.Data.Model;
using LocalUtilities.SerializeUtilities;
using System.Xml;
using System.Xml.Serialization;

namespace DailyMenu.IO.Data;

public class MenuXmlSerialization() : XmlSerialization<Menu>(new())
{
    public override string LocalName => nameof(Menu);

    public override void ReadXml(XmlReader reader)
    {
        var signature = reader.GetAttribute(nameof(Source.Signature)) ?? "";
        var menu = new Dictionary<string, uint>();
        menu.ReadXmlCollection(reader, LocalName, new MenuItemXmlSerialization());
        Source = new(signature, menu);
    }

    public override void WriteXml(XmlWriter writer)
    {
        writer.WriteAttributeString(nameof(Source.Signature), Source.Signature);
        Source.MenuList.WriteXmlCollection(writer, new MenuItemXmlSerialization());
    }
}
