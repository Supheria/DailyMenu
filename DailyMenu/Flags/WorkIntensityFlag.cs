using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyMenu.Flags;

public enum WorkIntensityFlag
{
    None,
    [Description("极轻")]
    Weak,
    [Description("轻度")]
    Low,
    [Description("中度")]
    Medium,
    [Description("重度")]
    High,
}
