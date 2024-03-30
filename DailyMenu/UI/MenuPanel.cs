using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace DailyMenu.UI
{
    public class MenuPanel : Panel
    {
        public MenuPanel()
        {
            BackColor = Color.Red;
            InitializeComponent();

            Resize += MenuPanel_Resize;

            DrawClient();
        }

        private void MenuPanel_Resize(object? sender, EventArgs e)
        {
            DrawClient();
        }

        private void DrawClient()
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
            // RecipeList
            //
            RecipeList.Left = ClientRectangle.Left + padding;
            RecipeList.Top = ClientRectangle.Top + padding;
            RecipeList.Width = listWidth;
            RecipeList.Height = listHeight;
            RecipeList.Font = listFont;
            //
            // Copies
            //
            Copies.Left = RecipeList.Left + padding;
            Copies.Top = ClientRectangle.Top + ClientRectangle.Height - (ClientRectangle.Height - numericHeight) / 2;
            Copies.Width = numericWidth;
            Copies.Font = editFont;
            Copies.TextAlign = HorizontalAlignment.Center;
            //
            // HeightLabel
            //
            RecipeList.Left = Copies.Left + padding;
            RecipeList.Top = ClientRectangle.Top + padding;
            RecipeList.Width = listWidth;
            RecipeList.Height = listHeight;
            RecipeList.Font = listFont;
            
            ResumeLayout();
        }

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            Controls.AddRange([
                RecipeList,
                MenuList,
                Copies,
                ]);
        }

        ListView RecipeList = new();
        ListView MenuList = new();
        NumericUpDown Copies = new();
    }
}
