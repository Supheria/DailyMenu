using DailyMenu.Data.Model;
using LocalUtilities.Serializations;
using LocalUtilities.SerializeUtilities;
using System.Xml.Serialization;

namespace DailyMenu.IO.Data;

public class FoodExchangesXmlSerialization() : RosterXmlSerialization<FoodExchanges, string, FoodExchange>(new(), new FoodExchangeXmlSerialization())
{
    public override string LocalName => nameof(FoodExchanges);
}
