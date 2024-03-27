using DailyMenu.Data.Model;
using DailyMenu.IO.Data;
using LocalUtilities.SerializeUtilities;
using System.Xml;
using System.Xml.Serialization;

namespace DailyMenu.Data.IO;

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
