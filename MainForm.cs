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

			List<Transaction> transactions = traService.GetTransactions();
			transactions = transactions.OrderBy(o => o.GetId()).ToList();
			traService.SetTransaction(transactions);


			int lastIndex = 0;
			int countTransaction = traService.GetTransactions().Count();
			lastIndex = traService.GetTransactions()[countTransaction - 1].GetId();
			Transaction.SetCountId(lastIndex/10 + 1);
		}

		private void btnSetting_Click(object sender, EventArgs e)
		{
			SettingForm settingForm = new SettingForm(this);
			settingForm.Show();
		}

		private void butSpendBio_Click(object sender, EventArgs e)
		{
			bool boolBioCat1 = rdoCategory1.Checked;
			bool boolBioCat2 = rdoCategory2.Checked;
			bool boolBioCat3 = rdoCategory3.Checked;
			DateTime recordDate = dateCalendar.Value;

			if (cmbOrganization.SelectedIndex != -1 && cmdDiagnosisBio.SelectedIndex != -1)
			{
				string description = txtDescription.Text;
				Organization org = OrgServise.FindByIndex(cmbOrganization.SelectedIndex);
				Transaction transaction = new Transaction(); ;

				if (boolBioCat1)
				{
					Diagnosis dia = DiaAllService.FindDiagnosByName(cmdDiagnosisBio.SelectedIndex, TypeResearch.Category1);
					
					if (rdoTimeSys.Checked)
					{
						transaction = new Transaction(org, TypeResearch.Category1, dia, description);
					}
					if (rdoTimeChoice.Checked)
					{
						transaction = new Transaction(org, TypeResearch.Category1, dia, description, recordDate);
					}


				}
				if (boolBioCat2)
				{
					Diagnosis dia = DiaAllService.FindDiagnosByName(cmdDiagnosisBio.SelectedIndex, TypeResearch.Category2);
					
					if (rdoTimeSys.Checked)
					{
						transaction = new Transaction(org, TypeResearch.Category2, dia, description);
					}
					if (rdoTimeChoice.Checked)
					{
						transaction = new Transaction(org, TypeResearch.Category2, dia, description, recordDate);
					}
				}
				if (boolBioCat3)
				{
					Diagnosis dia = DiaAllService.FindDiagnosByName(cmdDiagnosisBio.SelectedIndex, TypeResearch.Category3);
					
					if (rdoTimeSys.Checked)
					{
						transaction = new Transaction(org, TypeResearch.Category3, dia, description);
					}
					if (rdoTimeChoice.Checked)
					{
						transaction = new Transaction(org, TypeResearch.Category3, dia, description, recordDate);
					}
				}
				if(txtInputID.Text != "")
				{
					try
					{
						transaction.SetId(Int16.Parse(txtInputID.Text));
						txtInputID.Text = "";
					}
					catch (Exception ex) { }
				}
				traService.AddTransaction(transaction);
				traService.SaveTransaction();

				showTransaction();
			}
		}

		private void butSpendLittle_Click(object sender, EventArgs e)
		{
			DateTime recordDate = dateCalendar.Value;

			if (cmbOrganization.SelectedIndex != -1 && cmdDiagnosisLitt.SelectedIndex != -1)
			{
				string description = txtDescription.Text;
				Organization org = OrgServise.FindByIndex(cmbOrganization.SelectedIndex);
				Diagnosis dia = DiaAllService.FindDiagnosByName(cmdDiagnosisLitt.SelectedIndex, TypeResearch.LittleOperation);

				Transaction transaction = new Transaction();

				if (rdoTimeSys.Checked)
				{
					transaction = new Transaction(org, TypeResearch.LittleOperation, dia, description);
				}
				if (rdoTimeChoice.Checked)
				{
					transaction = new Transaction(org, TypeResearch.LittleOperation, dia, description, recordDate);
				}

				if (txtInputID.Text != "")
				{
					try
					{
						transaction.SetId(Int16.Parse(txtInputID.Text));
						txtInputID.Text = "";
					}
					catch (Exception ex) { }
				}

				traService.AddTransaction(transaction);
				traService.SaveTransaction();

				showTransaction();

			}
		}

		private void butSpendBig_Click(object sender, EventArgs e)
		{
			bool boolWithout = rdoWithout.Checked;
			bool boolWith = rdoWith.Checked;
			DateTime recordDate = dateCalendar.Value;

			if (cmbOrganization.SelectedIndex != -1 && cmdDiagnosisBig.SelectedIndex != -1)
			{
				string description = txtDescription.Text;
				Organization org = OrgServise.FindByIndex(cmbOrganization.SelectedIndex);
				Transaction transaction = new Transaction(); ;

				if (boolWithout)
				{
					Diagnosis dia = DiaAllService.FindDiagnosByName(cmdDiagnosisBig.SelectedIndex, TypeResearch.BigOperationWithout);
					if (rdoTimeSys.Checked)
					{
						transaction = new Transaction(org, TypeResearch.BigOperationWithout, dia, description);
					}
					if (rdoTimeChoice.Checked)
					{
						transaction = new Transaction(org, TypeResearch.BigOperationWithout, dia, description, recordDate);
					}
				}
				else
				{
					Diagnosis dia = DiaAllService.FindDiagnosByName(cmdDiagnosisBig.SelectedIndex, TypeResearch.BigOperationWith);
					if (rdoTimeSys.Checked)
					{
						transaction = new Transaction(org, TypeResearch.BigOperationWith, dia, description);
					}
					if (rdoTimeChoice.Checked)
					{
						transaction = new Transaction(org, TypeResearch.BigOperationWith, dia, description, recordDate);
					}
				}

				if (txtInputID.Text != "")
				{
					try
					{
						transaction.SetId(Int16.Parse(txtInputID.Text));
						txtInputID.Text = "";
					}
					catch (Exception ex) { }
				}
				traService.AddTransaction(transaction);
				traService.SaveTransaction();

				showTransaction();

			}
		}

		private void cmbOrganization_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cmbOrganization.SelectedIndex != -1)
			{
				lblCategoryOrg.Text = OrgServise.FindByIndex(cmbOrganization.SelectedIndex).GetCategory().GetName();
			}
			else
			{
				lblCategoryOrg.Text = "";
			}

		}

		private void showTransaction()
		{
			cmdDiagnosisBio.SelectedIndex = -1;
			cmdDiagnosisLitt.SelectedIndex = -1;
			cmdDiagnosisBig.SelectedIndex = -1;

			cmdDiagnosisBio.Text = "Виберіть діагноз";
			cmdDiagnosisLitt.Text = "Виберіть діагноз";
			cmdDiagnosisBig.Text = "Виберіть діагноз";
			txtDescription.Text = "";
			lblCategoryOrg.Text = "";

			txtBResult.Text = "";
			string rezultText = "";
			int lastIndexTransaction = traService.GetTransactions().Count() - 1;
			int stopIndexTransaction = lastIndexTransaction - 50;
			stopIndexTransaction = stopIndexTransaction < 0 ? 0 : stopIndexTransaction;


			for (int i = lastIndexTransaction; i >= stopIndexTransaction; i--)
			{
				try
				{
					Transaction transaction = traService.GetTransactions()[i];
					TypeResearch type = transaction.GetTypeResearch();

					string id = transaction.GetId().ToString();
					string org = transaction.GetOrganization().GetName();
					string cat = transaction.GetOrganization().GetCategory().GetName();
					string typ = DiaAllService.GetTypeResearchString(type);
					string dia = transaction.GetDiagnosis().GetName();
					string price = transaction.GetPrice().ToString();
					string descr = transaction.GetDescription();
					string dat = transaction.GetRecordDate().ToString();

					rezultText += id + ",  - " + dat + "  <" + org + ">  (" + cat + ")  " + typ + "  " + dia + "  " + price + "грн.  " + descr + "\r\n";
				}
				catch (Exception ex) { }
			}
			txtBResult.Text = rezultText;
		}

		private void txtInputID_TextChanged(object sender, EventArgs e)
		{
			if (txtInputID.Text == "")
			{
				txtPrepare.Text = "";
				txtInputPrice.Text = "";
			}
			try
			{
				int id = Int16.Parse(txtInputID.Text);
				Transaction transaction = traService.FindById(id);
				TypeResearch type = transaction.GetTypeResearch();

				string org = transaction.GetOrganization().GetName();
				string cat = transaction.GetOrganization().GetCategory().GetName();
				string typ = DiaAllService.GetTypeResearchString(type);
				string dia = transaction.GetDiagnosis().GetName();
				string price = transaction.GetPrice().ToString();
				string descr = transaction.GetDescription();
				string dat = transaction.GetRecordDate().ToString();
				txtDescription.Text = descr;
				txtInputPrice.Text = price.ToString();
				txtPrepare.Text = id.ToString() + ",  - " + dat + "  <" + org + ">  (" + cat + ")  " + typ + "  " + dia + "  " + price + "грн.  " + descr;
			}
			catch (Exception ex) { }
		}

		private void btnDeleteTransaction_Click(object sender, EventArgs e)
		{
			try
			{
				int id = Int16.Parse(txtInputID.Text);
			traService.DeleteById(id);
			traService.SaveTransaction();
			showTransaction();
			txtPrepare.Text = "";
			txtInputID.Text = "";
			}
			catch (Exception ex) { }
		}

		private void btnChange_Click(object sender, EventArgs e)
		{
			try
			{
				int id = Int16.Parse(txtInputID.Text);
				Transaction transaction = traService.FindById(id);
				double price = GetDigit(txtInputPrice.Text);
				string description = txtDescription.Text;

				transaction.SetPrice(price);
				transaction.SetDescription(description);
				traService.SaveTransaction();
				showTransaction();
				txtPrepare.Text = "";
				txtInputID.Text = "";
			}
			catch (Exception ex) { }
			
		}

		private double GetDigit(string strDigit)
		{
			string handler = strDigit.Replace('.', ',').Trim();
			double digit = 0;
			try
			{
				digit = Double.Parse(handler);
			}
			catch (Exception ex) { }
			return digit;
		}

		private void btnSort_Click(object sender, EventArgs e)
		{
			List<Transaction> transactions = traService.GetTransactions();
			transactions = transactions.OrderBy(o => o.GetId()).ToList();
			traService.SetTransaction(transactions);
			showTransaction();
		}
	}
}
