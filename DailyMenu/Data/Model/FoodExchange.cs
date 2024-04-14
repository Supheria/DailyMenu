using LocalUtilities.Interface;

namespace DailyMenu.Data.Model;

public class FoodExchange(string signature) : RosterItem<string>(signature)
{
    /// <summary>
    /// 每交换份质量
    /// </summary>
    public uint Mass { get; set; }
    /// <summary>
    /// 每交换份能量
    /// </summary>
    public uint Energy { get; } = 90;
    /// <summary>
    /// 蛋白质
    /// </summary>
    public float Protein { get; set; }
    /// <summary>
    /// 脂肪
    /// </summary>
    public float Fat { get; set; }
    /// <summary>
    /// 碳水
    /// </summary>
    public float Carbo { get; set; }

    public FoodExchange() : this("")
    {

    }
}
