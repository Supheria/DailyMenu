using DailyMenu.Data.Model;
using LocalUtilities.SerializeUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace DailyMenu.IO.Data;

[XmlRoot(nameof(Foods))]
public class FoodsXmlSerialization : XmlSerialization<Foods>
{
    public FoodsXmlSerialization() : base(nameof(Foods))
    {
    }

    public override void ReadXml(XmlReader reader)
    {
        throw new NotImplementedException();
    }

    public override void WriteXml(XmlWriter writer)
    {
        throw new NotImplementedException();
    }
}
