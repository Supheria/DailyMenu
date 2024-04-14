using DailyMenu.Data.IO;
using LocalUtilities.FileUtilities;
using LocalUtilities.Interface;
using LocalUtilities.StringUtilities;

namespace DailyMenu.Data.Model;

public class Members() : Roster<string, Member>(), IHistoryRecordable
{
    /// <summary>
    /// 每日所需总能量
    /// </summary>
    public float TotalDailyEnergy
    {
        get
        {
            float totalDailyEnergy = 0f;
            foreach (var m in RosterList)
            {
                totalDailyEnergy += m.DailyEnergy();
            }
            return totalDailyEnergy;
        }
    }
    /// <summary>
    /// 个人能量占比
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public string Percentage(Member member) => $"{this[member.Signature]?.DailyEnergy() / TotalDailyEnergy * 100}%";


    public int CurrentHistoryIndex { get; set; }
    public int CurrentHistoryLength { get; set; }
    public string[] HistoryCache { get; set; } = new string[20];
    public int LastSavedIndex { get; set; }

    public string HashCachePath => this.GetCacheFilePath("hash test");

    public string FileManageDirName => "MEMBERS";

    public string ToHashString()
    {
        new MembersXmlSerialization() { Source = this }.SaveToXml(HashCachePath);
        using var data = new FileStream(HashCachePath, FileMode.Open);
        var hashString = data.ToMd5HashString();
        if (!File.Exists(hashString))
            new MembersXmlSerialization() { Source = this }.SaveToXml(this.GetCacheFilePath(hashString));
        return new(hashString);
    }

    public string ToHashString(string filePath)
    {
        var members = new MembersXmlSerialization().LoadFromXml(out _, filePath);
        new MembersXmlSerialization() { Source = members }.SaveToXml(HashCachePath);
        using var data = new FileStream(HashCachePath, FileMode.Open);
        return data.ToMd5HashString();
    }

    public void FromHashString(string data)
    {
        RosterList = new MembersXmlSerialization().LoadFromXml(
                out _, this.GetCacheFilePath(data)
                )?.RosterList
                ?? [];
    }
}
