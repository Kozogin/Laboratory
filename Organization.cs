using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory
{
	[Serializable]
	class Organization
	{
		private string Name { get; set; }

		private DateTime RecordDate { get; set; }

		private Category CategoryOrg { get; set; }

		public Organization() { }

		public Organization(string name, Category categoryOrg)
		{
			this.Name = name;
			this.CategoryOrg = categoryOrg;
			this.RecordDate = DateTime.Now;
		}

		public string GetName()
		{
			return Name;
		}

		public Category GetCategory()
		{
			return CategoryOrg;
		}

		public DateTime GetRecordDate()
		{
			return RecordDate;
		}

	}
}
