using DailyMenu.Data.IO;
using LocalUtilities.Interface;
using LocalUtilities.FileUtilities;
using LocalUtilities.StringUtilities;
using DailyMenu.Flags;

namespace DailyMenu.Data.Model;

public class Members : IHistoryRecordable
{
    /// <summary>
    /// 以 Name 作为 Key 的所有成员
    /// </summary>
    private Dictionary<string, Member> _memberMap;
    /// <summary>
    /// 成员列表
    /// </summary>
    public Member[] MemberList => _memberMap.Values.ToArray();
    /// <summary>
    /// 通过 Name 获取或修改成员 
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public Member? this[string name]
    {
        get => _memberMap.ContainsKey(name) ? _memberMap[name] : null;
        set
        {
            if (name is "")
                return;
            _memberMap[name] = value ?? new("", 0f, 0f, WorkIntensityFlag.None);
        }
    }
    public void Remove(string name) => _memberMap.Remove(name);
    /// <summary>
    /// 每日所需总能量
    /// </summary>
    public float TotalDailyEnergy
    {
        get
        {
            float totalDailyEnergy = 0f;
            foreach (var m in MemberList)
            {
                totalDailyEnergy += m.DailyEnergy();
            }
            return totalDailyEnergy;
        }
    }
    public Members() => _memberMap = [];

    public Members(Member[] members) : this()
    {
        foreach (var m in members)
            _memberMap[m.Name] = m;
    }
    /// <summary>
    /// 个人能量占比
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public string Percentage(Member member)
    {
        if (!_memberMap.ContainsKey(member.Name))
            return "NAME_NOT_FOUND";

        return $"{_memberMap[member.Name].DailyEnergy() / TotalDailyEnergy * 100}%";
    }


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

    public void FromHashString(string data) => _memberMap =
        new MembersXmlSerialization().LoadFromXml(this.GetCacheFilePath(data))?._memberMap ?? [];
}
