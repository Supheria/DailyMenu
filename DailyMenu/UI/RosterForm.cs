using DailyMenu.IO.UI;
using DailyMenu.UI.IO;
using LocalUtilities.UIUtilities;

namespace DailyMenu.UI;

public abstract class RosterForm<TRosterFormData> : ResizeableForm<TRosterFormData> where TRosterFormData : RosterFormData
{
    protected RosterForm(TRosterFormData rosterFormData, RosterFormDataSerialization<TRosterFormData> rosterFormDataSerialization) : base(rosterFormData, rosterFormDataSerialization)
    {
        OnLoadFormData += RosterForm_LoadIniData;
        OnSaveFormData += RosterForm_SaveIniData;
        Load += RosterForm_Load;
    }

    private void RosterForm_LoadIniData()
    {
        BackColor = FormData.BackColor;
    }

    private void RosterForm_SaveIniData()
    {
        FormData.BackColor = BackColor;
    }

    private void RosterForm_Load(object? sender, EventArgs e) => UpdateAllData();

    protected abstract void UpdateAllData();
}
