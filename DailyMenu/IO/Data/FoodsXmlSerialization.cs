using DailyMenu.Data.Model;
using LocalUtilities.SerializeUtilities;
using System.Xml;
using System.Xml.Serialization;

namespace DailyMenu.IO.Data;

[XmlRoot(nameof(Foods))]
public class FoodsXmlSerialization : RosterXmlSerialization<Foods, Food>
{
    public FoodsXmlSerialization() : base(nameof(Foods), new FoodXmlSerialization(), new())
    {

    }
}
