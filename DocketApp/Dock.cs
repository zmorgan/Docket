using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.IO;

/* 
 * TO DO:
 * 
 * Settings window
 * * Background color (if i dont end up just using an image)
 * * Text color/size/font
 * * Dock location
 * * ???
 * 
 * Make dock sit on task bar when they're on the same edge of the screen (currently sticks directly to edge, under task bar)
 * 
 * Drag and drop placement/rearrangement of items
 * Let user drag multiple items to dock
 * Hide/show dock depending on mouse movement near it
 * If user deletes a folder item whose contents are currently being displayed, remove the listview displaying those contents
 * Make item removal delete associated icon image from icon folder
 * Take icon from image thumbnail when adding image file?
 * Make dock scale size to items
 * 
 * What happens when the dock is full?
 * 
 * Folder creation, everything else about installation
 * 
 * Refine appearance in general (eg text placement, icon placement, color, etc)
 * * Center everything, scale listview size to item list, center sublistview over parent item
 * 
 * Stick app in tray instead of task bar
 * 
 * Displaying folders is kind of slow, look into that
 * Also doesn't work if you move the mouse off the icon immediately after clicking
 * * Might be a mouse down/up thing, moving the mouse before releasing it off the icon, not long enough to register as a drag instead of click?
 * Fix flickering on PositionWindow() - might be in lv.Top/Left = subListViewSpacing + 2;
 * 
 * Put in proper error messages
 * 
 * See if methods in code need more organizing?
 * 
 */

namespace DocketApp
{
	public partial class Dock : Form
	{
		static int subListViewSpacing = 15; // Pixels between each level of the dock
		static int itemRow = 110; // The width of the list views (if docking to left or right) or their height (if docking to top or bottom) 

        string iconFolder = DocketApp.Properties.Settings.Default.iconFolder;
		int iconNumber = DocketApp.Properties.Settings.Default.iconNumber;

		private ListView currentListView;
        
		private ListViewItem itemHoverItem;

		DocketAppSettings _DocketAppSettings = new DocketAppSettings();
		ArrayList dockTree = new ArrayList();

        public Dock()
        {
            InitializeComponent();
            
            DocketAppSettings _DocketAppSettings = new DocketAppSettings();
            dockTree = _DocketAppSettings.DockedItems; // Grab the stored item tree
            
            lvRoot.Tag = new ListViewTag(dockTree); // Create a tag for the root dock

			// Load settings of the root list view - background color, font, etc
			lvRoot.BackColor = DocketApp.Properties.Settings.Default.backgroundColor;
			lvRoot.ForeColor = DocketApp.Properties.Settings.Default.fontColor;
			lvRoot.Font = DocketApp.Properties.Settings.Default.font;

			currentListView = lvRoot; // Initialize this

			Settings();

		}

        private void Dock_Load(object sender, EventArgs e)
        {
            PositionWindow();
			PaintListView(lvRoot);
		}

        private void PaintListView(ListView list)
		{
            list.BeginUpdate();

			ListViewItem lvi;

			list.Clear();

            int count = 0;

            foreach (DockedItem item in ((ListViewTag)list.Tag).item.docklist) // Load the items in the item list into the listview, and their images into its image list
			{
				lvi = new ListViewItem();
				lvi.Text = item.name;

				try
				{
					FileStream fs = new FileStream(item.image, FileMode.Open);
					list.LargeImageList.Images.Add(Image.FromStream(fs));
					fs.Close();
                }
                catch // If the image file wasn't found, wasn't actually an image, etc, use the default one
				{
                    Image di = Properties.Resources.defaultIcon;
                    list.LargeImageList.Images.Add(di);
                }

                lvi.ImageIndex = list.LargeImageList.Images.Count - 1;
				lvi.Tag = (ListViewTag) new ListViewTag(item);
				list.Items.Add(lvi);
                count++;
			}

            list.EndUpdate();
		}
        
		private void ListView_ItemActivate(object sender, EventArgs e)
		{
			ListView lv = (ListView)sender;
			ListViewTag lvt = (ListViewTag)lv.Tag;
			ListViewItem lvi = lv.SelectedItems[0];
			ListViewTag lvit = (ListViewTag)lvi.Tag;
			
			if (lvit.item.folder == false)
			{
				try
				{
					// Attempt to run the file
					Console.Write("\nrunning " + lvit.item.path);
					System.Diagnostics.Process.Start(lvit.item.path);
				}
				catch
				{
					Console.Write("\ncould not open file\n");
					return;
				}
			}
			else // Make a new listview and display it
                // Might write a method for this?
			{
                if ((ListView)((ListViewTag)lv.Tag).subListView != null) cleanTree((ListView)((ListViewTag)lv.Tag).subListView);

				// Create the new list view
				ListView subListView = new ListView();

				subListView.Size = lv.Size;
				subListView.View = lv.View;
				subListView.SmallImageList = lv.SmallImageList;
                subListView.LargeImageList = lv.LargeImageList;
                subListView.Activation = lv.Activation;
				subListView.AllowDrop = lv.AllowDrop;
				subListView.ContextMenuStrip = lv.ContextMenuStrip;

                subListView.OwnerDraw = true; // Allows custom drawing of items

				subListView.Tag = new ListViewTag(lvit.item);
                
                // Appearance
                subListView.BackColor = lv.BackColor;
                subListView.Font = lv.Font;
                subListView.ForeColor = lv.ForeColor;
                subListView.BorderStyle = lv.BorderStyle;

				// Add necessary events
				subListView.ItemActivate += new System.EventHandler(this.ListView_ItemActivate);
				subListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.ListView_DragDrop);
				subListView.DragEnter += new System.Windows.Forms.DragEventHandler(this.ListView_DragEnter);
				subListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListView_MouseClick);
                subListView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ListView_MouseClick);
                subListView.DrawItem += new DrawListViewItemEventHandler(ListView_DrawItem);

				lvt.subListView = subListView;
				this.Controls.Add(subListView);

				PaintListView(subListView);
				PositionWindow();

			}
		}

		private void ListView_MouseClick(object sender, MouseEventArgs e)
		{
			ListView lv = (ListView)sender;

			if (e.Button != MouseButtons.Right && lv.GetItemAt(e.X, e.Y) != null) return;

			if (e.Button == MouseButtons.Right)
			{
				if (lv.GetItemAt(e.X, e.Y) != null) // if the click is on an item
				{
                    // The item will be focused, put it in the global variable for potential editing
                    itemHoverItem = lv.FocusedItem;
					rightClickMenu.Items[0].Visible = true;
					rightClickMenu.Items[1].Visible = true;
					rightClickMenu.Items[2].Visible = true;
				}
				else // Hide item-specific options
				{
					rightClickMenu.Items[0].Visible = false;
					rightClickMenu.Items[1].Visible = false;
					rightClickMenu.Items[2].Visible = false;
				}
				rightClickMenu.Show(Cursor.Position);
			}
            else { // Any other mouse button (probably left)
                ListView slv = (ListView)((ListViewTag)lv.Tag).subListView;
                if (slv != null) cleanTree(slv);
            }
            currentListView = lv;
		}

        private void ListView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            ListViewItem lvi = e.Item; // The item to draw
            Image img = lvi.ImageList.Images[lvi.ImageIndex]; // The image of the item

            int center = e.Bounds.Width/2 + e.Bounds.Left; // The horizontal center of the item's rectangle

            e.Graphics.DrawImageUnscaled(img, new Point(center-img.Width/2,e.Bounds.Y+e.Bounds.Height/10)); // draws the image

            // Draw the text in the bottom center of the item's rectangle
            e.DrawText(TextFormatFlags.Bottom | TextFormatFlags.HorizontalCenter);
        }

        private void editIconToolStripMenuItem_Click(object sender, EventArgs e)
		{
			bool reopen = true;
			while (reopen) {
				if (selectIcon.ShowDialog() == DialogResult.OK)
				{
					try
					{
						Image img = Image.FromFile(selectIcon.FileName); // Check if the file name is an image
                                                                         // Dialog only gives image files as options but user can still enter any file manually

						setDockedItemImage(img, ((ListViewTag)itemHoverItem.Tag).item);

						Save(itemHoverItem.ListView);
						reopen = false;
					}
					catch (Exception err)
					{
						Console.Write(err.Message);
						Console.WriteLine();
						MessageBox.Show("Must select an image file.");
					}
				}
				else // If the dialog was canceled, for example
				{
					reopen = false;
				}
			}
		}

		private void deleteItemToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ListViewItem lvi = itemHoverItem;
			ListView lv = lvi.ListView;
			ArrayList list = ((ListViewTag)lv.Tag).item.docklist;

			list.Remove(((ListViewTag)lvi.Tag).item);

			Save(lv);
		}

		private void newFolderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ListView lv = currentListView;
			ListViewTag lvt = (ListViewTag)lv.Tag;

			PopupTextEntry popup = new PopupTextEntry();
			popup.Text = "Enter Folder Name";
			popup.setTextBoxText("New Folder");
            if (popup.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            DockedItem folder = new DockedItem(popup.getTextBoxText());

            Image di = Properties.Resources.defaultIcon;

            setDockedItemImage(di, folder);

            folder.folder = true;

			lvt.item.docklist.Add(folder);

			Save(lv);
		}

		private void renameFolderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DockedItem item = (DockedItem)((ListViewTag)itemHoverItem.Tag).item;
	
			// Let the user enter a new (non-empty) name
			PopupTextEntry popup = new PopupTextEntry();
			popup.Text = "Enter Item Name";
			popup.ShowDialog();
			if (popup.getTextBoxText() != "") item.name = popup.getTextBoxText();

			Save(itemHoverItem.ListView);
		}


		private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PopupSettingsWindow swindow = new PopupSettingsWindow();

			if (swindow.ShowDialog() == DialogResult.OK)
			{
				// Save the settings
				DocketApp.Properties.Settings.Default.font = swindow.font;
				DocketApp.Properties.Settings.Default.fontColor = swindow.fontColor;
				DocketApp.Properties.Settings.Default.backgroundColor = swindow.backgroundColor;
				DocketApp.Properties.Settings.Default.anchorLocation = swindow.anchorLocation;

				DocketApp.Properties.Settings.Default.Save();
				DocketApp.Properties.Settings.Default.Reload();

				// Apply them to all ListView controls and repaint all ListView controls
				ListView lv;
				foreach (Control c in this.Controls)
				{
					if (c is ListView)
					{
						lv = (ListView)c;
						lv.Font = swindow.font;
						lv.ForeColor = swindow.fontColor;
						lv.BackColor = swindow.backgroundColor;


						lv.Refresh();
					}
				}
				PositionWindow();
			}
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Maybe add a confirmation here?
            Application.Exit();
        }

		private void ListView_DragDrop(object sender, DragEventArgs e)
		{
			ListView lv = (ListView)sender;
			ListViewTag lvt = (ListViewTag)lv.Tag;

			string[] file = {};

			DockedItem item = new DockedItem();
			FileInfo fi;

			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				file = (string[])e.Data.GetData(DataFormats.FileDrop);
			}

			foreach (string str in file)
			{
				item.path = str;
				Image img = Icon.ExtractAssociatedIcon(str).ToBitmap();
				setDockedItemImage(img, item);

				fi = new FileInfo(str);
				item.name = fi.Name;

				if (lv == lvRoot)
				{
					dockTree.Insert(dockTree.Count, item);
				}
				else
				{
					lvt.item.Add(item);
				}
			}
			Save(lv);
		}

		private void ListView_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.All;
		}

		private void setDockedItemImage(Image img, DockedItem item)
		{
            string newImagePath = iconFolder + "\\icon" + DocketApp.Properties.Settings.Default.iconNumber + Path.GetExtension(selectIcon.FileName);
            try
            {
                img.Save(newImagePath);
            }

            catch // Initial creation can be shifted to install
                    // So this should only ever execute if the directory has been deleted or the user changes it in the settings
            {
                System.IO.Directory.CreateDirectory(iconFolder);
                img.Save(newImagePath);
            }

			DocketApp.Properties.Settings.Default.iconNumber++;
			DocketApp.Properties.Settings.Default.Save();
			item.image = newImagePath;
		}


        private void cleanTree(ListView lv) {

            // Attempts to remove the current ListView and all of its children, recursively

            if (((ListViewTag)lv.Tag).subListView != null) cleanTree(((ListViewTag)lv.Tag).subListView);
            this.Controls.Remove((Control)lv);

			PositionWindow();
        }


        private void PositionWindow()
        {
			// Resizes and positions containing window on screen

			Rectangle controlRect = Screen.FromControl(lvRoot).Bounds;

            ListView lv;

            switch (DocketApp.Properties.Settings.Default.anchorLocation)
            {
                case AnchorStyles.Bottom:
                    this.Height = 2; // Can't set a non-empty form to 0 height, will set to 2 as minimum
                    foreach (Control c in this.Controls)
                    {
						if (c is ListView) {
							lv = (ListView)c;
							lv.Size = new Size(itemRow * 6, itemRow); // Placeholder size; need to implement resizing based on # of items
							lv.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
                            this.Height += (lv.Height + subListViewSpacing);
                            lv.Top = subListViewSpacing + 2; // Account for min height being 2
							lv.Left = 0;
							if (lv.Width > this.Width) this.Width = lv.Width;
                        }
                    }
                    this.Height -= 2; // Subtract the 2 here
                    this.Top = controlRect.Bottom - this.Height;
                    this.Left = (controlRect.Right - this.Width) / 2;
                    break;

                case AnchorStyles.Right:
                    this.Width = 2;
                    foreach (Control c in this.Controls)
                    {
                        if (c is ListView)
                        {
                            lv = (ListView)c;
							lv.Size = new Size(itemRow, itemRow * 6);
							lv.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                            this.Width += (lv.Width + subListViewSpacing);
                            lv.Left = subListViewSpacing + 2;
							lv.Top = 0;
							if (lv.Height > this.Height) this.Height = lv.Height;
                        }
                    }
                    this.Width -= 2;
                    this.Left = controlRect.Right - this.Width;
                    this.Top = (controlRect.Bottom - this.Height) / 2;
                    break;

                case AnchorStyles.Top:
                    this.Height = 2;
                    foreach (Control c in this.Controls)
                    {
						if (c is ListView)
						{
							lv = (ListView)c;
							lv.Size = new Size(itemRow * 6, itemRow);
							lv.Top = this.Height - 2;
                            lv.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                            this.Height += (lv.Height + subListViewSpacing);
							lv.Left = 0;
                            if (lv.Width > this.Width) this.Width = lv.Width;
                        }
					}
                    this.Height -= 2;
                    this.Top = 0;
                    this.Left = (controlRect.Right - this.Width) / 2;
					break;

                case AnchorStyles.Left:
                    this.Width = 2;
                    foreach (Control c in this.Controls)
                    {
						if (c is ListView)
						{
							lv = (ListView)c;
							lv.Size = new Size(itemRow, itemRow * 6);
							lv.Left  = this.Width - 2;
                            lv.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                            this.Width += (lv.Width + subListViewSpacing);
							lv.Top = 0;
                            if (lv.Height > this.Height) this.Height = lv.Height;
						}
					}
                    this.Width -= 2;
                    this.Left = 0;
                    this.Top = (controlRect.Bottom - this.Height) / 2;
                    break;

                default: // Defaults to bottom
                    this.Height = 2;
                    foreach (Control c in this.Controls)
                    {
                        if (c is ListView)
                        {
                            lv = (ListView)c;
                            lv.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
                            this.Height += (lv.Height + subListViewSpacing);
                            lv.Top = subListViewSpacing + 2;
                            if (lv.Width > this.Width) this.Width = lv.Width;
                        }
                    }
                    this.Height -= 2;
                    this.Top = controlRect.Bottom - this.Height;
                    this.Left = (controlRect.Right - this.Width) / 2;
                    break;
            }
		}
		
        private void Save(ListView lv) // Saves current version of the item tree and repaints the passed list view, which may have been edited
		{
			_DocketAppSettings.DockedItems = dockTree;
			_DocketAppSettings.Save();
			_DocketAppSettings.Reload();
			PaintListView(lv);
		}

		private void Settings()
		{
			// Temporary method that asks for certain settings on startup
			// These will eventually go in either the settings window or be selected at install
			
			PopupTextEntry p = new PopupTextEntry();

			p.Text = "Enter Directory for Icon Storage";
			p.setLabelText("Doesn't check access.");
			p.setTextBoxText(DocketApp.Properties.Settings.Default.iconFolder);
			if (p.ShowDialog() != DialogResult.Cancel)
			{
				DocketApp.Properties.Settings.Default.iconFolder = p.getTextBoxText();
			}
			DocketApp.Properties.Settings.Default.Save();
			DocketApp.Properties.Settings.Default.Reload();
		}
	}
}

