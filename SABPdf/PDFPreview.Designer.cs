namespace SettingForm
{
    partial class PDFPreview
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        public System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PDFPreview));
            this.axAcroPDFPreview = new AxAcroPDFLib.AxAcroPDF();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDFPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // axAcroPDFPreview
            // 
            this.axAcroPDFPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axAcroPDFPreview.Enabled = true;
            this.axAcroPDFPreview.Location = new System.Drawing.Point(0, 0);
            this.axAcroPDFPreview.Name = "axAcroPDFPreview";
            this.axAcroPDFPreview.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAcroPDFPreview.OcxState")));
            this.axAcroPDFPreview.Size = new System.Drawing.Size(524, 504);
            this.axAcroPDFPreview.TabIndex = 0;
            // 
            // PDFPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 504);
            this.Controls.Add(this.axAcroPDFPreview);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PDFPreview";
            this.Text = "PDFPreview";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PDFPreview_FormClosed);
            this.Load += new System.EventHandler(this.PDFPreview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDFPreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public AxAcroPDFLib.AxAcroPDF axAcroPDFPreview;

    }
}