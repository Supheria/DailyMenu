using LocalUtilities.SerializeUtilities;
using LocalUtilities.StringUtilities;
using System.Xml.Serialization;

namespace DailyMenu.IO.Data;

[XmlRoot("Food")]
public class RecipeItemXmlSerialization : KeyValuePairXmlSerialization<string, uint>
{
    public RecipeItemXmlSerialization() :
        base("Food", "Name", "Copies",
        key => key ?? "", value => value.ToUint() ?? 0,
        key => key, value => value.ToString())
    {
    }
}
