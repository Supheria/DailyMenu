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
        public Members()
        {
            _memberMap = new()
            {
                //["AAA"] = new()
                //{
                //    Name = "AAA",
                //    Height = 1.82f,
                //    Weight = 63f,
                //    WorkIntensity = Flags.WorkIntensityFlag.Weak,
                //},

            };
        }
        public Members(Member[] members) : this()
        {
            foreach(var m in members)
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
    }
}
