using DailyMenu.IO.Data;
using LocalUtilities.FileUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyMenu.Data.Model;

public class Food(string name, string category)
{
    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; } = name;
    /// <summary>
    /// 食物类型
    /// </summary>
    public string Category { get; } = category;

    /// <summary>
    /// 一定重量食物的营养素含量
    /// </summary>
    /// <param name="weight"></param>
    /// <returns></returns>
    public Nutrient? GetContent(int weight)
    {
        var exchange = FoodExchangeRoster.Roster[Category];
        if (exchange is null)
            return null;
        var copies = weight / (exchange.Mass is 0 ? 1 : exchange.Mass);
        return new(
            exchange.Energy * copies,
            exchange.Protein * copies,
            exchange.Fat * copies,
            exchange.Carbo * copies
            );
    }
}
