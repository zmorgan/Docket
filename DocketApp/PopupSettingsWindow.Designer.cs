namespace DocketApp
{
	partial class PopupSettingsWindow
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
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.dockPositionLabel = new System.Windows.Forms.Label();
			this.dockPositionBox = new System.Windows.Forms.ComboBox();
			this.backgroundColorSelect = new System.Windows.Forms.Button();
			this.backgroundColorSelectLabel = new System.Windows.Forms.Label();
			this.fontSelectLabel = new System.Windows.Forms.Label();
			this.fontSelect = new System.Windows.Forms.Button();
			this.fontSampleLabel = new System.Windows.Forms.Label();
			this.fontColorSelect = new System.Windows.Forms.Button();
			this.fontColorSelectLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// okButton
			// 
			this.okButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Location = new System.Drawing.Point(30, 174);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 0;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(160, 175);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 1;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// dockPositionLabel
			// 
			this.dockPositionLabel.AutoSize = true;
			this.dockPositionLabel.Location = new System.Drawing.Point(12, 49);
			this.dockPositionLabel.Name = "dockPositionLabel";
			this.dockPositionLabel.Size = new System.Drawing.Size(75, 13);
			this.dockPositionLabel.TabIndex = 4;
			this.dockPositionLabel.Text = "Dock position:";
			// 
			// dockPositionBox
			// 
			this.dockPositionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.dockPositionBox.Items.AddRange(new object[] {
            "Top",
            "Bottom",
            "Left",
            "Right"});
			this.dockPositionBox.Location = new System.Drawing.Point(110, 46);
			this.dockPositionBox.MaxDropDownItems = 4;
			this.dockPositionBox.Name = "dockPositionBox";
			this.dockPositionBox.Size = new System.Drawing.Size(121, 21);
			this.dockPositionBox.TabIndex = 5;
			// 
			// backgroundColorSelect
			// 
			this.backgroundColorSelect.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.backgroundColorSelect.Location = new System.Drawing.Point(182, 122);
			this.backgroundColorSelect.Name = "backgroundColorSelect";
			this.backgroundColorSelect.Size = new System.Drawing.Size(49, 42);
			this.backgroundColorSelect.TabIndex = 7;
			this.backgroundColorSelect.UseVisualStyleBackColor = false;
			this.backgroundColorSelect.Click += new System.EventHandler(this.backgroundColorSelect_Click);
			// 
			// backgroundColorSelectLabel
			// 
			this.backgroundColorSelectLabel.AutoSize = true;
			this.backgroundColorSelectLabel.Location = new System.Drawing.Point(12, 137);
			this.backgroundColorSelectLabel.Name = "backgroundColorSelectLabel";
			this.backgroundColorSelectLabel.Size = new System.Drawing.Size(94, 13);
			this.backgroundColorSelectLabel.TabIndex = 9;
			this.backgroundColorSelectLabel.Text = "Background color:";
			this.backgroundColorSelectLabel.Click += new System.EventHandler(this.fontSelect_Click);
			// 
			// fontSelectLabel
			// 
			this.fontSelectLabel.AutoSize = true;
			this.fontSelectLabel.Location = new System.Drawing.Point(12, 14);
			this.fontSelectLabel.Name = "fontSelectLabel";
			this.fontSelectLabel.Size = new System.Drawing.Size(31, 13);
			this.fontSelectLabel.TabIndex = 10;
			this.fontSelectLabel.Text = "Font:";
			// 
			// fontSelect
			// 
			this.fontSelect.Location = new System.Drawing.Point(146, 9);
			this.fontSelect.Name = "fontSelect";
			this.fontSelect.Size = new System.Drawing.Size(85, 23);
			this.fontSelect.TabIndex = 11;
			this.fontSelect.Text = "Change font...";
			this.fontSelect.UseVisualStyleBackColor = true;
			this.fontSelect.Click += new System.EventHandler(this.fontSelect_Click);
			// 
			// fontSampleLabel
			// 
			this.fontSampleLabel.AutoSize = true;
			this.fontSampleLabel.Location = new System.Drawing.Point(63, 14);
			this.fontSampleLabel.Name = "fontSampleLabel";
			this.fontSampleLabel.Size = new System.Drawing.Size(42, 13);
			this.fontSampleLabel.TabIndex = 12;
			this.fontSampleLabel.Text = "Sample";
			// 
			// fontColorSelect
			// 
			this.fontColorSelect.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.fontColorSelect.Location = new System.Drawing.Point(182, 74);
			this.fontColorSelect.Name = "fontColorSelect";
			this.fontColorSelect.Size = new System.Drawing.Size(49, 42);
			this.fontColorSelect.TabIndex = 13;
			this.fontColorSelect.UseVisualStyleBackColor = false;
			this.fontColorSelect.Click += new System.EventHandler(this.fontColorSelect_Click);
			// 
			// fontColorSelectLabel
			// 
			this.fontColorSelectLabel.AutoSize = true;
			this.fontColorSelectLabel.Location = new System.Drawing.Point(12, 89);
			this.fontColorSelectLabel.Name = "fontColorSelectLabel";
			this.fontColorSelectLabel.Size = new System.Drawing.Size(57, 13);
			this.fontColorSelectLabel.TabIndex = 14;
			this.fontColorSelectLabel.Text = "Font color:";
			// 
			// PopupSettingsWindow
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(260, 210);
			this.Controls.Add(this.fontColorSelectLabel);
			this.Controls.Add(this.fontColorSelect);
			this.Controls.Add(this.fontSampleLabel);
			this.Controls.Add(this.fontSelect);
			this.Controls.Add(this.fontSelectLabel);
			this.Controls.Add(this.backgroundColorSelectLabel);
			this.Controls.Add(this.backgroundColorSelect);
			this.Controls.Add(this.dockPositionBox);
			this.Controls.Add(this.dockPositionLabel);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(276, 249);
			this.Name = "PopupSettingsWindow";
			this.Text = "PopupSettingsWindow";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Label dockPositionLabel;
		private System.Windows.Forms.ComboBox dockPositionBox;
		private System.Windows.Forms.Button backgroundColorSelect;
		private System.Windows.Forms.Label backgroundColorSelectLabel;
		private System.Windows.Forms.Label fontSelectLabel;
		private System.Windows.Forms.Button fontSelect;
		private System.Windows.Forms.Label fontSampleLabel;
		private System.Windows.Forms.Button fontColorSelect;
		private System.Windows.Forms.Label fontColorSelectLabel;
	}
}