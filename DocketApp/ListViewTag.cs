using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace DocketApp
{
	class ListViewTag
	{
        // each ListView is given an instance of this class as its tag

		public DockedItem item = new DockedItem();
		public ListView subListView; // the ListView being displayed below this one. used for clearTree()
		public string name = "";


		public ListViewTag(ArrayList display)
		{
			item.docklist = display;
		}

		public ListViewTag(DockedItem i)
		{
			name = "hi!!";
			item = i;
		}

	}
}
