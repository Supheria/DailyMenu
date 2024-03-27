using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyMenu.IO.UI;

public class MemberFormData
{
    public Size Size { get; set; }

    public float SizeRatio { get; set; }

    public Point Location { get; set; }

    public FormWindowState WindowState { get; set; }
}
