using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Laboratory
{
	class SettingLabService
	{
		private List<SettingLab> settings;

		public SettingLabService()
		{
			settings = new List<SettingLab>();
		}

		public void AddSettingLab(SettingLab setting)
		{
			bool exist = false;
			
			
			for(int i = 0; i < settings.Count - 1; i++)
			{
				try
				{
					if (settings[i].GetCategorySetting().GetName().Equals(setting.GetCategorySetting().GetName()))
				{
					exist = true;
					settings[i] = new SettingLab(setting);					
				}
				}
				catch (Exception ex) { }

			}

			if (exist == false)
			{
				settings.Add(setting);
			} 

		}

		public void SaveSettingLab()
		{
			BinaryFormatter formatter = new BinaryFormatter();
			using (FileStream fs = new FileStream("setting.dat", FileMode.OpenOrCreate))
			{
				try
				{
					formatter.Serialize(fs, settings);
				}
				catch (Exception ex) { }
			}
		}

		public void ReadSettingLab()
		{
			BinaryFormatter formatter = new BinaryFormatter();

			using (FileStream fs = new FileStream("setting.dat", FileMode.OpenOrCreate))
			{
				try
				{
					settings = (List<SettingLab>)formatter.Deserialize(fs);
				}
				catch (Exception ex) { }
			}

		}

		public SettingLab FindByCategory(string category)
		{
			try
			{
					foreach (SettingLab o in settings)
				{
					if (o.GetCategorySetting().GetName().Equals(category))
					{
						return o;
					}
				}

			}
			catch (Exception ex) { }
			return new SettingLab (new Category(category), 0, 0, 0, 0, 0, 0);
		}

		public List<SettingLab> GetSettings()
		{
			return settings;
		}

	}
}
