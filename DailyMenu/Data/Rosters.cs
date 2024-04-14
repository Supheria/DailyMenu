using DailyMenu.Data.IO;
using DailyMenu.Data.Model;
using DailyMenu.IO.Data;
using LocalUtilities.FileUtilities;
using LocalUtilities.Interface;
using LocalUtilities.Serializations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyMenu.Data;

public static class Rosters
{
    /// <summary>
    /// 全局食物交换份名册
    /// </summary>
    public static FoodExchanges FoodExchanges { get; set; } = new FoodExchangesXmlSerialization().LoadFromXml(out _);
    /// <summary>
    /// 全局食物名册
    /// </summary>
    public static Foods Foods { get; set; } = new FoodsXmlSerialization().LoadFromXml(out _);
    /// <summary>
    /// 全局成员名册
    /// </summary>
    public static Members Members { get; set; } = new MembersXmlSerialization().LoadFromXml(out _);
    /// <summary>
    /// 全局菜谱名册
    /// </summary>
    public static Recipes Recipes { get; set; } = new RecipesXmlSerialization().LoadFromXml(out _);
    /// <summary>
    /// 全局菜单名册
    /// </summary>
    public static Menu Menu { get; set; } = new MenuXmlSerialization().LoadFromXml(out _);
}
