using DailyMenu.Data.IO;
using DailyMenu.Flags;
using LocalUtilities.FileUtilities;
using LocalUtilities.Interface;
using LocalUtilities.StringUtilities;

namespace DailyMenu.Data.Model;

public class Members : Roster<Member>, IHistoryRecordable
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
    public string Percentage(Member member) => $"{this[member.Name]?.DailyEnergy() / TotalDailyEnergy * 100}%";


    public int HistoryIndex { get; set; }
    public int CurrentHistoryLength { get; set; }
    public string[] History { get; set; } = new string[20];
    public int LatestIndex { get; set; }

    public string HashCachePath => this.GetCacheFilePath("hash test");

    public string FileManageDirName => "ROSTER";

    public string ToHashString()
    {
        this.SaveToXml(HashCachePath, new MembersXmlSerialization());
        using var data = new FileStream(HashCachePath, FileMode.Open);
        var hashString = data.ToMd5HashString();
        if (!File.Exists(hashString))
            this.SaveToXml(this.GetCacheFilePath(hashString), new MembersXmlSerialization());
        return hashString;
    }

    public string ToHashString(string filePath)
    {
        new MembersXmlSerialization().LoadFromXml(filePath)
            ?.SaveToXml(HashCachePath, new MembersXmlSerialization());
        using var data = new FileStream(HashCachePath, FileMode.Open);
        return data.ToMd5HashString();
    }

    public void FromHashString(string data) =>
        SetRoster(new MembersXmlSerialization().LoadFromXml(this.GetCacheFilePath(data))?.RosterList ?? []);
}
