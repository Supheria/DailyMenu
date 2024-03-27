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

[XmlRoot(nameof(FoodExchanges))]
public class FoodExchangesXmlSerialization : XmlSerialization<FoodExchanges>
{
    public FoodExchangesXmlSerialization() : base(nameof(FoodExchanges))
    {
    }

    public override void ReadXml(XmlReader reader)
    {
        var exchanges = new List<FoodExchange>();
        exchanges.ReadXmlCollection(reader, LocalRootName, new FoodExchangeXmlSerialization());
        Source = new(exchanges.ToArray());
    }

    public override void WriteXml(XmlWriter writer)
    {
        if (Source is null)
            return;
        Source.ExchangeList.WriteXmlCollection(writer, new FoodExchangeXmlSerialization());
    }
}
