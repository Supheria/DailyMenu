using DailyMenu.Data.Model;
using DailyMenu.IO.Data;
using LocalUtilities.FileUtilities;

namespace DailyMenu.Data;

public static class FoodRoster
{
    /// <summary>
    /// 全局食物名册
    /// </summary>
    public static Foods Roster { get; private set; } = new();
    /// <summary>
    /// 名册文件路径
    /// </summary>
    public static string FilePath { get; private set; } = "./food.xml";
    /// <summary>
    /// 从文件加载名册
    /// </summary>
    /// <param name="filePath"></param>
    public static void Load()
    {
        _ = new FoodsXmlSerialization().LoadFromXml(FilePath, out var roster);
        Roster = roster ?? Roster;
    }
    /// <summary>
    /// 保存当前名册
    /// </summary>
    public static void Save() => Roster.SaveToXml(Path.ChangeExtension(FilePath, ".xml"), new FoodsXmlSerialization());
}
