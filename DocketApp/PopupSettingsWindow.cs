using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocketApp
{
	public partial class PopupSettingsWindow : Form
	{
		public Color fontColor, backgroundColor;
		public Font font;
		public AnchorStyles anchorLocation;

		public PopupSettingsWindow()
		{
			InitializeComponent();

			this.font = DocketApp.Properties.Settings.Default.font;
			this.fontColor = DocketApp.Properties.Settings.Default.fontColor;
			this.backgroundColor = DocketApp.Properties.Settings.Default.backgroundColor;
			this.anchorLocation = DocketApp.Properties.Settings.Default.anchorLocation;

			this.backgroundColorSelect.BackColor = backgroundColor;
			this.fontColorSelect.BackColor = fontColor;

			switch (this.anchorLocation)
			{
				case AnchorStyles.Top: //top
					dockPositionBox.SelectedItem = "Top";
					break;
				case AnchorStyles.Bottom: //bottom
					dockPositionBox.SelectedItem = "Bottom";
					break;
				case AnchorStyles.Left: //left
					dockPositionBox.SelectedItem = "Left";
					break;
				case AnchorStyles.Right: //right
					dockPositionBox.SelectedItem = "Right";
					break;
				default: // bottom
					dockPositionBox.SelectedItem = "Bottom";
					break;
			}

			this.fontSampleLabel.Font = font;
			this.fontSampleLabel.ForeColor = fontColor;

		}

		private void fontSelect_Click(object sender, EventArgs e)
		{
			FontDialog fontDialog = new FontDialog();
			fontDialog.Font = this.font;

			if (fontDialog.ShowDialog() == DialogResult.OK)
			{
				font = fontDialog.Font;
				fontColor = fontDialog.Color;

				fontSampleLabel.Font = font;
				fontSampleLabel.ForeColor = fontColor;
				fontSampleLabel.Refresh();
			}

		}

		private void backgroundColorSelect_Click(object sender, EventArgs e)
		{
			ColorDialog backgroundColorDialog = new ColorDialog();
			backgroundColorDialog.Color = backgroundColorSelect.BackColor;

			if (backgroundColorDialog.ShowDialog() == DialogResult.OK)
			{
				backgroundColor = backgroundColorDialog.Color;
				backgroundColorSelect.BackColor = backgroundColorDialog.Color;
				backgroundColorSelect.Refresh();
			}
		}

		private void fontColorSelect_Click(object sender, EventArgs e)
		{
			ColorDialog fontColorDialog = new ColorDialog();
			fontColorDialog.Color = fontColorSelect.BackColor;

			if (fontColorDialog.ShowDialog() == DialogResult.OK)
			{
				fontColor = fontColorDialog.Color;
				fontColorSelect.BackColor = fontColorDialog.Color;
				fontColorSelect.Refresh();

				fontSampleLabel.ForeColor = fontColor;
				fontSampleLabel.Refresh();
			}
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			//Save dock anchor location
			switch (dockPositionBox.SelectedItem)
			{
				case "Top":
					Console.WriteLine("make top");
					this.anchorLocation = AnchorStyles.Top;
					break;
				case "Bottom":
					this.anchorLocation = AnchorStyles.Bottom;
					break;
				case "Left":
					this.anchorLocation = AnchorStyles.Left;
					break;
				case "Right":
					this.anchorLocation = AnchorStyles.Right;
					break;
				default:
					Console.WriteLine("nothing");
					break; //Change nothing
			}

			Close();
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
