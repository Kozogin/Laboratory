using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratory
{
	static class Program
	{
		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());

			/*Category C = new Category("Oblasna");
			Diagnosis D = new Diagnosis("Corona", 350.28, C);




			D.GetInfo();*/
		}
	}
}
