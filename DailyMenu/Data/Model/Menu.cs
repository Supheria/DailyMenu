using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyMenu.Data.Model;

public class Menu(string date, Dictionary<string, uint> menu)
{
    string _date = date;

    public string Date => _date;

    Dictionary<string, uint> _menu = menu;

    public KeyValuePair<string, uint>[] MenuList => _menu.ToArray();

    public uint this[string recipeTitle]
    {
        get
        {
            uint copies = _menu.TryGetValue(recipeTitle, out var c) ? c : 0;
            return copies;
        }
        set => _menu[recipeTitle] = value;
    }
}
