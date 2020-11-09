namespace SettingForm
{
    partial class FormSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.title = new System.Windows.Forms.Label();
            this.panelKimitsu = new System.Windows.Forms.Panel();
            this.lnkLblDoc = new System.Windows.Forms.LinkLabel();
            this.rdoElse = new System.Windows.Forms.RadioButton();
            this.rdoB = new System.Windows.Forms.RadioButton();
            this.rdoA = new System.Windows.Forms.RadioButton();
            this.rdoS = new System.Windows.Forms.RadioButton();
            this.lblSettei = new System.Windows.Forms.Label();
            this.labelSttei = new System.Windows.Forms.Label();
            this.labelKimitsu = new System.Windows.Forms.Label();
            this.labelStamp = new System.Windows.Forms.Label();
            this.panelStamp = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.radioButtonNotSubstitute = new System.Windows.Forms.RadioButton();
            this.radioButtonSubstitute = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.radioButtonUpperRight = new System.Windows.Forms.RadioButton();
            this.radioButtonUpperLeft = new System.Windows.Forms.RadioButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.radioButtonSmall = new System.Windows.Forms.RadioButton();
            this.radioButtonMiddle = new System.Windows.Forms.RadioButton();
            this.radioButtonLarge = new System.Windows.Forms.RadioButton();
            this.labelPercent = new System.Windows.Forms.Label();
            this.txtBoxStampOpacity = new System.Windows.Forms.NumericUpDown();
            this.labelWatermark = new System.Windows.Forms.Label();
            this.labelStampSize = new System.Windows.Forms.Label();
            this.labelStampPosition = new System.Windows.Forms.Label();
            this.labelStampMenu = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panelKimitsu.SuspendLayout();
            this.panelStamp.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBoxStampOpacity)).BeginInit();
            this.SuspendLayout();
            // 
            // title
            // 
            resources.ApplyResources(this.title, "title");
            this.title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.title.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.title.Name = "title";
            // 
            // panelKimitsu
            // 
            resources.ApplyResources(this.panelKimitsu, "panelKimitsu");
            this.panelKimitsu.BackColor = System.Drawing.Color.White;
            this.panelKimitsu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelKimitsu.Controls.Add(this.lnkLblDoc);
            this.panelKimitsu.Controls.Add(this.rdoElse);
            this.panelKimitsu.Controls.Add(this.rdoB);
            this.panelKimitsu.Controls.Add(this.rdoA);
            this.panelKimitsu.Controls.Add(this.rdoS);
            this.panelKimitsu.Controls.Add(this.lblSettei);
            this.panelKimitsu.Controls.Add(this.labelSttei);
            this.panelKimitsu.Controls.Add(this.labelKimitsu);
            this.panelKimitsu.Name = "panelKimitsu";
            // 
            // lnkLblDoc
            // 
            resources.ApplyResources(this.lnkLblDoc, "lnkLblDoc");
            this.lnkLblDoc.Name = "lnkLblDoc";
            this.lnkLblDoc.TabStop = true;
            this.lnkLblDoc.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLblDoc_LinkClicked);
            // 
            // rdoElse
            // 
            resources.ApplyResources(this.rdoElse, "rdoElse");
            this.rdoElse.BackColor = System.Drawing.Color.Gray;
            this.rdoElse.ForeColor = System.Drawing.Color.White;
            this.rdoElse.Name = "rdoElse";
            this.rdoElse.UseVisualStyleBackColor = false;
            this.rdoElse.CheckedChanged += new System.EventHandler(this.btnSAB_CheckedChanged);
            // 
            // rdoB
            // 
            resources.ApplyResources(this.rdoB, "rdoB");
            this.rdoB.BackColor = System.Drawing.Color.Gray;
            this.rdoB.ForeColor = System.Drawing.Color.White;
            this.rdoB.Name = "rdoB";
            this.rdoB.UseVisualStyleBackColor = false;
            this.rdoB.CheckedChanged += new System.EventHandler(this.btnSAB_CheckedChanged);
            // 
            // rdoA
            // 
            resources.ApplyResources(this.rdoA, "rdoA");
            this.rdoA.BackColor = System.Drawing.Color.Gray;
            this.rdoA.ForeColor = System.Drawing.Color.White;
            this.rdoA.Name = "rdoA";
            this.rdoA.UseVisualStyleBackColor = false;
            this.rdoA.CheckedChanged += new System.EventHandler(this.btnSAB_CheckedChanged);
            // 
            // rdoS
            // 
            resources.ApplyResources(this.rdoS, "rdoS");
            this.rdoS.BackColor = System.Drawing.Color.Green;
            this.rdoS.Checked = true;
            this.rdoS.ForeColor = System.Drawing.Color.White;
            this.rdoS.Name = "rdoS";
            this.rdoS.TabStop = true;
            this.rdoS.UseVisualStyleBackColor = false;
            this.rdoS.CheckedChanged += new System.EventHandler(this.btnSAB_CheckedChanged);
            // 
            // lblSettei
            // 
            resources.ApplyResources(this.lblSettei, "lblSettei");
            this.lblSettei.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblSettei.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSettei.Name = "lblSettei";
            // 
            // labelSttei
            // 
            resources.ApplyResources(this.labelSttei, "labelSttei");
            this.labelSttei.Name = "labelSttei";
            // 
            // labelKimitsu
            // 
            resources.ApplyResources(this.labelKimitsu, "labelKimitsu");
            this.labelKimitsu.Name = "labelKimitsu";
            // 
            // labelStamp
            // 
            resources.ApplyResources(this.labelStamp, "labelStamp");
            this.labelStamp.Name = "labelStamp";
            // 
            // panelStamp
            // 
            resources.ApplyResources(this.panelStamp, "panelStamp");
            this.panelStamp.BackColor = System.Drawing.Color.White;
            this.panelStamp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelStamp.Controls.Add(this.panel4);
            this.panelStamp.Controls.Add(this.panel3);
            this.panelStamp.Controls.Add(this.panel5);
            this.panelStamp.Controls.Add(this.labelPercent);
            this.panelStamp.Controls.Add(this.txtBoxStampOpacity);
            this.panelStamp.Controls.Add(this.labelWatermark);
            this.panelStamp.Controls.Add(this.labelStampSize);
            this.panelStamp.Controls.Add(this.labelStampPosition);
            this.panelStamp.Controls.Add(this.labelStampMenu);
            this.panelStamp.Controls.Add(this.labelStamp);
            this.panelStamp.Name = "panelStamp";
            // 
            // panel4
            // 
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Controls.Add(this.radioButtonNotSubstitute);
            this.panel4.Controls.Add(this.radioButtonSubstitute);
            this.panel4.Name = "panel4";
            // 
            // radioButtonNotSubstitute
            // 
            resources.ApplyResources(this.radioButtonNotSubstitute, "radioButtonNotSubstitute");
            this.radioButtonNotSubstitute.BackColor = System.Drawing.Color.Gray;
            this.radioButtonNotSubstitute.ForeColor = System.Drawing.Color.White;
            this.radioButtonNotSubstitute.Name = "radioButtonNotSubstitute";
            this.radioButtonNotSubstitute.TabStop = true;
            this.radioButtonNotSubstitute.UseVisualStyleBackColor = false;
            this.radioButtonNotSubstitute.CheckedChanged += new System.EventHandler(this.btnStamp_CheckedChanged);
            // 
            // radioButtonSubstitute
            // 
            resources.ApplyResources(this.radioButtonSubstitute, "radioButtonSubstitute");
            this.radioButtonSubstitute.BackColor = System.Drawing.Color.Green;
            this.radioButtonSubstitute.ForeColor = System.Drawing.Color.White;
            this.radioButtonSubstitute.Name = "radioButtonSubstitute";
            this.radioButtonSubstitute.TabStop = true;
            this.radioButtonSubstitute.UseVisualStyleBackColor = false;
            this.radioButtonSubstitute.CheckedChanged += new System.EventHandler(this.btnStamp_CheckedChanged);
            // 
            // panel3
            // 
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Controls.Add(this.radioButtonUpperRight);
            this.panel3.Controls.Add(this.radioButtonUpperLeft);
            this.panel3.Name = "panel3";
            // 
            // radioButtonUpperRight
            // 
            resources.ApplyResources(this.radioButtonUpperRight, "radioButtonUpperRight");
            this.radioButtonUpperRight.BackColor = System.Drawing.Color.Gray;
            this.radioButtonUpperRight.ForeColor = System.Drawing.Color.White;
            this.radioButtonUpperRight.Name = "radioButtonUpperRight";
            this.radioButtonUpperRight.TabStop = true;
            this.radioButtonUpperRight.UseVisualStyleBackColor = false;
            this.radioButtonUpperRight.CheckedChanged += new System.EventHandler(this.btnPosition_CheckedChanged);
            // 
            // radioButtonUpperLeft
            // 
            resources.ApplyResources(this.radioButtonUpperLeft, "radioButtonUpperLeft");
            this.radioButtonUpperLeft.BackColor = System.Drawing.Color.Green;
            this.radioButtonUpperLeft.ForeColor = System.Drawing.Color.White;
            this.radioButtonUpperLeft.Name = "radioButtonUpperLeft";
            this.radioButtonUpperLeft.TabStop = true;
            this.radioButtonUpperLeft.UseVisualStyleBackColor = false;
            this.radioButtonUpperLeft.CheckedChanged += new System.EventHandler(this.btnPosition_CheckedChanged);
            // 
            // panel5
            // 
            resources.ApplyResources(this.panel5, "panel5");
            this.panel5.Controls.Add(this.radioButtonSmall);
            this.panel5.Controls.Add(this.radioButtonMiddle);
            this.panel5.Controls.Add(this.radioButtonLarge);
            this.panel5.Name = "panel5";
            // 
            // radioButtonSmall
            // 
            resources.ApplyResources(this.radioButtonSmall, "radioButtonSmall");
            this.radioButtonSmall.BackColor = System.Drawing.Color.Gray;
            this.radioButtonSmall.ForeColor = System.Drawing.Color.White;
            this.radioButtonSmall.Name = "radioButtonSmall";
            this.radioButtonSmall.TabStop = true;
            this.radioButtonSmall.UseVisualStyleBackColor = false;
            this.radioButtonSmall.CheckedChanged += new System.EventHandler(this.btnSize_CheckedChanged);
            // 
            // radioButtonMiddle
            // 
            resources.ApplyResources(this.radioButtonMiddle, "radioButtonMiddle");
            this.radioButtonMiddle.BackColor = System.Drawing.Color.Gray;
            this.radioButtonMiddle.ForeColor = System.Drawing.Color.White;
            this.radioButtonMiddle.Name = "radioButtonMiddle";
            this.radioButtonMiddle.TabStop = true;
            this.radioButtonMiddle.UseVisualStyleBackColor = false;
            this.radioButtonMiddle.CheckedChanged += new System.EventHandler(this.btnSize_CheckedChanged);
            // 
            // radioButtonLarge
            // 
            resources.ApplyResources(this.radioButtonLarge, "radioButtonLarge");
            this.radioButtonLarge.BackColor = System.Drawing.Color.Green;
            this.radioButtonLarge.ForeColor = System.Drawing.Color.White;
            this.radioButtonLarge.Name = "radioButtonLarge";
            this.radioButtonLarge.TabStop = true;
            this.radioButtonLarge.UseVisualStyleBackColor = false;
            this.radioButtonLarge.CheckedChanged += new System.EventHandler(this.btnSize_CheckedChanged);
            // 
            // labelPercent
            // 
            resources.ApplyResources(this.labelPercent, "labelPercent");
            this.labelPercent.Name = "labelPercent";
            // 
            // txtBoxStampOpacity
            // 
            resources.ApplyResources(this.txtBoxStampOpacity, "txtBoxStampOpacity");
            this.txtBoxStampOpacity.Maximum = new decimal(new int[] {
            95,
            0,
            0,
            0});
            this.txtBoxStampOpacity.Name = "txtBoxStampOpacity";
            this.txtBoxStampOpacity.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // labelWatermark
            // 
            resources.ApplyResources(this.labelWatermark, "labelWatermark");
            this.labelWatermark.Name = "labelWatermark";
            // 
            // labelStampSize
            // 
            resources.ApplyResources(this.labelStampSize, "labelStampSize");
            this.labelStampSize.Name = "labelStampSize";
            // 
            // labelStampPosition
            // 
            resources.ApplyResources(this.labelStampPosition, "labelStampPosition");
            this.labelStampPosition.Name = "labelStampPosition";
            // 
            // labelStampMenu
            // 
            resources.ApplyResources(this.labelStampMenu, "labelStampMenu");
            this.labelStampMenu.Name = "labelStampMenu";
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.BackColor = System.Drawing.Color.Green;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPrev
            // 
            resources.ApplyResources(this.btnPrev, "btnPrev");
            this.btnPrev.BackColor = System.Drawing.Color.Green;
            this.btnPrev.ForeColor = System.Drawing.Color.White;
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.UseVisualStyleBackColor = false;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.BackColor = System.Drawing.Color.Green;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FormSettings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panelStamp);
            this.Controls.Add(this.panelKimitsu);
            this.Controls.Add(this.title);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSettings_FormClosing);
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormSettings_KeyDown);
            this.panelKimitsu.ResumeLayout(false);
            this.panelKimitsu.PerformLayout();
            this.panelStamp.ResumeLayout(false);
            this.panelStamp.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtBoxStampOpacity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Panel panelKimitsu;
        private System.Windows.Forms.Label labelKimitsu;
        private System.Windows.Forms.Label lblSettei;
        private System.Windows.Forms.Label labelSttei;
        private System.Windows.Forms.Label labelStamp;
        private System.Windows.Forms.Panel panelStamp;
        private System.Windows.Forms.Label labelStampMenu;
        private System.Windows.Forms.RadioButton rdoElse;
        private System.Windows.Forms.RadioButton rdoB;
        private System.Windows.Forms.RadioButton rdoA;
        private System.Windows.Forms.RadioButton rdoS;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label labelStampPosition;
        private System.Windows.Forms.Label labelStampSize;
        private System.Windows.Forms.NumericUpDown txtBoxStampOpacity;
        private System.Windows.Forms.Label labelWatermark;
        private System.Windows.Forms.Label labelPercent;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.RadioButton radioButtonSmall;
        private System.Windows.Forms.RadioButton radioButtonMiddle;
        private System.Windows.Forms.RadioButton radioButtonLarge;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton radioButtonNotSubstitute;
        private System.Windows.Forms.RadioButton radioButtonSubstitute;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton radioButtonUpperRight;
        private System.Windows.Forms.RadioButton radioButtonUpperLeft;
        private System.Windows.Forms.LinkLabel lnkLblDoc;
    }
}

