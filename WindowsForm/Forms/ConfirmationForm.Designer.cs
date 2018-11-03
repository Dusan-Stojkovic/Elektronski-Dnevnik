namespace WindowsForms
{
    partial class ConfirmationForm
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
            this.YesButton = new System.Windows.Forms.Button();
            this.WarningDialog = new System.Windows.Forms.Label();
            this.NoButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // YesButton
            // 
            this.YesButton.Location = new System.Drawing.Point(46, 128);
            this.YesButton.Name = "YesButton";
            this.YesButton.Size = new System.Drawing.Size(75, 23);
            this.YesButton.TabIndex = 0;
            this.YesButton.Text = "Yes";
            this.YesButton.UseVisualStyleBackColor = true;
            this.YesButton.Click += new System.EventHandler(this.YesButton_Click);
            // 
            // WarningDialog
            // 
            this.WarningDialog.AutoSize = true;
            this.WarningDialog.Location = new System.Drawing.Point(43, 21);
            this.WarningDialog.Name = "WarningDialog";
            this.WarningDialog.Size = new System.Drawing.Size(169, 13);
            this.WarningDialog.TabIndex = 1;
            this.WarningDialog.Text = "You are about to do the following: ";
            // 
            // NoButton
            // 
            this.NoButton.Location = new System.Drawing.Point(146, 127);
            this.NoButton.Name = "NoButton";
            this.NoButton.Size = new System.Drawing.Size(75, 23);
            this.NoButton.TabIndex = 2;
            this.NoButton.Text = "No";
            this.NoButton.UseVisualStyleBackColor = true;
            this.NoButton.Click += new System.EventHandler(this.NoButton_Click);
            // 
            // ConfirmationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 173);
            this.Controls.Add(this.NoButton);
            this.Controls.Add(this.WarningDialog);
            this.Controls.Add(this.YesButton);
            this.Name = "ConfirmationForm";
            this.Text = "ConfirmationForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button YesButton;
        private System.Windows.Forms.Label WarningDialog;
        private System.Windows.Forms.Button NoButton;
    }
}