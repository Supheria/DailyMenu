using DailyMenu.Data.Model;
using DailyMenu.IO.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocalUtilities.FileUtilities;

namespace DailyMenu.Data;

public static class RecipeRoster
{
    /// <summary>
    /// 全局菜谱名册
    /// </summary>
    public static Recipes Roster { get; private set; } = new();
    /// <summary>
    /// 名册文件路径
    /// </summary>
    public static string FilePath { get; private set; } = "./recipe.xml";
    /// <summary>
    /// 从文件加载名册
    /// </summary>
    /// <param name="filePath"></param>
    public static void Load()
    {
        _ = new RecipesXmlSerialization().LoadFromXml(FilePath, out var roster);
        Roster = roster ?? Roster;
    }
    /// <summary>
    /// 保存当前名册
    /// </summary>
    public static void Save() => Roster.SaveToXml(FilePath, new RecipesXmlSerialization());
}
