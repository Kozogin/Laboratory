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
		public string Name { get; set; }
		public double Price { get; set; }
		public Category CateDiagnosis { get; set; }

		public Diagnosis(string name, double price, Category category)
		{
			this.Name = name;
			this.Price = price;
			this.CateDiagnosis = category;
		}

		public void GetInfo()
		{
			Console.WriteLine($"Name: {Name}  Price: {Price}");
		}
		
	}
}
