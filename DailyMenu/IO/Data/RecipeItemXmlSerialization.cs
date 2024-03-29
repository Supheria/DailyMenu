using DailyMenu.Data.Model;
using LocalUtilities.SerializeUtilities;
using LocalUtilities.StringUtilities;
using System.Xml.Serialization;

namespace DailyMenu.IO.Data;

[XmlRoot(nameof(Food))]
public class RecipeItemXmlSerialization : KeyValuePairXmlSerialization<string, float>
{
    public RecipeItemXmlSerialization() :
        base(nameof(Food), nameof(Food.Name), "Copies",
        key => key ?? "", value => value.ToFloat() ?? 0,
        key => key, value => value.ToString())
    {
    }
}
