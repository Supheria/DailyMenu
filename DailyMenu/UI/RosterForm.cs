using DailyMenu.UI.IO;
using LocalUtilities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocalUtilities.FileUtilities;
using DailyMenu.IO.UI;

namespace DailyMenu.UI;

public abstract class RosterForm : ResizeableForm, IInitializationManageable
{
    string _iniFileName { get; }

    public string IniFileName => _iniFileName;

    protected RosterForm(string iniFileName)
    {
        _iniFileName = iniFileName;

        Load += RosterForm_Load;
        FormClosing += RosterForm_FormClosing;

        BackColor = Color.White;
        InitializeComponent();
    }

    protected abstract void InitializeComponent();

    private void RosterForm_Load(object? sender, EventArgs e)
    {
        _ = new RosterFormDataSerialization().LoadFromXml(this.GetInitializationFilePath(), out var formData);
        if (formData is not null)
        {
            Size = formData.Size;
            Location = formData.Location;
            WindowState = formData.WindowState;
        }
        else
        {
            Location = new(
                    (Screen.GetBounds(this).Width / 2) - (this.Width / 2),
                    (Screen.GetBounds(this).Height / 2) - (base.Height / 2)
                    );
            WindowState = FormWindowState.Normal;
        }
        UpdateAllData();
        DrawClient();
    }

    private void RosterForm_FormClosing(object? sender, FormClosingEventArgs e)
    {
        new RosterFormData()
        {
            Size = Size,
            Location = Location,
            WindowState = WindowState,
        }.SaveToXml(this.GetInitializationFilePath(), new RosterFormDataSerialization());
    }

    protected abstract void UpdateAllData();
}
