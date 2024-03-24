using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyMenu;

public partial class MemberForm : Form
{

    internal float SizeRatio = 0.618f;
    internal float LengthMaxlRatio = 3f;

    public MemberForm()
    {
        InitializeComponent();

        FormClosing += MemberForm_FormClosing;
        SizeChanged += MemberForm_SizeChanged;

        DrawClient();
    }

    private void MemberForm_SizeChanged(object? sender, EventArgs e)
    {
        DrawClient();
    }

    protected virtual void DrawClient()
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
        // Name
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
        var buttonWidth = ClientRectangle.Width / 3;
        var buttonHeight = (int)(ClientRectangle.Height * 0.1f);
        //
        // Edit
        //
        Edit.Left = ClientRectangle.Left + buttonWidth;
        Edit.Top = Name.Bottom + padding;
        Edit.Height = buttonHeight;
        Edit.Width = buttonWidth;
        Edit.Font = labelFont;
        //
        // MemberList
        //
        MemberList.Left = ClientRectangle.Left + padding;
        MemberList.Top = Edit.Bottom + padding;
        MemberList.Width = ClientRectangle.Width - padding * 2;
        MemberList.Height = ClientRectangle.Bottom - Edit.Bottom - padding * 4 - buttonHeight;
        //
        //
        //
        buttonWidth = ClientRectangle.Width / 5;
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

    public virtual new void Close() => Hide();

    private void MemberForm_FormClosing(object? sender, FormClosingEventArgs e)
    {
        Close();
        e.Cancel = true;
        Hide();
    }

    private void InitializeComponent()
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
            Edit,
            Delete,
            Save,
            MemberList,
        });
        TopMost = true;
        MinimumSize = Size = new(500, (int)(500 * SizeRatio));
        BackColor = backColor;
        Location = new(
            (Screen.GetBounds(this).Width / 2) - (this.Width / 2),
            (Screen.GetBounds(this).Height / 2) - (base.Height / 2)
            );
        //MinimizeBox = MaximizeBox = false;
        DoubleBuffered = true;
        SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
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
        // Name
        //
        Name.Name = "Name";
        Name.TextAlign = HorizontalAlignment.Center;
        Name.BorderStyle = BorderStyle.FixedSingle;
        Name.BackColor = backColor;
        Name.ForeColor = editColor;
        //
        // Height
        //
        Height.Name = "Height";
        Height.TextAlign = HorizontalAlignment.Center;
        Height.BorderStyle = BorderStyle.FixedSingle;
        Height.BackColor = backColor;
        Height.ForeColor = editColor;
        //
        // Weight
        //
        Height.Name = "Weight";
        Height.TextAlign = HorizontalAlignment.Center;
        Height.BorderStyle = BorderStyle.FixedSingle;
        Height.BackColor = backColor;
        Height.ForeColor = editColor;
        //
        // WorkIntensity
        //
        WorkIntensity.Name = "WorkIntensity";
        WorkIntensity.Items.AddRange(new object[]
        {
            "极轻",
            "轻度",
            "中度",
            "重度",
        });
        WorkIntensity.SelectedIndex = 0;
        WorkIntensity.DropDownStyle = ComboBoxStyle.DropDownList;
        WorkIntensity.FlatStyle = FlatStyle.Popup;
        WorkIntensity.BackColor = backColor;
        WorkIntensity.ForeColor = editColor;
        //
        // Edit
        //
        Edit.Name = "Add";
        Edit.Text = "添改";
        Edit.BackColor = buttonColor;
        Edit.ForeColor = labelColor;
        //
        // Delete
        //
        Delete.Name = "Delete";
        Delete.Text = "删除";
        Delete.BackColor = buttonColor;
        Delete.ForeColor = labelColor;
        //
        // Save
        //
        Save.Name = "Save";
        Save.Text = "保存";
        Save.BackColor = buttonColor;
        Save.ForeColor = labelColor;
        //
        // MemberList
        //
        MemberList.Name = "MemberList";
        MemberList.View = View.Details;
        MemberList.Columns.AddRange(new ColumnHeader[]
        {
            NameHeader,
            HeightHeader,
            WeightHeader,
        });
        this.MemberList.BeginUpdate();   //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度

        for (int i = 0; i < 10; i++)   //添加10行数据
        {
            ListViewItem lvi = new ListViewItem();

            lvi.ImageIndex = i;     //通过与imageList绑定，显示imageList中第i项图标

            lvi.Text = "subitem" + i;

            lvi.SubItems.Add("第2列,第" + i + "行");

            lvi.SubItems.Add("第3列,第" + i + "行");

            this.MemberList.Items.Add(lvi);
        }

        this.MemberList.EndUpdate();  //结束数据处理，UI界面一次性绘制。
        //
        // NameHeader
        //
        NameHeader.Name = "NameHeader";
        NameHeader.Text = "名字";
        NameHeader.Width = 120;
        NameHeader.TextAlign = HorizontalAlignment.Center;
        //
        // HeightHeader
        //
        HeightHeader.Name = "HeightHeader";
        HeightHeader.Text = "身高(m)";
        HeightHeader.Width = 120;
        HeightHeader.TextAlign = HorizontalAlignment.Center;
        //
        // WeightHeader
        //
        WeightHeader.Name = "WeightHeader";
        WeightHeader.Text = "体重(kg)";
        WeightHeader.Width = 120;
        WeightHeader.TextAlign = HorizontalAlignment.Center;
    }

    System.Windows.Forms.Label NameLabel = new();
    System.Windows.Forms.Label HeightLabel = new();
    System.Windows.Forms.Label WeightLabel = new();
    System.Windows.Forms.Label WorkIntensityLabel = new();
    new System.Windows.Forms.TextBox Name = new();
    new System.Windows.Forms.TextBox Height = new();
    System.Windows.Forms.TextBox Weight = new();
    System.Windows.Forms.ComboBox WorkIntensity = new();
    System.Windows.Forms.Button Edit = new();
    System.Windows.Forms.Button Delete = new();
    System.Windows.Forms.Button Save = new();
    System.Windows.Forms.ListView MemberList = new();
    System.Windows.Forms.ColumnHeader NameHeader = new();
    System.Windows.Forms.ColumnHeader HeightHeader = new();
    System.Windows.Forms.ColumnHeader WeightHeader = new();
}
