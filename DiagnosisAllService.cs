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
			diagnosesAll = new DiagnosisAll();
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

		/*public DiagnosisAll GetDiagnosisAll()
		{
			return diagnosesAll;
		}*/


	}
}
