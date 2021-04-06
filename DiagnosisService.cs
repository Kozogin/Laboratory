using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Laboratory
{
	class DiagnosisService
	{
		private List<Diagnosis> diagnoses;

		public DiagnosisService()
		{
			diagnoses = new List<Diagnosis>();
		}

		public void AddDiagnosis(String diagnosisStr)
		{
			Diagnosis diagnosis = new Diagnosis(diagnosisStr);
			diagnoses.Add(diagnosis);
		}

		public void SaveDiagnosis()
		{
			BinaryFormatter formatter = new BinaryFormatter();
			using (FileStream fs = new FileStream("diagnoses.dat", FileMode.OpenOrCreate))
			{
				try { 
				formatter.Serialize(fs, diagnoses);
				}
				catch (Exception ex) { }
			}
		}

		public void ReadDiagnosis()
		{
			BinaryFormatter formatter = new BinaryFormatter();

			using (FileStream fs = new FileStream("diagnoses.dat", FileMode.OpenOrCreate))
			{
				try
				{
					diagnoses = (List<Diagnosis>)formatter.Deserialize(fs);
				}
				catch (Exception ex) { }
			}

		}

		public List<Diagnosis> GetDiagnosis()
		{
			return diagnoses;
		}

	}
}
