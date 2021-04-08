using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory
{
	[Serializable]
	class Transaction
	{		
		private Organization Org { get; set; }
		private Category Cat { get; set; }
		private TypeResearch Typ { get; set; }
		private Diagnosis Dia { get; set; }
		private Double price { get; set; }
		private string Description { get; set; }
		private DateTime RecordDate { get; set; }

		public Transaction() { }

		public Transaction(Organization org, TypeResearch typ, Diagnosis dia, string description)
		{	
			this.Org = org;
			this.Cat = Org.GetCategory();
			this.Typ = typ;
			this.Dia = dia;
			ChoisePrice();
			this.Description = description;
			this.RecordDate = DateTime.Now;
		}

		private void ChoisePrice()
		{
			SettingLabService SetService = new SettingLabService();
			SetService.ReadSettingLab();
			//try
			//{
				switch (Typ)
				{
					case TypeResearch.Category1:
						this.price = SetService.FindByCategory(Cat.GetName()).GetCategory1();
						break;
					case TypeResearch.Category2:
						this.price = SetService.FindByCategory(Cat.GetName()).GetCategory2();
						break;
					case TypeResearch.Category3:
						this.price = SetService.FindByCategory(Cat.GetName()).GetCategory3();
						break;
					case TypeResearch.LittleOperation:
						this.price = SetService.FindByCategory(Cat.GetName()).GetLittleOperation();
						break;
					case TypeResearch.BigOperationWithout:
						this.price = SetService.FindByCategory(Cat.GetName()).GetBigOperationWithout();
						break;
					case TypeResearch.BigOperationWith:
						this.price = SetService.FindByCategory(Cat.GetName()).GetBigOperationWith();
						break;
					default:
						this.price = 0;
						break;
				}
			//}
			//catch (Exception ex) { }
		}

		public void SetOrganization(Organization org)
		{
			this.Org = org;
			this.Cat = Org.GetCategory();
		}

		public void SetCategory()
		{
			this.Cat = Org.GetCategory();
			ChoisePrice();
		}

		public void SetTypeResearch(TypeResearch typ)
		{
			this.Typ = typ;
			ChoisePrice();
		}
		public void SetDiagnosis(Diagnosis dia)
		{
			this.Dia = dia;
		}
		public void SetPrice()
		{
			ChoisePrice();
		}
		public void SetPrice(double price)
		{
			this.price = price;
		}
		public void SetDescription(string description)
		{
			this.Description = description;
		}
		public Organization GetOrganization()
		{
			return Org;
		}
		public Category GetCategory()
		{
			return Cat;
		}
		public TypeResearch GetTypeResearch()
		{
			return Typ;
		}
		public Diagnosis GetDiagnosis()
		{
			return Dia;
		}

		public string GetDescription()
		{
			return Description;
		}

		public double GetPrice()
		{
			return price;
		}
		public DateTime GetRecordDate()
		{
			return RecordDate;
		}
	}
	
}
