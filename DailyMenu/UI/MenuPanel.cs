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
            InitializeComponent();

            SizeChanged += MenuPanel_Resize;

            DrawClient();
        }

        private void MenuPanel_Resize(object? sender, EventArgs e)
        {
            DrawClient();
        }

        protected void DrawClient()
        {
            if (Visible == false)
                return;
            SuspendLayout();
            const int padding = 10;
            var listFont = new Font("黑体", base.Height * 0.05f, FontStyle.Regular, GraphicsUnit.Pixel);
            var editFont = new Font("仿宋", base.Height * 0.075f, FontStyle.Regular, GraphicsUnit.Pixel);
            var numericWidth = (int)(ClientRectangle.Width * 0.2f);
            var listWidth = (ClientRectangle.Width - numericWidth - padding * 4) / 2;
            var listHeight = ClientRectangle.Height - padding * 2;
            //
            // RecipeLabel
            //
            RecipeLabel.Left = ClientRectangle.Left + padding;
            RecipeLabel.Top = ClientRectangle.Top + padding;
            RecipeLabel.Width = listWidth;
            RecipeLabel.Height = listHeight;
            RecipeLabel.Font = listFont;
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
            Copies.Left = RecipeList.Right + padding;
            Copies.Top = ClientRectangle.Top + (ClientRectangle.Height - Copies.Height) / 2;
            Copies.Width = numericWidth;
            Copies.Font = editFont;
            Copies.TextAlign = HorizontalAlignment.Center;
            //
            // MenuList
            //
            MenuList.Left = Copies.Right + padding;
            MenuList.Top = ClientRectangle.Top + padding;
            MenuList.Width = listWidth;
            MenuList.Height = listHeight;
            MenuList.Font = listFont;
            
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
            //
            // RecipeLabel
            //
            RecipeLabel.Text = "食谱列表";
        }

        Label RecipeLabel = new();
        Label MenuLabel = new();
        ListView RecipeList = new();
        ListView MenuList = new();
        TextBox Copies = new();
    }
}
