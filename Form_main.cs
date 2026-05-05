// Form_main.cs
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace 英文逐語訳
{
    public partial class Form_main : Form
    {
        public Form_main()
        {
            InitializeComponent();
            btn逐語訳.Select();
            btn逐語訳.Focus();
        }

        private void btn逐語訳_Click(object sender, EventArgs e)
        {
            if (textBox.Text.Trim()=="") { return; }
            var fb = new Form_browser(textBox.Text);
            fb.Show();
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (textBox.Text.Trim() == "") { this.btn逐語訳.Enabled = false; }
            else { this.btn逐語訳.Enabled = true; }
        }
    }

    /// <summary>
    /// placeholderつきtextBox
    /// </summary>
    public class TextBoxEx : System.Windows.Forms.TextBox
    {
        private string _placeholder = "";
        private Color _placeholderColor = Color.Gray;

        public string PlaceHolder
        {
            get => _placeholder;
            set { _placeholder = value; Invalidate(); }
        }

        public Color PlaceHolderColor
        {
            get => _placeholderColor;
            set { _placeholderColor = value; Invalidate(); }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            // WM_PAINT = 0x000F
            if (m.Msg == 0x000F)
            {
                if (ShouldDrawPlaceholder())
                { DrawPlaceholder(); }
            }
        }

        private bool ShouldDrawPlaceholder()
        {
            return !Focused &&
                   string.IsNullOrEmpty(Text) &&
                   !string.IsNullOrEmpty(_placeholder);
        }

        private void DrawPlaceholder()
        {
            using (Graphics g = Graphics.FromHwnd(this.Handle))
            {
                Rectangle rect = this.ClientRectangle;

                // TextBox の内部余白に合わせる
                rect.Offset(1, 1);

                TextRenderer.DrawText(
                    g,
                    _placeholder,
                    this.Font,
                    rect,
                    _placeholderColor,
                    TextFormatFlags.Left | TextFormatFlags.Top
                );
            }
        }
    }



}
