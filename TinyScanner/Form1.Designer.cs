namespace TinyScanner
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.ListBox lstTokens;
        private System.Windows.Forms.Button btnScan;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lstTokens = new System.Windows.Forms.ListBox();
            this.btnScan = new System.Windows.Forms.Button();
            this.SuspendLayout();
          
            this.txtCode.Location = new System.Drawing.Point(12, 12);
            this.txtCode.Multiline = true;
            this.txtCode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCode.Size = new System.Drawing.Size(460, 200);
            this.txtCode.Name = "txtCode";
           
            this.lstTokens.Location = new System.Drawing.Point(12, 230);
            this.lstTokens.Size = new System.Drawing.Size(460, 200);
            this.lstTokens.Name = "lstTokens";
          
            this.btnScan.Location = new System.Drawing.Point(490, 100);
            this.btnScan.Size = new System.Drawing.Size(100, 40);
            this.btnScan.Name = "btnScan";
            this.btnScan.Text = "Scan";
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
          
            this.ClientSize = new System.Drawing.Size(600, 450);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lstTokens);
            this.Controls.Add(this.btnScan);
            this.Name = "Form1";
            this.Text = "Tiny Lexical Analyzer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}