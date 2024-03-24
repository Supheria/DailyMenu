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
        const int padding = 12;
        //
        //
        // Name
        //
        Name.Left = ClientRectangle.Left + padding;
        Name.Top = (int)(ClientRectangle.Top + padding * 1.5f);
        Name.Width = (int)(ClientRectangle.Width / 4);
        Name.Height = (int)(ClientRectangle.Height - padding * 2.5);
        //
        //
        // Height
        //
        Height.Left = Name.Left + padding;
        Height.Top = (int)(ClientRectangle.Top + padding * 1.5f);
        Height.Width = (int)(ClientRectangle.Width / 4);
        Height.Height = (int)(ClientRectangle.Height - padding * 2.5);
        //
        //
        // Weight
        //
        Weight.Left = Height.Left + padding;
        Weight.Top = (int)(ClientRectangle.Top + padding * 1.5f);
        Weight.Width = (int)(ClientRectangle.Width / 4);
        Weight.Height = (int)(ClientRectangle.Height - padding * 2.5);
        //
        //
        // WorkIntensity
        //
        WorkIntensity.Left = Weight.Left + padding;
        WorkIntensity.Top = (int)(ClientRectangle.Top + padding * 1.5f);
        WorkIntensity.Width = (int)(ClientRectangle.Width / 4);
        WorkIntensity.Height = (int)(ClientRectangle.Height - padding * 2.5);
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
        var foreColor = Color.DarkBlue;
        //
        // Name
        //
        Name.Name = "Name";
        Name.TextAlign = HorizontalAlignment.Center;
        Name.BorderStyle = BorderStyle.FixedSingle;
        Name.BackColor = backColor;
        Name.ForeColor = foreColor;
        //
        // Height
        //
        Height.Name = "Height";
        Height.TextAlign = HorizontalAlignment.Center;
        Height.BorderStyle = BorderStyle.FixedSingle;
        Height.BackColor = backColor;
        Height.ForeColor = foreColor;
        //
        // Weight
        //
        Height.Name = "Weight";
        Height.TextAlign = HorizontalAlignment.Center;
        Height.BorderStyle = BorderStyle.FixedSingle;
        Height.BackColor = backColor;
        Height.ForeColor = foreColor;
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
        //
        // Add
        //

        //
        // Delete
        //

        //
        // Edit
        //

        //
        // MemberList
        //
        MemberList.Name = "MemberList";
        MemberList.Columns.AddRange(new ColumnHeader[]
        {
            NameHeader
        });
        //
        // NameHeader
        //
        NameHeader.Name = "NameHeader";
        NameHeader.Text = "名字";
        NameHeader.Width = 120;
        NameHeader.TextAlign = HorizontalAlignment.Center;
        //
        // main
        //
        Controls.AddRange(new Control[]
        {
            Name,
            Height,
            Weight,
            WorkIntensity,
            Add,
            Delete,
            Edit,
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
    }

    new System.Windows.Forms.TextBox Name = new();
    new System.Windows.Forms.TextBox Height = new();
    System.Windows.Forms.TextBox Weight = new();
    System.Windows.Forms.ComboBox WorkIntensity = new();
    System.Windows.Forms.Button Add = new();
    System.Windows.Forms.Button Delete = new();
    System.Windows.Forms.Button Edit = new();
    System.Windows.Forms.ListView MemberList = new();
    System.Windows.Forms.ColumnHeader NameHeader = new();
}
