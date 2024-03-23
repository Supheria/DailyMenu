using DailyMenu.IO.Xml;
using System.Drawing.Text;
using LocalUtilities.SerializeUtilities;
using LocalUtilities.ManageUtilities;

namespace DailyMenu
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            DrawClient();
            SizeChanged += MainForm_SizeChanged;
            _ = new MembersXmlSerialization().LoadFromXml("test.xml", out var members);
            _members = members ?? _members;
            _members.SaveToXml("test.xml", new MembersXmlSerialization());
        }
        private void InitializeComponent()
        {
            SuspendLayout();
            var backColor = Color.White;
            var foreColor = Color.DarkBlue;
            //
            // main
            //
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Name = "Daily Menu";
            Controls.AddRange(new Control[]
            {
                MemberList,
            });
            TopMost = true;
            //MinimumSize = Size = new((int)(500 * SizeRatio), 500);
            BackColor = backColor;
            Location = new(
                (Screen.GetBounds(this).Width / 2) - (this.Width / 2),
                (Screen.GetBounds(this).Height / 2) - (this.Height / 2)
                );
            //MinimizeBox = MaximizeBox = false;
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            ResumeLayout();
        }

        private void MainForm_SizeChanged(object? sender, EventArgs e)
        {
            DrawClient();
        }

        private Members _members = new();

        PictureBox MemberList = new();

        protected virtual void DrawClient()
        {
            if (WindowState == FormWindowState.Minimized)
            {
                return;
            }
            SuspendLayout();
            const int padding = 12;
            var fontSize = Height * 0.03f;
            //
            //
            //MemberList
            //
            MemberList.Left = ClientRectangle.Left + padding;
            MemberList.Top = (int)(ClientRectangle.Top + padding * 1.5f);
            MemberList.Width = (int)(ClientRectangle.Width - padding * 2.5);
            MemberList.Height = (int)(ClientRectangle.Height - padding * 2.5);
            //
            // draw picture box image
            //
            MemberList.Image?.Dispose();
            MemberList.Image = new Bitmap(MemberList.Width, MemberList.Height);
            var gMembers = Graphics.FromImage(MemberList.Image);
            gMembers.Clear(BackColor);
            var brush = new SolidBrush(Color.DarkBlue);
            var stringFormat = new StringFormat
            {
                Alignment = StringAlignment.Near,
                FormatFlags = (StringFormatFlags)0,
                HotkeyPrefix = HotkeyPrefix.None,
                LineAlignment = StringAlignment.Near,
                Trimming = StringTrimming.None
            };
            //stringFormat.Alignment = StringAlignment.Near;
            //stringFormat.LineAlignment = StringAlignment.Center;
            //stringFormat.Alignment = StringAlignment.Center;
            string content = "";
            foreach (var member in _members.MemberList)
            {
                content += $"{member.Name}£º{_members.Percentage(member)}\n";
            }
            gMembers.DrawString(
                content,
                new Font("·ÂËÎ", fontSize, FontStyle.Regular, GraphicsUnit.Pixel),
                brush,
                new RectangleF(0, 0, MemberList.Width, MemberList.Height),
                stringFormat
                );
            gMembers.Flush(); gMembers.Dispose();
            ResumeLayout();
        }
    }
}
