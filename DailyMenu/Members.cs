using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyMenu
{
    public class Members
    {
        /// <summary>
        /// 以 Name 作为 Key 的所有成员
        /// </summary>
        private Dictionary<string, Member> _memberMap { get; set; } = new();
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

        public Members()
        {
            _memberMap = new()
            {
                ["AAA"] = new Member("AAA", 1.82f, 63f, Flags.WorkIntensityFlag.Weak),
                ["BBB"] = new Member("BBB", 1.86f, 90f, Flags.WorkIntensityFlag.Weak),
                ["CCC"] = new Member("CCC", 1.68f, 60f, Flags.WorkIntensityFlag.Weak),

            };
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
            float totalDailyEnergy = 0f;
            foreach (var m in MemberList)
            {
                totalDailyEnergy += m.DailyEnergy();
            }
            return $"{_memberMap[member.Name].DailyEnergy() / totalDailyEnergy * 100}%";
        }
    }
}
