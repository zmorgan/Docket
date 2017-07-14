namespace DocketApp
{
	partial class PopupTextEntry
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
            this.popupTextBox = new System.Windows.Forms.TextBox();
            this.popupOkButton = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // popupTextBox
            // 
            this.popupTextBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.popupTextBox.Location = new System.Drawing.Point(12, 31);
            this.popupTextBox.Name = "popupTextBox";
            this.popupTextBox.Size = new System.Drawing.Size(335, 20);
            this.popupTextBox.TabIndex = 0;
            // 
            // popupOkButton
            // 
            this.popupOkButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.popupOkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.popupOkButton.Location = new System.Drawing.Point(140, 57);
            this.popupOkButton.Name = "popupOkButton";
            this.popupOkButton.Size = new System.Drawing.Size(75, 23);
            this.popupOkButton.TabIndex = 1;
            this.popupOkButton.Text = "OK";
            this.popupOkButton.UseVisualStyleBackColor = true;
            this.popupOkButton.Click += new System.EventHandler(this.popupOkButton_Click);
            // 
            // label
            // 
            this.label.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(167, 9);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(0, 13);
            this.label.TabIndex = 2;
            // 
            // PopupTextEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 87);
            this.Controls.Add(this.label);
            this.Controls.Add(this.popupOkButton);
            this.Controls.Add(this.popupTextBox);
            this.Name = "PopupTextEntry";
            this.Text = "Enter Text";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox popupTextBox;
		private System.Windows.Forms.Button popupOkButton;
		private System.Windows.Forms.Label label;
	}
}