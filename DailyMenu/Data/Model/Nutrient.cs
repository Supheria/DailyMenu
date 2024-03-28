namespace DailyMenu.Data.Model;

public class Nutrient(int energy, float protein, float fat, float carbo)
{
    /// <summary>
    /// 能量
    /// </summary>
    public int Energy { get; } = energy;
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
