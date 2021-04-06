using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory
{
	[Serializable]
	class Category
	{

		private string Name { get; set; }

		private DateTime RecordDate { get; set; }

		public Category(){ }

		public Category(string name)
		{ 
			this.Name = name;
			this.RecordDate = DateTime.Now;
		}

		public string GetName()
		{
			return Name;
		}

		public DateTime GetRecordDate()
		{
			return RecordDate;
		}

	}
}
