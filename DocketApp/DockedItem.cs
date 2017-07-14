using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Configuration;
using System.Windows.Forms;

namespace DocketApp
{
	[Serializable]
	class DockedItem
	{
		public string name { get; set; } // file/folder name
		public string path { get; set; } // file/folder full path
		public string image; // image path; empty or not found goes to default.png

		public bool folder = false;
        
		public ArrayList docklist = new ArrayList();

		public DockedItem()
		{
		}

		public DockedItem(string name) {
			this.name = name;
			this.path = "";
			this.image = "";
		}

		public void Add(DockedItem item)
		{
			docklist.Add(item);
		}
	}
}
