namespace MusicDLP {
    partial class CustomDialogBox {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btnDefault2 = new System.Windows.Forms.Button();
            this.btnDefault1 = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnDefault2
            // 
            this.btnDefault2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDefault2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDefault2.Location = new System.Drawing.Point(389, 142);
            this.btnDefault2.Name = "btnDefault2";
            this.btnDefault2.Size = new System.Drawing.Size(75, 23);
            this.btnDefault2.TabIndex = 0;
            this.btnDefault2.Text = "Cancel";
            this.btnDefault2.UseVisualStyleBackColor = true;
            // 
            // btnDefault1
            // 
            this.btnDefault1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDefault1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnDefault1.Location = new System.Drawing.Point(308, 142);
            this.btnDefault1.Name = "btnDefault1";
            this.btnDefault1.Size = new System.Drawing.Size(75, 23);
            this.btnDefault1.TabIndex = 1;
            this.btnDefault1.Text = "OK";
            this.btnDefault1.UseVisualStyleBackColor = true;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(14, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(171, 46);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Loading...";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoEllipsis = true;
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(23, 74);
            this.lblMessage.MaximumSize = new System.Drawing.Size(441, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(410, 55);
            this.lblMessage.TabIndex = 3;
            this.lblMessage.Text = "The dialog box is now loading its contents...\r\n\r\nLorem ipsum dolor sit amet, cons" +
    "ectetur adipiscing elit, sed do eiusmod tempor \r\nincididunt ut labore et dolore " +
    "magna aliqua. Ut enim ad minim veniam";
            this.lblMessage.UseCompatibleTextRendering = true;
            // 
            // CustomDialogBox
            // 
            this.AcceptButton = this.btnDefault1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnDefault2;
            this.ClientSize = new System.Drawing.Size(476, 177);
            this.ControlBox = false;
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnDefault1);
            this.Controls.Add(this.btnDefault2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CustomDialogBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Loading...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDefault2;
        private System.Windows.Forms.Button btnDefault1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMessage;
    }
}