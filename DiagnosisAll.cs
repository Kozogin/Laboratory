using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory
{
	[Serializable]
	class DiagnosisAll
	{
		private List<Diagnosis> diagnosesBio;
		private List<Diagnosis> diagnosesLittle;
		private List<Diagnosis> diagnosesBig;
		
		public DiagnosisAll() 
		{
			diagnosesBio = new List<Diagnosis>();
			diagnosesLittle = new List<Diagnosis>();
			diagnosesBig = new List<Diagnosis>();
		}

		public DiagnosisAll(List<Diagnosis> diagnosesBiol, List<Diagnosis> diagnosesLittlel, List<Diagnosis> diagnosesBigl)
		{
			diagnosesBio = diagnosesBiol;
			diagnosesLittle = diagnosesLittlel;
			diagnosesBig = diagnosesBigl;
		}

		public void AddDiagnosesBio(Diagnosis diagnos)
		{
			bool exist = diagnosesBio.FindAll(o => o.GetName().Equals(diagnos.GetName())).Any();

			if (!exist)
			{
				diagnosesBio.Add(diagnos);
				diagnosesBio = diagnosesBio.OrderBy(u => u.GetName()).ToList();
			}
		}

		public void AddDiagnosesLittle(Diagnosis diagnos)
		{
			bool exist = diagnosesLittle.FindAll(o => o.GetName().Equals(diagnos.GetName())).Any();

			if (!exist)
			{
				diagnosesLittle.Add(diagnos);
				diagnosesLittle = diagnosesLittle.OrderBy(u => u.GetName()).ToList();
			}
		}

		public void AddDiagnosesBig(Diagnosis diagnos)
		{
			bool exist = diagnosesBig.FindAll(o => o.GetName().Equals(diagnos.GetName())).Any();

			if (!exist)
			{
				diagnosesBig.Add(diagnos);
				diagnosesBig = diagnosesBig.OrderBy(u => u.GetName()).ToList();
			}
		}		

		public void SetDiagnosesBio(List<Diagnosis> diagnoses)
		{			
			diagnosesBio = diagnoses;
		}

		public void SetDiagnosesLittle(List<Diagnosis> diagnoses)
		{
			diagnosesLittle = diagnoses;
		}

		public void SetDiagnosesBig(List<Diagnosis> diagnoses)
		{
			diagnosesBig = diagnoses;
		}


		public List<Diagnosis> GetDiagnosesBio()
		{
			return diagnosesBio;
		}

		public List<Diagnosis> GetDiagnosesLittle()
		{
			return diagnosesLittle;
		}

		public List<Diagnosis> GetDiagnosesBig()
		{
			return diagnosesBig;
		}

	}
}
