namespace DailyMenu.Data.Model;

public class Nutrient(float energy, float protein, float fat, float carbo)
{
    /// <summary>
    /// 能量
    /// </summary>
    public float Energy { get; } = energy;
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

    public static Nutrient operator *(Nutrient n, uint copies) =>
        new(n.Energy * copies, n.Protein * copies, n.Fat * copies, n.Carbo * copies);

    public static Nutrient operator +(Nutrient n1, Nutrient n2) =>
        new(n1.Energy + n2.Energy, n1.Protein + n2.Protein, n1.Fat + n2.Fat, n1.Carbo + n2.Carbo);
}
