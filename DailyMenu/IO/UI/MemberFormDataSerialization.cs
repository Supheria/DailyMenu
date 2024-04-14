using DailyMenu.UI;
using DailyMenu.UI.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyMenu.IO.UI;

public class MemberFormDataSerialization() : RosterFormDataSerialization<MemberFormData>(nameof(MemberForm), new())
{
}
