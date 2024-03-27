using DailyMenu.Flags;

namespace DailyMenu.Data.Model;

public class Member(string name,float height, float weight, WorkIntensityFlag workIntensity)
{
    /// <summary>
    /// 名字
    /// </summary>
    public string Name { get; } = name;
    /// <summary>
    /// 身高(m)
    /// </summary>
    public float Height { get; } = height;
    /// <summary>
    /// 体重(kg)
    /// </summary>
    public float Weight { get; } = weight;
    /// <summary>
    /// 劳动强度
    /// </summary>
    public WorkIntensityFlag WorkIntensity { get; } = workIntensity;
    /// <summary>
    /// Bmi指标
    /// </summary>
    public BmiFlag Bmi
    {
        get
        {
            var bmi = _bmi;
            if (bmi is 0)
                return BmiFlag.None;
            if (bmi < 18.5f)
                return BmiFlag.Thin;
            if (bmi < 23.9f)
                return BmiFlag.Common;
            if (bmi < 27.9f)
                return BmiFlag.Overweight;
            return BmiFlag.Fat;
        }
    }
    /// <summary>
    /// Bmi值
    /// </summary>
    private float _bmi => Height is 0f ? 0f : Weight / (Height * Height);
    /// <summary>
    /// 每日所需能量
    /// </summary>
    /// <returns></returns>
    public float DailyEnergy()
    {
        int standardUnitEnergy = 0;
        switch (WorkIntensity)
        {
            case WorkIntensityFlag.Weak:
                standardUnitEnergy = StandardUnitEnergy(15);
                break;
            case WorkIntensityFlag.Low:
                standardUnitEnergy = StandardUnitEnergy(25);
                break;
            case WorkIntensityFlag.Medium:
                standardUnitEnergy = StandardUnitEnergy(30);
                break;
            case WorkIntensityFlag.High:
                standardUnitEnergy = StandardUnitEnergy(35);
                break;
        }
        return (Height * 100 - 105) * standardUnitEnergy;
    }
    /// <summary>
    /// 单位标准体重能量供给量
    /// </summary>
    private int StandardUnitEnergy(int basicValue)
    {
        switch (Bmi)
        {
            case BmiFlag.Thin:
                return basicValue + 15;
            case BmiFlag.Common:
                return basicValue + 10;
            case BmiFlag.Overweight:
                return basicValue + 5;
            case BmiFlag.Fat:
                return basicValue;
            default:
                return 0;
        }
    }
}
