using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyMenu.IO.UI;

public class MainFormData : RosterFormData
{
    public override Size MinimumSize { get; set; } = new(800, (int)(800 * 0.618f));

    public MainFormData()
    {
        Location = Screen.PrimaryScreen is null
        ? new()
        : new(
            (Screen.PrimaryScreen.Bounds.Width / 2) - (Size.Width / 2),
            (Screen.PrimaryScreen.Bounds.Height / 2) - (Size.Height / 2)
            );
    }
}
