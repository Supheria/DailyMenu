using LocalUtilities.Interface;

namespace DailyMenu.Data.Model;

public class Food(string signature) : RosterItem<string>(signature)
{
    /// <summary>
    /// 食物类型
    /// </summary>
    public string Category { get; set; } = "";

    public Food() : this("")
    {

    }
    /// <summary>
    /// 一定重量食物的营养素含量
    /// </summary>
    /// <param name="weight"></param>
    /// <returns></returns>
    public Nutrient? GetContent(float weight)
    {
        var exchange = Rosters.FoodExchanges[Category];
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
