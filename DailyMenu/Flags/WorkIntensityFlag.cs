using System.ComponentModel;

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
