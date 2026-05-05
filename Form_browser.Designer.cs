namespace 英文逐語訳
{
    partial class Form_browser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.wb = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // wb
            // 
            this.wb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wb.Location = new System.Drawing.Point(0, 0);
            this.wb.MinimumSize = new System.Drawing.Size(20, 20);
            this.wb.Name = "wb";
            this.wb.Size = new System.Drawing.Size(800, 450);
            this.wb.TabIndex = 0;
            this.wb.NewWindow += new System.ComponentModel.CancelEventHandler(this.wb_NewWindow);
            // 
            // Form_browser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.wb);
            this.Name = "Form_browser";
            this.Text = "マウスホバーで逐語訳";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser wb;
    }
}