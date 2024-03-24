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

[XmlRoot(nameof(Members))]
public class MembersXmlSerialization : XmlSerialization<Members>
{
    public MembersXmlSerialization() : base(nameof(Members))
    {
    }

    public override void ReadXml(XmlReader reader)
    {
        var members = new List<Member>();
        members.ReadXmlCollection(reader, LocalRootName, new MemberXmlSerialization());
        Source = new(members.ToArray());
    }

    public override void WriteXml(XmlWriter writer)
    {
        if (Source is null)
            return;
        Source.MemberList.WriteXmlCollection(writer, new MemberXmlSerialization());
    }
}
