using DailyMenu.Data.IO;
using DailyMenu.Data.Model;
using DailyMenu.IO.Data;
using LocalUtilities.FileUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyMenu.Data;

public static class FoodExchangeRoster
{
    /// <summary>
    /// 全局成员名册
    /// </summary>
    public static FoodExchanges Roster { get; private set; } = new();
    /// <summary>
    /// 名册文件路径
    /// </summary>
    public static string FilePath { get; private set; } = "./food exchange.xml";
    /// <summary>
    /// 从文件加载名册
    /// </summary>
    /// <param name="filePath"></param>
    public static void Load()
    {
        _ = new FoodExchangesXmlSerialization().LoadFromXml(FilePath, out var roster);
        Roster = roster ?? Roster;
    }
    /// <summary>
    /// 保存当前名册
    /// </summary>
    public static void Save() => Roster.SaveToXml(Path.ChangeExtension(FilePath, ".xml"), new FoodExchangesXmlSerialization());
}
