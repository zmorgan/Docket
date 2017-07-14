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
	public partial class PopupTextEntry : Form
	{
		public PopupTextEntry()
		{
			InitializeComponent();
		}

		string TextEntry = "";

		private void popupOkButton_Click(object sender, EventArgs e)
		{
			TextEntry = popupTextBox.Text;
			this.Close();
		}

		public string getTextBoxText()
		{
			return TextEntry;
		}

		public void setTextBoxText(string str)
		{
			popupTextBox.Text = str;
		}

		public string getLabelText()
		{
			return label.Text;
		}

		public void setLabelText(string str)
		{
			label.Text = str;
			label.Left = (this.Size.Width - label.Width)/ 2;
		}
	}



}
