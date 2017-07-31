using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DocketApp
{
	class DocketAppSettings : ApplicationSettingsBase
	{
		[UserScopedSetting()]
		[SettingsSerializeAs(System.Configuration.SettingsSerializeAs.Binary)]
		[DefaultSettingValue("")]

		public System.Collections.ArrayList DockedItems // the entire tree of docked items, as a list
		{
			get
			{
				return ((System.Collections.ArrayList)this["DockedItems"]);
			}
			set
			{
				this["DockedItems"] = (System.Collections.ArrayList)value;
			}
		}
	}
}
