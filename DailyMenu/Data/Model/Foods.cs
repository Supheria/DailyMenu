using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyMenu.Data.Model;

public class Foods
{
    private Dictionary<string, Food> _foodMap;

    public Food[] ExchangeList => _foodMap.Values.ToArray();

    public Food? this[string name]
    {
        get => _foodMap.ContainsKey(name) ? _foodMap[name] : null;
        set
        {
            if (name is "")
                return;
            _foodMap[name] = value ?? new("", "");
        }
    }

    public Foods() => _foodMap = [];

    public Foods(Food[] food) : this()
    {
        foreach (var f in food)
            _foodMap[f.Name] = f;
    }
}
