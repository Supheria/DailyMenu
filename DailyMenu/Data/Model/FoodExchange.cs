using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyMenu.Data.Model;

public class FoodExchange(string category, int mass, float protein, float fat, float carbo)
{
    /// <summary>
    /// 食物类型
    /// </summary>
    public string Category { get; } = category;
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
