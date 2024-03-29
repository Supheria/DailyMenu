using LocalUtilities.Interface;

namespace DailyMenu.Data.Model;

public class Food(string name, string category) : IRosterItem
{
    string _name = name;

    public string Name => _name;
    /// <summary>
    /// 食物类型
    /// </summary>
    public string Category { get; } = category;

    /// <summary>
    /// 一定重量食物的营养素含量
    /// </summary>
    /// <param name="weight"></param>
    /// <returns></returns>
    public Nutrient? GetContent(float weight)
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
