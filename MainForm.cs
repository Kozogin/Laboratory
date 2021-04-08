using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Laboratory
{
	
	public partial class MainForm : Form
	{
		private OrganizationService OrgServise;
		private DiagnosisAllService DiaAllService;
		private TransactionService traService;

		public MainForm()
		{
			InitializeComponent();
			OrgServise = new OrganizationService();
			DiaAllService = new DiagnosisAllService();
			traService = new TransactionService();
		}

		public MainForm(CreateForm f)
		{
			InitializeComponent();
			OrgServise = new OrganizationService();
			DiaAllService = new DiagnosisAllService();
			traService = new TransactionService();
			//f.BackColor = Color.Green;
		}		

		private void butAdd_Click(object sender, EventArgs e)
		{			
			CreateForm createForm = new CreateForm(this);
			createForm.Show();
		}
		

		private void MainForm_Activated(object sender, EventArgs e)
		{
			DiaAllService.ReadDiagnosis();
			dateCalendar.Value = DateTime.Now;			

			cmbOrganization.Items.Clear();
			foreach (Organization o in OrgServise.GetOrganizations())
			{
				cmbOrganization.Items.Add(o.GetName());
			}

			DiagnosisAll diaAll = DiaAllService.GetDiagnosisAll();

			cmdDiagnosisBio.Items.Clear();
			foreach (Diagnosis o in diaAll.GetDiagnosesBio())
			{
				cmdDiagnosisBio.Items.Add(o.GetName());
			}

			cmdDiagnosisLitt.Items.Clear();
			foreach (Diagnosis o in diaAll.GetDiagnosesLittle())
			{
				cmdDiagnosisLitt.Items.Add(o.GetName());
			}

			cmdDiagnosisBig.Items.Clear();
			foreach (Diagnosis o in diaAll.GetDiagnosesBig())
			{
				cmdDiagnosisBig.Items.Add(o.GetName());
			}

			dateCalendar.Value = DateTime.Now;

			showTransaction();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			OrgServise.ReadOrganization();
			DiaAllService.ReadDiagnosis();
			traService.ReadTransaction();
		}

		private void btnSetting_Click(object sender, EventArgs e)
		{
			SettingForm settingForm = new SettingForm(this);
			settingForm.Show();
		}

		

		private void butSpendLittle_Click(object sender, EventArgs e){

			string description = txtDescription.Text;
			Organization org = OrgServise.FindByIndex(cmbOrganization.SelectedIndex);	
			Diagnosis dia = DiaAllService.FindDiagnosByName(cmdDiagnosisLitt.SelectedText, TypeResearch.LittleOperation);
			Transaction transaction = new Transaction(org, TypeResearch.LittleOperation, dia, description);

			traService.AddTransaction(transaction);
			traService.SaveTransaction();

			cmbOrganization.Text = "Виберіть організацію";
			cmdDiagnosisLitt.Text = "Виберіть діагноз";
			txtDescription.Text = "";

			showTransaction();
		}

		private void cmbOrganization_SelectedIndexChanged(object sender, EventArgs e)
		{			
			lblCategoryOrg.Text = OrgServise.FindByIndex(cmbOrganization.SelectedIndex).GetCategory().GetName();
		}

		private void showTransaction()
		{
			txtBResult.Text = "";
			string rezultText = "";
			int lastIndexTransaction = traService.GetTransactions().Count() - 1;
			int stopIndexTransaction = lastIndexTransaction - 50;
			stopIndexTransaction = stopIndexTransaction < 0 ? 0 : stopIndexTransaction;

			//try
			//{
				for (int i = lastIndexTransaction; i >= stopIndexTransaction; i--)
				{
					TypeResearch type = traService.GetTransactions()[i].GetTypeResearch();

					string org = traService.GetTransactions()[i].GetOrganization().GetName();
					string cat = traService.GetTransactions()[i].GetOrganization().GetCategory().GetName();
					string typ = DiaAllService.GetTypeResearchString(type);
				string dia = "";
					try
					{
						dia = traService.GetTransactions()[i].GetDiagnosis().GetName();
					}
					catch (Exception ex) { }

				string price = traService.GetTransactions()[i].GetPrice().ToString();
					string descr = traService.GetTransactions()[i].GetDescription();
					string dat = traService.GetTransactions()[i].GetRecordDate().ToString();

					rezultText += dat + "  <" + org + ">  (" + cat + ")  " + typ + "  " + dia + "  " + price + "грн.  " + descr + "\r\n";
				}
			//}
			//catch (Exception ex) { }
			txtBResult.Text = rezultText;
		}



	}
	
}
