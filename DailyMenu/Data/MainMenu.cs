using DailyMenu.Data.Model;
using DailyMenu.IO.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocalUtilities.FileUtilities;

namespace DailyMenu.Data;

public static class MainMenu
{
    /// <summary>
    /// 全局菜单名册
    /// </summary>
    public static Menu Menu { get; private set; } = new("", []);
    /// <summary>
    /// 名册文件路径
    /// </summary>
    public static string FilePath { get; private set; } = "./menu.xml";
    /// <summary>
    /// 从文件加载名册
    /// </summary>
    /// <param name="filePath"></param>
    public static void Load()
    {
        _ = new MenuXmlSerialization().LoadFromXml(FilePath, out var menu);
        Menu = menu ?? Menu;
    }
    /// <summary>
    /// 保存当前名册
    /// </summary>
    public static void Save() => Menu.SaveToXml(FilePath, new MenuXmlSerialization());
}
