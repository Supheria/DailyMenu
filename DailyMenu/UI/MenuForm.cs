using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyMenu.UI
{
    public partial class MenuForm : RosterForm
    {
        float SizeRatio { get; set; } = 0.618f;

        public MenuForm() : base("menu form")
        {
        }

        protected override void DrawClient()
        {
            if (Visible == false)
                return;
            SuspendLayout();
            const int padding = 10;
            var listFont = new Font("黑体", base.Height * 0.05f, FontStyle.Regular, GraphicsUnit.Pixel);
            var editFont = new Font("仿宋", base.Height * 0.075f, FontStyle.Regular, GraphicsUnit.Pixel);
            var numericWidth = (int)(ClientRectangle.Width * 0.2f);
            var numericHeight = (int)(ClientRectangle.Height * 0.5f);
            var listWidth = (ClientRectangle.Width - numericWidth - padding * 4) / 2;
            var listHeight = ClientRectangle.Height - padding * 2;
            //
            // MenuPanel
            //
            MenuPanel.Left = ClientRectangle.Left + padding;
            MenuPanel.Top = ClientRectangle.Top + padding;
            MenuPanel.Width = ClientRectangle.Width - padding * 2;
            MenuPanel.Height = ClientRectangle.Height - padding * 2;
            

            ResumeLayout();
        }

        protected override void InitializeComponent()
        {
            var backColor = Color.White;
            MinimumSize = new(500, (int)(500 * SizeRatio));
            Location = new(
                    (Screen.GetBounds(this).Width / 2) - (this.Width / 2),
                    (Screen.GetBounds(this).Height / 2) - (base.Height / 2)
                    );
            BackColor = backColor;
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            Controls.AddRange([
                MenuPanel,
            ]);
            //MenuPanel.Visible = false;
        }

        protected override void UpdateAllData()
        {
            
        }

        MenuPanel MenuPanel = new();
    }
}
