using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory
{
	[Serializable]
	class SettingLab
	{
		private Category CategorySetting { get; set; }
		private double Category1 { get; set; }
		private double Category2 { get; set; }
		private double Category3 { get; set; }
		private double LittleOperation { get; set; }
		private double BigOperationWithout { get; set; }
		private double BigOperationWith { get; set; }

		private DateTime RecordDate { get; set; }


		public SettingLab() { }

		public SettingLab(Category categorySetting, double category1, double category2, double category3,
			double littleOperation, double bigOperationWithout, double bigOperationWith) 
		{
			this.CategorySetting = categorySetting;
			this.Category1 = category1;
			this.Category2 = category2;
			this.Category3 = category3;
			this.LittleOperation = littleOperation;
			this.BigOperationWithout = bigOperationWithout;
			this.BigOperationWith = bigOperationWith;
			this.RecordDate = DateTime.Now;
		}

		public SettingLab(SettingLab sl)
		{
			this.CategorySetting = sl.CategorySetting;
			this.Category1 = sl.Category1;
			this.Category2 = sl.Category2;
			this.Category3 = sl.Category3;
			this.LittleOperation = sl.LittleOperation;
			this.BigOperationWithout = sl.BigOperationWithout;
			this.BigOperationWith = sl.BigOperationWith;
			this.RecordDate = DateTime.Now;
		}

		public void SetCategorySetting(Category categorySetting)
		{
			this.CategorySetting = categorySetting;
			this.RecordDate = DateTime.Now;
		}		

		public void SetCategory(double category1, double category2, double category3)
		{
			this.Category1 = category1;
			this.Category2 = category2;
			this.Category3 = category3;
		}

		public void SetLittleOperation(double littleOperation)
		{
			this.LittleOperation = littleOperation;
		}

		public void SetBigOperation(double bigOperationWithout, double bigOperationWith)
		{
			this.BigOperationWithout = bigOperationWithout;
			this.BigOperationWith = bigOperationWith;
		}
		public Category GetCategorySetting() {return this.CategorySetting; }
		public double GetCategory1() { return this.Category1; }
		public double GetCategory2() { return this.Category2; }
		public double GetCategory3() { return this.Category3; }
		public double GetLittleOperation() { return this.LittleOperation; }
		public double GetBigOperationWithout() { return this.BigOperationWithout; }
		public double GetBigOperationWith() { return this.BigOperationWith; }
		public DateTime GetRecordDate() {return RecordDate;}

	}

}
