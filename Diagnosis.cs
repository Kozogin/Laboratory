using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory
{
	[Serializable]
	class Diagnosis
	{
		private string Name { get; set; }		
		private string RecordDate { get; set; }

		public Diagnosis() { }

		public Diagnosis(string name)
		{
			this.Name = name;			
			this.RecordDate = DateTime.Now.ToString();			
		}

		public void SetName(string name)
		{
			this.Name = name;
			this.RecordDate = DateTime.Now.ToString();
		}		

		public string GetName()
		{
			return Name;
		}	

		public string GetRecordDate()
		{
			return RecordDate;
		}


	}
}
