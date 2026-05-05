namespace 英文逐語訳
{
    partial class Form_main
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn逐語訳 = new System.Windows.Forms.Button();
            this.textBox = new 英文逐語訳.TextBoxEx();
            this.SuspendLayout();
            // 
            // btn逐語訳
            // 
            this.btn逐語訳.Enabled = false;
            this.btn逐語訳.Location = new System.Drawing.Point(12, 6);
            this.btn逐語訳.Name = "btn逐語訳";
            this.btn逐語訳.Size = new System.Drawing.Size(75, 23);
            this.btn逐語訳.TabIndex = 1;
            this.btn逐語訳.Text = "逐語訳";
            this.btn逐語訳.UseVisualStyleBackColor = true;
            this.btn逐語訳.Click += new System.EventHandler(this.btn逐語訳_Click);
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(12, 35);
            this.textBox.MaxLength = 0;
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.PlaceHolder = "ここに英文を書く";
            this.textBox.PlaceHolderColor = System.Drawing.Color.Gray;
            this.textBox.Size = new System.Drawing.Size(776, 403);
            this.textBox.TabIndex = 0;
            this.textBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // Form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn逐語訳);
            this.Controls.Add(this.textBox);
            this.Name = "Form_main";
            this.Text = "英文の逐語訳";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBoxEx textBox;
        private System.Windows.Forms.Button btn逐語訳;
    }
}

