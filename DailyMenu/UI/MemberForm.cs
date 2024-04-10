using DailyMenu.Data;
using DailyMenu.Data.Model;
using DailyMenu.Flags;
using LocalUtilities.FileUtilities;
using LocalUtilities.StringUtilities;

namespace DailyMenu.UI;

public partial class MemberForm : RosterForm
{

    private bool _isEditing = false;

    #region ==== Main Events ====

    public MemberForm() : base("member form")
    {
        FormClosing += MemberForm_FormClosing;
    }

    private void MemberForm_FormClosing(object? sender, FormClosingEventArgs e)
    {
        if (MemberRoster.Roster.IsEdit() is false)
        {
            MemberRoster.Roster.ClearCache();
        }
        else
        {
            var result = MessageBox.Show("是否保存当前编辑？", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.Cancel:
                    e.Cancel = true;
                    return;
                case DialogResult.Yes:
                    MemberRoster.Save();
                    break;
            }
        }
    }

    private void UpdateMemberList()
    {
        this.MemberList.BeginUpdate();

        MemberList.Items.Clear();
        foreach (var m in MemberRoster.Roster.RosterList)
        {
            var item = new ListViewItem();
            item.Text = m.Name;
            item.SubItems.Add(m.Height.ToString());
            item.SubItems.Add(m.Weight.ToString());
            item.SubItems.Add(m.WorkIntensity.ToDescription());

            this.MemberList.Items.Add(item);
        }
        this.MemberList.EndUpdate();

        Invalidate();
    }

    #endregion


    #region ==== Draw Client ====

    protected override void DrawClient()
    {
        if (WindowState == FormWindowState.Minimized)
        {
            return;
        }
        SuspendLayout();
        const int padding = 10;
        var labelWidth = (int)((ClientRectangle.Width - 6 * padding) * 0.25f);
        var labelHeight = (int)(ClientRectangle.Height * 0.075f);
        var labelFont = new Font("黑体", base.Height * 0.05f, FontStyle.Regular, GraphicsUnit.Pixel);
        var editFont = new Font("仿宋", base.Height * 0.075f, FontStyle.Regular, GraphicsUnit.Pixel);
        //
        // NameLabel
        //
        NameLabel.Left = ClientRectangle.Left + padding;
        NameLabel.Top = ClientRectangle.Top + padding;
        NameLabel.Width = labelWidth;
        NameLabel.Height = labelHeight;
        NameLabel.Font = labelFont;
        NameLabel.TextAlign = ContentAlignment.MiddleLeft;
        //
        // Title
        //
        Name.Left = NameLabel.Left + padding;
        Name.Top = NameLabel.Bottom + padding;
        Name.Width = labelWidth;
        Name.Font = editFont;
        Name.TextAlign = HorizontalAlignment.Left;
        //
        // HeightLabel
        //
        HeightLabel.Left = NameLabel.Right + padding;
        HeightLabel.Top = ClientRectangle.Top + padding;
        HeightLabel.Width = labelWidth;
        HeightLabel.Height = labelHeight;
        HeightLabel.Font = labelFont;
        HeightLabel.TextAlign = ContentAlignment.MiddleLeft;
        //
        //
        // Height
        //
        Height.Left = HeightLabel.Left + padding;
        Height.Top = HeightLabel.Bottom + padding;
        Height.Width = labelWidth;
        Height.Font = editFont;
        Height.TextAlign = HorizontalAlignment.Left;
        //
        // WeightLabel
        //
        WeightLabel.Left = HeightLabel.Right + padding;
        WeightLabel.Top = ClientRectangle.Top + padding;
        WeightLabel.Width = labelWidth;
        WeightLabel.Height = labelHeight;
        WeightLabel.Font = labelFont;
        WeightLabel.TextAlign = ContentAlignment.MiddleLeft;
        //
        //
        // Weight
        //
        Weight.Left = WeightLabel.Left + padding;
        Weight.Top = WeightLabel.Bottom + padding;
        Weight.Width = labelWidth;
        Weight.Font = editFont;
        Weight.TextAlign = HorizontalAlignment.Left;
        //
        // WorkIntensityLabel
        //
        WorkIntensityLabel.Left = WeightLabel.Right + padding;
        WorkIntensityLabel.Top = ClientRectangle.Top + padding;
        WorkIntensityLabel.Width = labelWidth;
        WorkIntensityLabel.Height = labelHeight;
        WorkIntensityLabel.Font = labelFont;
        WorkIntensityLabel.TextAlign = ContentAlignment.MiddleLeft;
        //
        //
        // WorkIntensity
        //
        WorkIntensity.Left = WorkIntensityLabel.Left + padding;
        WorkIntensity.Top = WorkIntensityLabel.Bottom + padding;
        WorkIntensity.Width = labelWidth;
        WorkIntensity.Font = editFont;
        //
        //
        //
        var buttonHeight = (int)(ClientRectangle.Height * 0.1f);
        //
        // MemberList
        //
        MemberList.Left = ClientRectangle.Left + padding;
        MemberList.Top = Name.Bottom + padding;
        MemberList.Width = ClientRectangle.Width - padding * 2;
        MemberList.Height = ClientRectangle.Bottom - Name.Bottom - padding * 4 - buttonHeight;
        MemberList.Font = new Font("宋体", base.Height * 0.05f, FontStyle.Regular, GraphicsUnit.Pixel); ;
        var columnWidth = (MemberList.Width - padding) / (MemberList.Columns.Count is 0 ? 1 : MemberList.Columns.Count);
        foreach (ColumnHeader c in MemberList.Columns)
            c.Width = columnWidth;
        //
        //
        //
        var buttonWidth = ClientRectangle.Width / 5;
        var buttonTop = MemberList.Bottom + padding;
        //
        // Delete
        //
        Delete.Left = ClientRectangle.Left + buttonWidth;
        Delete.Top = buttonTop;
        Delete.Height = buttonHeight;
        Delete.Width = buttonWidth;
        Delete.Font = labelFont;
        //
        // Save
        //
        Save.Left = Delete.Right + buttonWidth;
        Save.Top = buttonTop;
        Save.Height = buttonHeight;
        Save.Width = buttonWidth;
        Save.Font = labelFont;
        ResumeLayout();
    }

    #endregion


    #region ==== Initialize ====

    protected override void InitializeComponent()
    {
        var backColor = Color.White;
        var labelColor = Color.DarkRed;
        var editColor = Color.DarkBlue;
        var buttonColor = Color.AliceBlue;
        //
        // main
        //
        Controls.AddRange(new Control[]
        {
            NameLabel,
            HeightLabel,
            WeightLabel,
            WorkIntensityLabel,
            Name,
            Height,
            Weight,
            WorkIntensity,
            Delete,
            Save,
            MemberList,
        });
        MinimumSize = new(500, (int)(500 * 0.618f));
        //
        // NameLabel
        //
        NameLabel.Text = "名字";
        NameLabel.BackColor = backColor;
        NameLabel.ForeColor = labelColor;
        //
        // HeightLabel
        //
        HeightLabel.Text = "身高(m)";
        HeightLabel.BackColor = backColor;
        HeightLabel.ForeColor = labelColor;
        //
        // WeightLabel
        //
        WeightLabel.Text = "体重(kg)";
        WeightLabel.BackColor = backColor;
        WeightLabel.ForeColor = labelColor;
        //
        // WorkIntensityLabel
        //
        WorkIntensityLabel.Text = "劳动强度";
        WorkIntensityLabel.BackColor = backColor;
        WorkIntensityLabel.ForeColor = labelColor;
        //
        // Title
        //
        Name.Name = "Name";
        Name.TextAlign = HorizontalAlignment.Center;
        Name.BorderStyle = BorderStyle.FixedSingle;
        Name.BackColor = backColor;
        Name.ForeColor = editColor;
        Name.KeyPress += Name_KeyPress;
        Name.GotFocus += Name_GotFocus;
        Name.LostFocus += FinishEdition;
        //
        // Height
        //
        Height.Name = "Height";
        Height.TextAlign = HorizontalAlignment.Center;
        Height.BorderStyle = BorderStyle.FixedSingle;
        Height.BackColor = backColor;
        Height.ForeColor = editColor;
        Height.KeyPress += Float_KeyPress;
        Height.GotFocus += Height_GotFocus; ;
        Height.LostFocus += FinishEdition;
        //
        // Weight
        //
        Weight.Name = "Weight";
        Weight.TextAlign = HorizontalAlignment.Center;
        Weight.BorderStyle = BorderStyle.FixedSingle;
        Weight.BackColor = backColor;
        Weight.ForeColor = editColor;
        Weight.KeyPress += Float_KeyPress;
        Weight.GotFocus += Weight_GotFocus;
        Weight.LostFocus += FinishEdition;
        //
        // WorkIntensity
        //
        WorkIntensity.Name = "WorkIntensity";
        WorkIntensity.Items.AddRange(new WorkIntensityFlag().ToDescriptionList());
        WorkIntensity.SelectedIndex = 0;
        WorkIntensity.DropDownStyle = ComboBoxStyle.DropDownList;
        WorkIntensity.FlatStyle = FlatStyle.Popup;
        WorkIntensity.BackColor = backColor;
        WorkIntensity.ForeColor = editColor;
        WorkIntensity.LostFocus += FinishEdition;
        //
        // Delete
        //
        Delete.Name = "Delete";
        Delete.Text = "删除";
        Delete.BackColor = buttonColor;
        Delete.ForeColor = labelColor;
        Delete.Click += Delete_Click;
        //
        // Save
        //
        Save.Name = "Save";
        Save.Text = "保存";
        Save.BackColor = buttonColor;
        Save.ForeColor = labelColor;
        Save.Click += Save_Click;
        //
        // MemberList
        //
        MemberList.Name = "MemberList";
        MemberList.View = View.Details;
        MemberList.FullRowSelect = true;
        MemberList.Columns.AddRange(new ColumnHeader[]
        {
            NameHeader,
            HeightHeader,
            WeightHeader,
            WorkIntensityHeader,
            BmiHeader,
            DailyEnergyHeader,
        });
        MemberList.SelectedIndexChanged += MemberList_SelectedIndexChanged;
        //
        // NameHeader
        //
        NameHeader.Name = "NameHeader";
        NameHeader.Text = "名字";
        NameHeader.TextAlign = HorizontalAlignment.Left;
        //
        // HeightHeader
        //
        HeightHeader.Name = "HeightHeader";
        HeightHeader.Text = "身高(m)";
        HeightHeader.TextAlign = HorizontalAlignment.Left;
        //
        // WeightHeader
        //
        WeightHeader.Name = "WeightHeader";
        WeightHeader.Text = "体重(kg)";
        WeightHeader.TextAlign = HorizontalAlignment.Left;
        //
        // WorkIntensityHeader
        //
        WorkIntensityHeader.Name = "WorkIntensityHeader";
        WorkIntensityHeader.Text = "劳动强度";
        WorkIntensityHeader.TextAlign = HorizontalAlignment.Left;
        //
        // BmiHeader
        //
        BmiHeader.Name = "BmiHeader";
        BmiHeader.Text = "BMI";
        BmiHeader.TextAlign = HorizontalAlignment.Left;
        //
        // DailyEnergyHeader
        //
        DailyEnergyHeader.Name = "DailyEnergyHeader";
        DailyEnergyHeader.Text = "日需能量";
        DailyEnergyHeader.TextAlign = HorizontalAlignment.Left;
    }

    System.Windows.Forms.Label NameLabel = new();
    System.Windows.Forms.Label HeightLabel = new();
    System.Windows.Forms.Label WeightLabel = new();
    System.Windows.Forms.Label WorkIntensityLabel = new();
    new System.Windows.Forms.TextBox Name = new();
    new System.Windows.Forms.TextBox Height = new();
    System.Windows.Forms.TextBox Weight = new();
    System.Windows.Forms.ComboBox WorkIntensity = new();
    System.Windows.Forms.Button Delete = new();
    System.Windows.Forms.Button Save = new();
    System.Windows.Forms.ListView MemberList = new();
    System.Windows.Forms.ColumnHeader NameHeader = new();
    System.Windows.Forms.ColumnHeader HeightHeader = new();
    System.Windows.Forms.ColumnHeader WeightHeader = new();
    System.Windows.Forms.ColumnHeader WorkIntensityHeader = new();
    System.Windows.Forms.ColumnHeader BmiHeader = new();
    System.Windows.Forms.ColumnHeader DailyEnergyHeader = new();

    #endregion


    #region ==== Controls Events ====

    private void Editing(object? sender, EventArgs e)
    {

    }

    private void Float_KeyPress(object? sender, KeyPressEventArgs e)
    {
        var tb = sender as TextBox;
        if (tb is null)
            return;
        if (e.KeyChar is '.' && (tb.Text.IndexOf('.') is not -1 || tb.Text.Length is 0))
            e.Handled = true;
        if (!(e.KeyChar is '\b' || (e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar is '.'))
            e.Handled = true;
    }

    private void Save_Click(object? sender, EventArgs e)
    {
        MemberRoster.Save();
        Close();
    }

    private void Delete_Click(object? sender, EventArgs e)
    {
        MemberRoster.Roster.Remove(MemberList.SelectedItems[0].SubItems[0].Text);
        UpdateMemberList();
        MemberRoster.Roster.EnqueueHistory();
    }

    private void MemberList_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (MemberList.SelectedItems.Count is 0)
            return;
        Name.Text = MemberList.SelectedItems[0].SubItems[0].Text;
        Height.Text = MemberList.SelectedItems[0].SubItems[1].Text.ToFloat().ToString();
        Weight.Text = MemberList.SelectedItems[0].SubItems[2].Text.ToFloat().ToString();
        var flag = MemberList.SelectedItems[0].SubItems[3].Text.DescriptionToEnum<WorkIntensityFlag>();
        WorkIntensity.SelectedIndex = flag is WorkIntensityFlag.None ? 0 : (int)flag - 1;
    }

    //private void WorkIntensity_GotFocus(object? sender, EventArgs e) => _isEditing = true;

    private void Weight_GotFocus(object? sender, EventArgs e)
    {
        Weight.Text = "";
    }

    private void Height_GotFocus(object? sender, EventArgs e)
    {
        Height.Text = "";
    }

    private void Name_GotFocus(object? sender, EventArgs e)
    {
        Name.Text = Height.Text = Weight.Text = "";
    }

    private void Name_KeyPress(object? sender, KeyPressEventArgs e)
    {
        if (e.KeyChar is ' ' || e.KeyChar is '\n' || e.KeyChar is '\t')
            e.Handled = true;
    }

    private void FinishEdition(object? sender, EventArgs e)
    {
        if (_isEditing || Height.Text is "" || Weight.Text is "")
            return;
        MemberRoster.Roster[Name.Text] = new Member(
            Name.Text,
            Height.Text.ToFloat() ?? 0f,
            Weight.Text.ToFloat() ?? 0f,
            WorkIntensity.Text.DescriptionToEnum<WorkIntensityFlag>()
            );
        MemberRoster.Roster.EnqueueHistory();

        UpdateMemberList();
    }

    protected override void UpdateAllData() => UpdateMemberList();

    #endregion
}
