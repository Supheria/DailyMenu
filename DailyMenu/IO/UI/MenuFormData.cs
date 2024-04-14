using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyMenu.IO.UI;

public class MenuFormData : RosterFormData
{
    public override Size MinimumSize { get; set; } = new(500, (int)(500 * 0.618f));

    public MenuFormData()
    {
        Location = Screen.PrimaryScreen is null
        ? new()
        : new(
            (Screen.PrimaryScreen.Bounds.Width / 2) - (Size.Width / 2),
            (Screen.PrimaryScreen.Bounds.Height / 2) - (Size.Height / 2)
            );
    }
}
