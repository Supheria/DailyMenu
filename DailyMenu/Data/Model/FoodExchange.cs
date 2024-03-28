using LocalUtilities.Interface;
using System.Xml.Linq;

namespace DailyMenu.Data.Model;

public class FoodExchange(string category, int mass, float protein, float fat, float carbo) : IRosterItem
{

    public string Name => _category;

    string _category = category;
    /// <summary>
    /// 食物类型
    /// </summary>
    public string Category => _category;
    /// <summary>
    /// 每交换份质量
    /// </summary>
    public int Mass { get; } = mass;
    /// <summary>
    /// 每交换份能量
    /// </summary>
    public int Energy { get; } = 90;
    /// <summary>
    /// 蛋白质
    /// </summary>
    public float Protein { get; } = protein;
    /// <summary>
    /// 脂肪
    /// </summary>
    public float Fat { get; } = fat;
    /// <summary>
    /// 碳水
    /// </summary>
    public float Carbo { get; } = carbo;
}
