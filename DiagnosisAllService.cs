using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Laboratory
{
	class DiagnosisAllService
	{
		private DiagnosisAll diagnosesAll;

		public DiagnosisAllService()
		{
			//diagnosesAll = new DiagnosisAll();
		}

		public void AddDiagnosis(String diagnosisStr, bool bio, bool little, bool big)
		{
			Diagnosis diagnos = new Diagnosis(diagnosisStr);			

			if (bio)
			{
				diagnosesAll.AddDiagnosesBio(diagnos);
			}
			if (little)
			{
				diagnosesAll.AddDiagnosesLittle(diagnos);
			}
			if (big)
			{
				diagnosesAll.AddDiagnosesBig(diagnos);
			}
			
		}

		public void SaveDiagnosis()
		{
			BinaryFormatter formatter = new BinaryFormatter();
			using (FileStream fs = new FileStream("diagnoses.dat", FileMode.OpenOrCreate))
			{
				try
				{
					formatter.Serialize(fs, diagnosesAll);
				}
				catch (Exception ex) { }
			}
		}

		public DiagnosisAll ReadDiagnosis()
		{
			BinaryFormatter formatter = new BinaryFormatter();

			using (FileStream fs = new FileStream("diagnoses.dat", FileMode.OpenOrCreate))
			{
				try
				{
					diagnosesAll = (DiagnosisAll)formatter.Deserialize(fs);
				}
				catch (Exception ex) { }
			}

			return diagnosesAll;

		}		

		public void DeleteDiagnosis(string diagnosisStr, bool bio, bool little, bool big)
		{	
			if (bio)
			{
				diagnosesAll.SetDiagnosesBio(diagnosesAll.GetDiagnosesBio().FindAll(o => !o.GetName().Equals(diagnosisStr)).ToList());
			}
			if (little)
			{
				diagnosesAll.SetDiagnosesLittle(diagnosesAll.GetDiagnosesLittle().FindAll(o => !o.GetName().Equals(diagnosisStr)).ToList());
			}
			if (big)
			{				
				diagnosesAll.SetDiagnosesBig(diagnosesAll.GetDiagnosesBig().FindAll(o => !o.GetName().Equals(diagnosisStr)).ToList());
			}

			SaveDiagnosis();
		}

		public Diagnosis FindDiagnosByName(string name, TypeResearch type)
		{
			Diagnosis diagnos = new Diagnosis();	

			switch (type)
			{
				case TypeResearch.Category1:
				case TypeResearch.Category2:
				case TypeResearch.Category3:
					diagnos = diagnosesAll.GetDiagnosesBio().Find(o => o.GetName().Equals(name));
					break;
				case TypeResearch.LittleOperation:
					//diagnos = diagnosesAll.GetDiagnosesLittle().Find(o => o.GetName().Equals(name));

					Console.WriteLine("************************************************************************");

					foreach (Diagnosis o in diagnosesAll.GetDiagnosesBio())
					{
						if (o.GetName().Equals(name))
						{
							diagnos = o;
							Console.WriteLine(o.GetName());
						}
					}



					break;
				case TypeResearch.BigOperationWithout:
				case TypeResearch.BigOperationWith:
					diagnos = diagnosesAll.GetDiagnosesBig().Find(o => o.GetName().Equals(name));
					break;
			}
			Console.WriteLine("++++++++ "  + " ------------------------");
			return diagnos;
		}

		public string GetTypeResearchString(TypeResearch type)
		{
			switch (type)
			{
				case TypeResearch.Category1:
					return "біопсія категорія 1";					
				case TypeResearch.Category2:
					return "біопсія категорія 2";
				case TypeResearch.Category3:
					return "біопсія категорія 3";
				case TypeResearch.LittleOperation:
					return "малий операційний";
				case TypeResearch.BigOperationWithout:
					return "вевикий операційний без лімфовузлів";
				case TypeResearch.BigOperationWith:
					return "вевикий операційний з лімфовузлами";
			}

			return null;
		}

		public DiagnosisAll GetDiagnosisAll()
		{
			return diagnosesAll;
		}


	}
}
