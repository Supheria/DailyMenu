using DailyMenu.Data.Model;
using LocalUtilities.SerializeUtilities;
using System.Xml;
using System.Xml.Serialization;

namespace DailyMenu.IO.Data;

[XmlRoot(nameof(FoodExchanges))]
public class FoodExchangesXmlSerialization : RosterXmlSerialization<FoodExchanges, FoodExchange>
{
    public FoodExchangesXmlSerialization() : base(nameof(FoodExchanges), new FoodExchangeXmlSerialization(), new())
    {

    }
}
