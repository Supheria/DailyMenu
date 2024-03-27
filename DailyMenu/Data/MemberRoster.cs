using DailyMenu.Data.IO;
using DailyMenu.Data.Model;
using LocalUtilities.FileUtilities;

namespace DailyMenu.Data;

public static class MemberRoster
{
    /// <summary>
    /// 全局成员名册
    /// </summary>
    public static Members Roster { get; private set; } = new();
    /// <summary>
    /// 名册文件路径
    /// </summary>
    public static string FilePath { get; private set; } = "./member.xml";
    /// <summary>
    /// 从文件加载名册
    /// </summary>
    /// <param name="filePath"></param>
    public static void Load()
    {
        Roster.ClearCache();
        _ = new MembersXmlSerialization().LoadFromXml(FilePath, out var roster);
        Roster = roster ?? Roster;
        Roster.NewHistory();
    }
    /// <summary>
    /// 保存当前名册
    /// </summary>
    public static void Save()
    {
        Roster.SaveToXml(Path.ChangeExtension(FilePath, ".xml"), new MembersXmlSerialization());
        Roster.UpdateLatest();
    }
}
