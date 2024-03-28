using DailyMenu.Data.Model;
using DailyMenu.IO.Data;
using DailyMenu.UI;
using LocalUtilities.FileUtilities;

namespace DailyMenu;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        //Test();
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }

    static void Test()
    {
        var r = new Recipe("test", new() { ["a"] = 1, ["b"] = 2 });
        r.SaveToXml("test.xml", new RecipeXmlSerialization());
        var r2 = new RecipeXmlSerialization().LoadFromXml("test.xml");
        var a = r2.Title;
    }
}