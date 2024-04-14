using DailyMenu.Data.Model;
using DailyMenu.IO.Data;
using LocalUtilities.Serializations;
using LocalUtilities.SerializeUtilities;
using System.Xml.Serialization;

namespace DailyMenu.Data.IO;

public class MembersXmlSerialization : RosterXmlSerialization<Members, string, Member>
{
    public override string LocalName => nameof(Members);

    public MembersXmlSerialization() : base(new(), new MemberXmlSerialization())
    {

    }
}
