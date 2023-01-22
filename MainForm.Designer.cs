namespace MusicDLP
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lblTitle = new System.Windows.Forms.Label();
            this.rtbOutput = new System.Windows.Forms.RichTextBox();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadProgress = new System.Windows.Forms.ProgressBar();
            this.btnChooseDownloadFolder = new System.Windows.Forms.Button();
            this.lblDownloadFolder = new System.Windows.Forms.Label();
            this.lblUrl = new System.Windows.Forms.Label();
            this.txtDownloadFolder = new System.Windows.Forms.TextBox();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.btnStartDownload = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOptions = new System.Windows.Forms.Button();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageDownloader = new System.Windows.Forms.TabPage();
            this.tabPageConverter = new System.Windows.Forms.TabPage();
            this.contextMenu.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPageDownloader.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(6, 17);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(319, 83);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "MusicDLP";
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // rtbOutput
            // 
            this.rtbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbOutput.BackColor = System.Drawing.SystemColors.InfoText;
            this.rtbOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbOutput.ContextMenuStrip = this.contextMenu;
            this.rtbOutput.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbOutput.ForeColor = System.Drawing.SystemColors.Window;
            this.rtbOutput.Location = new System.Drawing.Point(20, 308);
            this.rtbOutput.Margin = new System.Windows.Forms.Padding(5);
            this.rtbOutput.Name = "rtbOutput";
            this.rtbOutput.ReadOnly = true;
            this.rtbOutput.Size = new System.Drawing.Size(715, 114);
            this.rtbOutput.TabIndex = 6;
            this.rtbOutput.Text = "[log start]";
            this.rtbOutput.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtbOutput_LinkClicked);
            this.rtbOutput.TextChanged += new System.EventHandler(this.rtbOutput_TextChanged);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyLogToolStripMenuItem,
            this.clearLogToolStripMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(199, 48);
            // 
            // copyLogToolStripMenuItem
            // 
            this.copyLogToolStripMenuItem.Name = "copyLogToolStripMenuItem";
            this.copyLogToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyLogToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.copyLogToolStripMenuItem.Text = "Copy Log";
            this.copyLogToolStripMenuItem.Click += new System.EventHandler(this.copyLogToolStripMenuItem_Click);
            // 
            // clearLogToolStripMenuItem
            // 
            this.clearLogToolStripMenuItem.Name = "clearLogToolStripMenuItem";
            this.clearLogToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.C)));
            this.clearLogToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.clearLogToolStripMenuItem.Text = "Clear Log";
            this.clearLogToolStripMenuItem.Click += new System.EventHandler(this.clearLogToolStripMenuItem_Click);
            // 
            // downloadProgress
            // 
            this.downloadProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.downloadProgress.Location = new System.Drawing.Point(20, 430);
            this.downloadProgress.MarqueeAnimationSpeed = 5;
            this.downloadProgress.Name = "downloadProgress";
            this.downloadProgress.Size = new System.Drawing.Size(715, 23);
            this.downloadProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.downloadProgress.TabIndex = 5;
            // 
            // btnChooseDownloadFolder
            // 
            this.btnChooseDownloadFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChooseDownloadFolder.Location = new System.Drawing.Point(627, 37);
            this.btnChooseDownloadFolder.Name = "btnChooseDownloadFolder";
            this.btnChooseDownloadFolder.Size = new System.Drawing.Size(71, 22);
            this.btnChooseDownloadFolder.TabIndex = 4;
            this.btnChooseDownloadFolder.Text = "Choose...";
            this.btnChooseDownloadFolder.UseVisualStyleBackColor = true;
            this.btnChooseDownloadFolder.Click += new System.EventHandler(this.btnChooseDownloadFolder_Click);
            // 
            // lblDownloadFolder
            // 
            this.lblDownloadFolder.AutoSize = true;
            this.lblDownloadFolder.Location = new System.Drawing.Point(12, 42);
            this.lblDownloadFolder.Name = "lblDownloadFolder";
            this.lblDownloadFolder.Size = new System.Drawing.Size(70, 13);
            this.lblDownloadFolder.TabIndex = 3;
            this.lblDownloadFolder.Text = "Download to:";
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(50, 17);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(32, 13);
            this.lblUrl.TabIndex = 2;
            this.lblUrl.Text = "URL:";
            // 
            // txtDownloadFolder
            // 
            this.txtDownloadFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDownloadFolder.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtDownloadFolder.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.txtDownloadFolder.Location = new System.Drawing.Point(87, 38);
            this.txtDownloadFolder.Name = "txtDownloadFolder";
            this.txtDownloadFolder.Size = new System.Drawing.Size(538, 20);
            this.txtDownloadFolder.TabIndex = 1;
            this.txtDownloadFolder.TextChanged += new System.EventHandler(this.txtDownloadFolder_TextChanged);
            // 
            // txtUrl
            // 
            this.txtUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUrl.Location = new System.Drawing.Point(87, 13);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(610, 20);
            this.txtUrl.TabIndex = 0;
            this.txtUrl.Text = "https://www.youtube.com/watch?v=dQw4w9WgXcQ";
            this.txtUrl.TextChanged += new System.EventHandler(this.txtUrl_TextChanged);
            // 
            // btnStartDownload
            // 
            this.btnStartDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartDownload.Location = new System.Drawing.Point(658, 463);
            this.btnStartDownload.Name = "btnStartDownload";
            this.btnStartDownload.Size = new System.Drawing.Size(78, 30);
            this.btnStartDownload.TabIndex = 4;
            this.btnStartDownload.Text = "Start";
            this.btnStartDownload.UseVisualStyleBackColor = true;
            this.btnStartDownload.Click += new System.EventHandler(this.btnStartDownload_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(575, 463);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(78, 30);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOptions
            // 
            this.btnOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOptions.Location = new System.Drawing.Point(19, 462);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(78, 30);
            this.btnOptions.TabIndex = 2;
            this.btnOptions.Text = "Options";
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMain.Controls.Add(this.tabPageDownloader);
            this.tabControlMain.Controls.Add(this.tabPageConverter);
            this.tabControlMain.Location = new System.Drawing.Point(19, 104);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(717, 197);
            this.tabControlMain.TabIndex = 5;
            // 
            // tabPageDownloader
            // 
            this.tabPageDownloader.Controls.Add(this.txtUrl);
            this.tabPageDownloader.Controls.Add(this.txtDownloadFolder);
            this.tabPageDownloader.Controls.Add(this.btnChooseDownloadFolder);
            this.tabPageDownloader.Controls.Add(this.lblUrl);
            this.tabPageDownloader.Controls.Add(this.lblDownloadFolder);
            this.tabPageDownloader.Location = new System.Drawing.Point(4, 22);
            this.tabPageDownloader.Name = "tabPageDownloader";
            this.tabPageDownloader.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDownloader.Size = new System.Drawing.Size(709, 171);
            this.tabPageDownloader.TabIndex = 0;
            this.tabPageDownloader.Text = "Downloader";
            this.tabPageDownloader.UseVisualStyleBackColor = true;
            // 
            // tabPageConverter
            // 
            this.tabPageConverter.Location = new System.Drawing.Point(4, 22);
            this.tabPageConverter.Name = "tabPageConverter";
            this.tabPageConverter.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageConverter.Size = new System.Drawing.Size(709, 171);
            this.tabPageConverter.TabIndex = 1;
            this.tabPageConverter.Text = "Converter";
            this.tabPageConverter.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(753, 508);
            this.Controls.Add(this.rtbOutput);
            this.Controls.Add(this.downloadProgress);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.btnOptions);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnStartDownload);
            this.Controls.Add(this.lblTitle);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(667, 490);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MusicDLP";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.contextMenu.ResumeLayout(false);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageDownloader.ResumeLayout(false);
            this.tabPageDownloader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnStartDownload;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnChooseDownloadFolder;
        private System.Windows.Forms.Label lblDownloadFolder;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.TextBox txtDownloadFolder;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.ProgressBar downloadProgress;
        private System.Windows.Forms.Button btnOptions;
        private System.Windows.Forms.RichTextBox rtbOutput;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem copyLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearLogToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageDownloader;
        private System.Windows.Forms.TabPage tabPageConverter;
    }
}

