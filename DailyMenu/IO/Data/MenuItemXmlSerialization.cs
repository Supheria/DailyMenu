using DailyMenu.Data.Model;
using LocalUtilities.SerializeUtilities;
using LocalUtilities.StringUtilities;
using System.Xml.Serialization;

namespace DailyMenu.IO.Data;

[XmlRoot(nameof(Recipe))]
public class MenuItemXmlSerialization : KeyValuePairXmlSerialization<string, uint>
{
    public MenuItemXmlSerialization() :
        base(nameof(Recipe), nameof(Recipe.Title), "Copies",
        key => key ?? "", value => value.ToUint() ?? 0,
        key => key, value => value.ToString())
    {
    }
}
