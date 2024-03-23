using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using LocalUtilities;
using LocalUtilities.SerializeUtilities;

namespace DailyMenu.IO.Xml;

[XmlRoot("Members")]
public class MembersXmlSerialization : Serialization<Members>, IXmlSerialization<Members>
{
    public MembersXmlSerialization() : base("Members")
    {
    }

    public XmlSchema? GetSchema() => null;

    public void ReadXml(XmlReader reader)
    {
        var members = new List<Member>();
        members.ReadXmlCollection(reader, LocalRootName, new MemberXmlSerialization());
        Source = new(members.ToArray());
    }

    public void WriteXml(XmlWriter writer)
    {
        if (Source is null)
            return;
        Source.MemberList.WriteXmlCollection(writer, new MemberXmlSerialization());
    }
}
