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
		public string Name { get; set; }

		public string RecordDate { get; set; }

		public Organization(string name)
		{
			this.Name = name;
			this.RecordDate = DateTime.Now.ToString();
		}

	}
}
