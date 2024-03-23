using System.Drawing.Text;

namespace DailyMenu
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

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
            // FocusName
            //
            FocusName.Left = ClientRectangle.Left + padding;
            FocusName.Top = ClientRectangle.Top + padding;
            FocusName.Width = (int)((ClientRectangle.Width - padding * 2.5) * 0.7 - padding);
            FocusName.Font = new Font(Font.FontFamily, fontSize, FontStyle.Regular, GraphicsUnit.Pixel);
            //
            // FocusIcon
            //
            FocusIcon.Left = ClientRectangle.Left + padding;
            FocusIcon.Top = FocusName.Bottom + padding;
            FocusIcon.Width = (int)(MathF.Min(ClientRectangle.Width * 0.382f, ClientRectangle.Height * 0.3f));
            FocusIcon.Height = (int)(MathF.Min(ClientRectangle.Width * 0.382f, ClientRectangle.Height * 0.3f));
            //
            // Duration
            //
            Duration.Left = FocusIcon.Right + padding;
            Duration.Top = FocusName.Bottom + padding;
            Duration.Width = (int)((FocusName.Width * 1.05f - FocusIcon.Right) * 0.6f);
            //Duration.Height = textFont.Height;
            Duration.Font = new Font(Font.FontFamily, fontSize, FontStyle.Regular, GraphicsUnit.Pixel);
            //
            // DurationUnit
            //
            DurationUnit.Left = (int)(Duration.Right);
            DurationUnit.Top = (int)(FocusName.Bottom + padding * 1.22f);
            DurationUnit.Width = (int)(FocusName.Width - FocusIcon.Width - Duration.Width);
            DurationUnit.Height = Duration.Height;
            //
            // ButtonEvent
            //
            ButtonEvent.Left = (int)(FocusName.Right + padding * 2.5f);
            ButtonEvent.Top = ClientRectangle.Top + padding;
            ButtonEvent.Width = (int)(ClientRectangle.Right - FocusName.Right - padding * 4.5f);
            ButtonEvent.Height = (int)(Duration.Bottom - ClientRectangle.Top - padding);
            ButtonEvent.Font = new Font("黑体", fontSize, FontStyle.Regular, GraphicsUnit.Pixel);
            //
            // Requires
            //
            Requires.Left = FocusIcon.Right + padding;
            Requires.Top = (int)(Duration.Bottom + padding * 1.5f);
            Requires.Width = (int)(ClientRectangle.Right - FocusIcon.Right - padding * 2.5f);
            Requires.Height = FocusIcon.Bottom - Duration.Bottom - padding * 2;

            //
            // Description
            //
            Descript.Left = ClientRectangle.Left + padding;
            Descript.Top = FocusIcon.Bottom + padding;
            Descript.Width = (int)(ClientRectangle.Width - padding * 2.5f);
            Descript.Height = (int)(ClientRectangle.Height * 0.15f);
            //
            //EffectsTitle
            //
            EffectsTitle.Left = ClientRectangle.Left + padding;
            EffectsTitle.Top = (int)(Descript.Bottom + padding * 1.5f);
            EffectsTitle.Width = (int)(ClientRectangle.Width - padding * 2.5);
            EffectsTitle.Height = (int)(ClientRectangle.Height * 0.05f);
            //
            // Effects
            //
            Effects.Left = ClientRectangle.Left + padding;
            Effects.Top = (int)(EffectsTitle.Bottom + padding * 0.5f);
            Effects.Width = (int)(ClientRectangle.Width - padding * 2.5f);
            Effects.Height = (int)(ClientRectangle.Bottom - EffectsTitle.Bottom - padding * 2.5f);
            //
            // draw picture box image
            //
            FocusIcon.Image?.Dispose();
            DurationUnit.Image?.Dispose();
            EffectsTitle.Image?.Dispose();
            //FocusIcon.Image = Image.FromFile("C:\\Non_E\\documents\\GitHub\\FocusTree\\FocusTree\\FocusTree\\Resources\\FocusTree.ico");
            DurationUnit.Image = new Bitmap(DurationUnit.Width, DurationUnit.Height);
            EffectsTitle.Image = new Bitmap(EffectsTitle.Width, EffectsTitle.Height);
            var g1 = Graphics.FromImage(DurationUnit.Image);
            var g2 = Graphics.FromImage(EffectsTitle.Image);
            g1.Clear(BackColor);
            g2.Clear(BackColor);
            var brush = new SolidBrush(Color.Black);
            var stringFormat = new StringFormat
            {
                Alignment = StringAlignment.Near,
                FormatFlags = (StringFormatFlags)0,
                HotkeyPrefix = HotkeyPrefix.None,
                LineAlignment = StringAlignment.Near,
                Trimming = StringTrimming.None
            };
            stringFormat.Alignment = StringAlignment.Near;
            stringFormat.LineAlignment = StringAlignment.Center;
            g1.DrawString(
                "日",
                new Font("仿宋", fontSize, FontStyle.Bold, GraphicsUnit.Pixel),
                brush,
                new RectangleF(0, 0, DurationUnit.Width, DurationUnit.Height),
                stringFormat
                );
            stringFormat.Alignment = StringAlignment.Center;
            g2.DrawString(
                "==== 效果 ====",
                new Font("仿宋", fontSize, FontStyle.Regular, GraphicsUnit.Pixel),
                brush,
                new RectangleF(0, 0, EffectsTitle.Width, EffectsTitle.Height),
                stringFormat
                );
            g1.Flush(); g1.Dispose();
            g2.Flush(); g2.Dispose();
            ResumeLayout();
        }
    }
}
