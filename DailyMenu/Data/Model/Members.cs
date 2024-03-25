using DailyMenu.IO.Xml;
using LocalUtilities.ManageUtilities;
using LocalUtilities.SerializeUtilities;
using LocalUtilities.StringUtilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DailyMenu.Data.Model
{
    public class Members : IHistoryRecordable, IFileBackupManageable
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
        public Member this[string name]
        {
            get => _memberMap[name];
            set => _memberMap[name] = value;
        }
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
        public Members() => _memberMap = new();

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
        public FormattedData[] History { get; set; } = new FormattedData[20];
        public int LatestIndex { get; set; }

        public FormattedData ToFormattedData()
        {
            var hashString = this.GetHashString();
            if (!Directory.Exists(hashString))
                this.SaveToXml(this.GetCachePath(hashString), new MembersXmlSerialization());
            return new(hashString);
        }

        public void FromFormattedData(FormattedData data) => _memberMap =
            new MembersXmlSerialization().LoadFromXml(this.GetCachePath(data.Items[0]))?._memberMap ?? new();

        public string FileManageDirName => $"ROSTER";

        private string CachePath => this.GetCachePath("hash test");

        public string GetHashString()
        {
            this.SaveToXml(CachePath, new MembersXmlSerialization());
            using var data = new FileStream(CachePath, FileMode.Open);
            return data.ToMd5HashString();
        }

        public string GetHashStringFromFilePath(string filePath)
        {
            new MembersXmlSerialization().LoadFromXml(filePath)
                ?.SaveToXml(CachePath, new MembersXmlSerialization());
            using var data = new FileStream(CachePath, FileMode.Open);
            return data.ToMd5HashString();
        }
    }
}
