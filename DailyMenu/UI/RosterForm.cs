using DailyMenu.IO.UI;
using DailyMenu.UI.IO;
using LocalUtilities.UIUtilities;

namespace DailyMenu.UI;

public abstract class RosterForm : ResizeableForm
{
    protected RosterForm(string iniFileName) : base(iniFileName)
    {
        BackColor = Color.White;
        FormDataXmlSerialization = new RosterFormDataSerialization();
        OnLoadFormData += RosterForm_LoadIniData;
        OnSaveFormData += RosterForm_SaveIniData;
        Load += RosterForm_Load;
    }

    private void RosterForm_LoadIniData(FormData formData)
    {
        var data = formData as RosterFormData;
        if (data is not null)
            BackColor = data.BackColor;
    }

    private FormData RosterForm_SaveIniData()
    {
        return new RosterFormData
        {
            BackColor = BackColor,
        };
    }

    private void RosterForm_Load(object? sender, EventArgs e) => UpdateAllData();

    protected abstract void UpdateAllData();
}
