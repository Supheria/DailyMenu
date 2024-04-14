using DailyMenu.Data.Model;
using LocalUtilities.Serializations;
using LocalUtilities.SerializeUtilities;
using LocalUtilities.StringUtilities;
using System.Xml.Serialization;

namespace DailyMenu.IO.Data;
public class MenuItemXmlSerialization : KeyValuePairXmlSerialization<string, uint>
{
    public MenuItemXmlSerialization() :
        base(nameof(Recipe), nameof(Recipe.Signature), "Copies",
        key => key ?? "", value => value.ToUint() ?? 0,
        key => key, value => value.ToString())  
    {
    }
}
