using System;
using System.Collections.Generic;
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
        public Member[] MemberMap => _memberMap.Values.ToArray();
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
    }
}
