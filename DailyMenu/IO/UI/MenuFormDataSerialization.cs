using DailyMenu.Data.Model;
using DailyMenu.UI;
using DailyMenu.UI.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyMenu.IO.UI;

public class MenuFormDataSerialization() : RosterFormDataSerialization<MenuFormData>(nameof(MenuForm), new())
{
}
