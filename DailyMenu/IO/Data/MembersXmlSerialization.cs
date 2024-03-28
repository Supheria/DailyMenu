using DailyMenu.Data.Model;
using DailyMenu.IO.Data;
using LocalUtilities.SerializeUtilities;
using System.Xml;
using System.Xml.Serialization;

namespace DailyMenu.Data.IO;

[XmlRoot(nameof(Members))]
public class MembersXmlSerialization : RosterXmlSerialization<Members, Member>
{
    public MembersXmlSerialization() : base(nameof(Members), new MemberXmlSerialization(), new())
    {

    }
}
