using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyMenu.Data.Model;

public class FoodExchanges
{
    private Dictionary<string, FoodExchange> _exchangeMap;

    public FoodExchange[] ExchangeList => _exchangeMap.Values.ToArray();

    public FoodExchange? this[string category]
    {
        get => _exchangeMap.ContainsKey(category) ? _exchangeMap[category] : null;
        set
        {
            if (category is "")
                return;
            _exchangeMap[category] = value ?? new("", 0, 0f, 0f, 0f);
        }
    }

    public FoodExchanges() => _exchangeMap = [];

    public FoodExchanges(FoodExchange[] exchanges) : this()
    {
        foreach (var e in exchanges)
            _exchangeMap[e.Category] = e;
    }
}
