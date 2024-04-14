using DailyMenu.Data.Model;
using LocalUtilities.Serializations;
using LocalUtilities.SerializeUtilities;
using System.Xml.Serialization;

namespace DailyMenu.IO.Data;

public class FoodsXmlSerialization() : RosterXmlSerialization<Foods, string, Food>(new(), new FoodXmlSerialization())
{
    public override string LocalName => nameof(Food);
}
