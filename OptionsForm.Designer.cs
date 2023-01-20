namespace MusicDLP
{
    partial class OptionsForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabControlOptions = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.tabAdditionalTools = new System.Windows.Forms.TabPage();
            this.lblSeperator = new System.Windows.Forms.Label();
            this.downloadProgress = new System.Windows.Forms.ProgressBar();
            this.lblYtdlpInstalled = new System.Windows.Forms.Label();
            this.lnkLblYtdlp = new System.Windows.Forms.LinkLabel();
            this.btnDownloadYtdlp = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.cbShowOutputConsole = new System.Windows.Forms.CheckBox();
            this.cbClearPreviousOutput = new System.Windows.Forms.CheckBox();
            this.tabControlOptions.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.tabAdditionalTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(14, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(178, 48);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Options...";
            // 
            // tabControlOptions
            // 
            this.tabControlOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlOptions.Controls.Add(this.tabGeneral);
            this.tabControlOptions.Controls.Add(this.tabAdditionalTools);
            this.tabControlOptions.Location = new System.Drawing.Point(22, 68);
            this.tabControlOptions.Name = "tabControlOptions";
            this.tabControlOptions.SelectedIndex = 0;
            this.tabControlOptions.Size = new System.Drawing.Size(515, 278);
            this.tabControlOptions.TabIndex = 1;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.cbClearPreviousOutput);
            this.tabGeneral.Controls.Add(this.cbShowOutputConsole);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(507, 252);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // tabAdditionalTools
            // 
            this.tabAdditionalTools.Controls.Add(this.lblSeperator);
            this.tabAdditionalTools.Controls.Add(this.downloadProgress);
            this.tabAdditionalTools.Controls.Add(this.lblYtdlpInstalled);
            this.tabAdditionalTools.Controls.Add(this.lnkLblYtdlp);
            this.tabAdditionalTools.Controls.Add(this.btnDownloadYtdlp);
            this.tabAdditionalTools.Location = new System.Drawing.Point(4, 22);
            this.tabAdditionalTools.Name = "tabAdditionalTools";
            this.tabAdditionalTools.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdditionalTools.Size = new System.Drawing.Size(507, 252);
            this.tabAdditionalTools.TabIndex = 1;
            this.tabAdditionalTools.Text = "Additional Tools";
            this.tabAdditionalTools.UseVisualStyleBackColor = true;
            // 
            // lblSeperator
            // 
            this.lblSeperator.AutoSize = true;
            this.lblSeperator.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeperator.Location = new System.Drawing.Point(63, 13);
            this.lblSeperator.Name = "lblSeperator";
            this.lblSeperator.Size = new System.Drawing.Size(13, 17);
            this.lblSeperator.TabIndex = 5;
            this.lblSeperator.Text = "-";
            // 
            // downloadProgress
            // 
            this.downloadProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.downloadProgress.Location = new System.Drawing.Point(8, 221);
            this.downloadProgress.Name = "downloadProgress";
            this.downloadProgress.Size = new System.Drawing.Size(491, 23);
            this.downloadProgress.TabIndex = 4;
            // 
            // lblYtdlpInstalled
            // 
            this.lblYtdlpInstalled.AutoSize = true;
            this.lblYtdlpInstalled.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYtdlpInstalled.Location = new System.Drawing.Point(75, 16);
            this.lblYtdlpInstalled.Name = "lblYtdlpInstalled";
            this.lblYtdlpInstalled.Size = new System.Drawing.Size(54, 13);
            this.lblYtdlpInstalled.TabIndex = 3;
            this.lblYtdlpInstalled.Text = "Loading...";
            this.lblYtdlpInstalled.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lnkLblYtdlp
            // 
            this.lnkLblYtdlp.AutoSize = true;
            this.lnkLblYtdlp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkLblYtdlp.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkLblYtdlp.Location = new System.Drawing.Point(13, 15);
            this.lnkLblYtdlp.Name = "lnkLblYtdlp";
            this.lnkLblYtdlp.Size = new System.Drawing.Size(49, 15);
            this.lnkLblYtdlp.TabIndex = 1;
            this.lnkLblYtdlp.TabStop = true;
            this.lnkLblYtdlp.Text = "yt-dlp";
            this.lnkLblYtdlp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLblYtdlp_LinkClicked);
            // 
            // btnDownloadYtdlp
            // 
            this.btnDownloadYtdlp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownloadYtdlp.Location = new System.Drawing.Point(424, 11);
            this.btnDownloadYtdlp.Name = "btnDownloadYtdlp";
            this.btnDownloadYtdlp.Size = new System.Drawing.Size(75, 23);
            this.btnDownloadYtdlp.TabIndex = 2;
            this.btnDownloadYtdlp.Text = "Download";
            this.btnDownloadYtdlp.UseVisualStyleBackColor = true;
            this.btnDownloadYtdlp.Click += new System.EventHandler(this.btnDownloadYtdlp_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(458, 357);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(377, 357);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cbShowOutputConsole
            // 
            this.cbShowOutputConsole.AutoSize = true;
            this.cbShowOutputConsole.Location = new System.Drawing.Point(8, 8);
            this.cbShowOutputConsole.Name = "cbShowOutputConsole";
            this.cbShowOutputConsole.Size = new System.Drawing.Size(160, 17);
            this.cbShowOutputConsole.TabIndex = 0;
            this.cbShowOutputConsole.Text = "Show yt-dlp console output?";
            this.cbShowOutputConsole.UseVisualStyleBackColor = true;
            // 
            // cbClearPreviousOutput
            // 
            this.cbClearPreviousOutput.AutoSize = true;
            this.cbClearPreviousOutput.Location = new System.Drawing.Point(8, 31);
            this.cbClearPreviousOutput.Name = "cbClearPreviousOutput";
            this.cbClearPreviousOutput.Size = new System.Drawing.Size(201, 17);
            this.cbClearPreviousOutput.TabIndex = 1;
            this.cbClearPreviousOutput.Text = "Clear output pane on next operation?";
            this.cbClearPreviousOutput.UseVisualStyleBackColor = true;
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(549, 392);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tabControlOptions);
            this.Controls.Add(this.lblTitle);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(565, 431);
            this.Name = "OptionsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options...";
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            this.tabControlOptions.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabGeneral.PerformLayout();
            this.tabAdditionalTools.ResumeLayout(false);
            this.tabAdditionalTools.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TabControl tabControlOptions;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.TabPage tabAdditionalTools;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnDownloadYtdlp;
        private System.Windows.Forms.Label lblYtdlpInstalled;
        private System.Windows.Forms.LinkLabel lnkLblYtdlp;
        private System.Windows.Forms.ProgressBar downloadProgress;
        private System.Windows.Forms.Label lblSeperator;
        private System.Windows.Forms.CheckBox cbShowOutputConsole;
        private System.Windows.Forms.CheckBox cbClearPreviousOutput;
    }
}