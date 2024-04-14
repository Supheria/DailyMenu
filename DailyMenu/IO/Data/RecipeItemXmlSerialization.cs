using DailyMenu.Data.Model;
using LocalUtilities.Serializations;
using LocalUtilities.SerializeUtilities;
using LocalUtilities.StringUtilities;
using System.Xml.Serialization;

namespace DailyMenu.IO.Data;
public class RecipeItemXmlSerialization : KeyValuePairXmlSerialization<string, float>
{
    public RecipeItemXmlSerialization() :
        base(nameof(Food), nameof(Food.Signature), "Copies",
        key => key ?? "", value => value.ToFloat() ?? 0,
        key => key, value => value.ToString())
    {
    }
}
