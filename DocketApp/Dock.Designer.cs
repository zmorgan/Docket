namespace DocketApp
{
	partial class Dock
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
			this.lvRoot = new System.Windows.Forms.ListView();
			this.iLarge = new System.Windows.Forms.ImageList(this.components);
			this.rightClickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.editIconToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.renameFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lblCurrentPath = new System.Windows.Forms.Label();
			this.selectIcon = new System.Windows.Forms.OpenFileDialog();
			this.rightClickMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// lvRoot
			// 
			this.lvRoot.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.lvRoot.AllowDrop = true;
			this.lvRoot.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lvRoot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.lvRoot.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lvRoot.Font = new System.Drawing.Font("DejaVu Sans Condensed", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lvRoot.ForeColor = System.Drawing.Color.White;
			this.lvRoot.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.lvRoot.LargeImageList = this.iLarge;
			this.lvRoot.Location = new System.Drawing.Point(0, 0);
			this.lvRoot.Margin = new System.Windows.Forms.Padding(0);
			this.lvRoot.Name = "lvRoot";
			this.lvRoot.OwnerDraw = true;
			this.lvRoot.Size = new System.Drawing.Size(500, 100);
			this.lvRoot.SmallImageList = this.iLarge;
			this.lvRoot.TabIndex = 0;
			this.lvRoot.UseCompatibleStateImageBehavior = false;
			this.lvRoot.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.ListView_DrawItem);
			this.lvRoot.ItemActivate += new System.EventHandler(this.ListView_ItemActivate);
			this.lvRoot.DragDrop += new System.Windows.Forms.DragEventHandler(this.ListView_DragDrop);
			this.lvRoot.DragEnter += new System.Windows.Forms.DragEventHandler(this.ListView_DragEnter);
			this.lvRoot.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListView_MouseClick);
			this.lvRoot.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ListView_MouseClick);
			// 
			// iLarge
			// 
			this.iLarge.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.iLarge.ImageSize = new System.Drawing.Size(64, 64);
			this.iLarge.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// rightClickMenu
			// 
			this.rightClickMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editIconToolStripMenuItem,
            this.renameFolderToolStripMenuItem,
            this.deleteItemToolStripMenuItem,
            this.newFolderToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.rightClickMenu.Name = "rightClickMenu";
			this.rightClickMenu.Size = new System.Drawing.Size(145, 136);
			this.rightClickMenu.Tag = "";
			this.rightClickMenu.Text = "Folder Item Edit";
			// 
			// editIconToolStripMenuItem
			// 
			this.editIconToolStripMenuItem.Name = "editIconToolStripMenuItem";
			this.editIconToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.editIconToolStripMenuItem.Text = "Edit Icon";
			this.editIconToolStripMenuItem.Click += new System.EventHandler(this.editIconToolStripMenuItem_Click);
			// 
			// renameFolderToolStripMenuItem
			// 
			this.renameFolderToolStripMenuItem.Name = "renameFolderToolStripMenuItem";
			this.renameFolderToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.renameFolderToolStripMenuItem.Text = "Rename Item";
			this.renameFolderToolStripMenuItem.Click += new System.EventHandler(this.renameFolderToolStripMenuItem_Click);
			// 
			// deleteItemToolStripMenuItem
			// 
			this.deleteItemToolStripMenuItem.Name = "deleteItemToolStripMenuItem";
			this.deleteItemToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.deleteItemToolStripMenuItem.Text = "Delete Item";
			this.deleteItemToolStripMenuItem.Click += new System.EventHandler(this.deleteItemToolStripMenuItem_Click);
			// 
			// newFolderToolStripMenuItem
			// 
			this.newFolderToolStripMenuItem.Name = "newFolderToolStripMenuItem";
			this.newFolderToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.newFolderToolStripMenuItem.Text = "New Folder";
			this.newFolderToolStripMenuItem.Click += new System.EventHandler(this.newFolderToolStripMenuItem_Click);
			// 
			// settingsToolStripMenuItem
			// 
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.settingsToolStripMenuItem.Text = "Settings";
			this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// lblCurrentPath
			// 
			this.lblCurrentPath.AutoSize = true;
			this.lblCurrentPath.Location = new System.Drawing.Point(34, 22);
			this.lblCurrentPath.Name = "lblCurrentPath";
			this.lblCurrentPath.Size = new System.Drawing.Size(0, 13);
			this.lblCurrentPath.TabIndex = 2;
			// 
			// selectIcon
			// 
			this.selectIcon.FileName = "selectIcon";
			this.selectIcon.Filter = "Image Files(*.BMP; *.JPG; *.GIF; *.PNG)|*.BMP;*.JPG;*.GIF;*.PNG";
			this.selectIcon.InitialDirectory = "Environment.GetFolderPath(Environment.SpecialFolder.System)";
			this.selectIcon.Title = "Select Icon";
			// 
			// Dock
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = System.Drawing.Color.Fuchsia;
			this.ClientSize = new System.Drawing.Size(600, 100);
			this.Controls.Add(this.lvRoot);
			this.Controls.Add(this.lblCurrentPath);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "Dock";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Dock";
			this.TransparencyKey = System.Drawing.Color.Fuchsia;
			this.Load += new System.EventHandler(this.Dock_Load);
			this.rightClickMenu.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView lvRoot;
		private System.Windows.Forms.Label lblCurrentPath;
		private System.Windows.Forms.ImageList iLarge;
		private System.Windows.Forms.ContextMenuStrip rightClickMenu;
		private System.Windows.Forms.ToolStripMenuItem editIconToolStripMenuItem;
		private System.Windows.Forms.OpenFileDialog selectIcon;
		private System.Windows.Forms.ToolStripMenuItem deleteItemToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newFolderToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem renameFolderToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
	}
}

