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
			this.diagnosesBio = new List<Diagnosis>();
			this.diagnosesLittle = new List<Diagnosis>();
			this.diagnosesBig = new List<Diagnosis>();
		}

		public DiagnosisAll(List<Diagnosis> diagnosesBio, List<Diagnosis> diagnosesLittle, List<Diagnosis> diagnosesBig)
		{
			this.diagnosesBio = diagnosesBio;
			this.diagnosesLittle = diagnosesLittle;
			this.diagnosesBig = diagnosesBig;
		}

		public void AddDiagnosesBio(Diagnosis diagnos)
		{
			bool exist = diagnosesBio.FindAll(o => o.GetName().Equals(diagnos.GetName())).Any();

			if (!exist)
			{
				diagnosesBio.Add(diagnos);
			}
		}

		public void AddDiagnosesLittle(Diagnosis diagnos)
		{
			bool exist = diagnosesLittle.FindAll(o => o.GetName().Equals(diagnos.GetName())).Any();

			if (!exist)
			{
				diagnosesLittle.Add(diagnos);
			}
		}

		public void AddDiagnosesBig(Diagnosis diagnos)
		{
			bool exist = diagnosesBig.FindAll(o => o.GetName().Equals(diagnos.GetName())).Any();

			if (!exist)
			{
				diagnosesBig.Add(diagnos);
			}
		}		

		public void SetDiagnosesBio(List<Diagnosis> diagnoses)
		{
			this.diagnosesBio = diagnoses;
		}

		public void SetDiagnosesLittle(List<Diagnosis> diagnoses)
		{
			this.diagnosesLittle = diagnoses;
		}

		public void setDiagnosesBig(List<Diagnosis> diagnoses)
		{
			this.diagnosesBig = diagnoses;
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
