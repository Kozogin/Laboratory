using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratory
{
	public partial class CreateForm : Form
	{				
		private OrganizationService orgService;
		private CategoryService catService;
		private DiagnosisAllService diaService;
		private SortedSet<string> diagnosisDelete;

		public CreateForm(MainForm f)
		{
			InitializeComponent();
			orgService = new OrganizationService();
			catService = new CategoryService();
			diaService = new DiagnosisAllService();
			diagnosisDelete = new SortedSet<string>();
			//f.BackColor = Color.Yellow;
		}

		private void CreateForm_Activated(object sender, EventArgs e)
		{
			try
			{
				catService.ReadCategory();
			}
			catch (Exception ex) { }

			ShowCategory();
			
			try
			{
				diaService.ReadDiagnosis();
			}
			catch (Exception ex) { }

			try
			{
				orgService.ReadOrganization();
			}
			catch (Exception ex) { }

			ShowOrganization();
		}

		private void btnCreateOrg_Click(object sender, EventArgs e)
		{
			string organizationEnter = txtBCreateOrg.Text.Trim();
			int cmbIndex = cmbChoiseCatOrg.SelectedIndex;

			if (organizationEnter != "" && cmbIndex != -1)
			{			
				orgService.AddOrganization(organizationEnter, catService.FindByIndex(cmbIndex));
				orgService.SaveOrganization();
				lblCrOrgDown.Text = organizationEnter;
				txtBCreateOrg.Text = "";
			}
			else
			{
				lblCrOrgDown.Text = "Виберіть категорію";
			}
			
			ShowOrganization();
		}			

		private void btnCreateCategory_Click(object sender, EventArgs e)
		{			
			
			if (txtBCreateCat.Text.Trim() != "") {
				catService.AddCategory(txtBCreateCat.Text.Trim());
				catService.SaveCategory();
			}
			lblCrCat.Text = txtBCreateCat.Text.Trim();
			txtBCreateCat.Text = "";			

			ShowCategory();

		}

		private void btnCreateDiagnosis_Click(object sender, EventArgs e)
		{
			
			string diagnosEnter = txtBCreateDiagnosis.Text.Trim();
			bool bio = chkBiopsy.Checked;
			bool little = chkLittle.Checked;
			bool big = chkBig.Checked; 

			if (diagnosEnter != "")
			{
				diaService.AddDiagnosis(diagnosEnter, bio, little, big);
				diaService.SaveDiagnosis();
			}
			lblCrDiagDown.Text = diagnosEnter;
			txtBCreateDiagnosis.Text = "";

			chkBiopsy.Checked = false;
			chkLittle.Checked = false;
			chkBig.Checked = false;
		}

		private void btnDeleteDia_Click(object sender, EventArgs e)
		{
			string diagnosChoice = cmbDeleteDia.Text.Trim();
			bool bio = chkBiopsy.Checked;
			bool little = chkLittle.Checked;
			bool big = chkBig.Checked;
			diaService.DeleteDiagnosis(diagnosChoice, bio, little, big);

			cmbDeleteDia.Text = "Виберіть діагноз для видалення";
			chkBiopsy.Checked = false;
			chkLittle.Checked = false;
			chkBig.Checked = false;
			GetDeleteCheked();
		}

		private void chkBiopsy_CheckedChanged(object sender, EventArgs e)
		{
			GetDeleteCheked();
		}
		private void chkLittle_CheckedChanged(object sender, EventArgs e)
		{
			GetDeleteCheked();
		}
		private void chkBig_CheckedChanged(object sender, EventArgs e)
		{
			GetDeleteCheked();
		}

		private void GetDeleteCheked()
		{
			try { 
			bool bio = chkBiopsy.Checked;
			bool little = chkLittle.Checked;
			bool big = chkBig.Checked;
			diagnosisDelete.Clear();

			if (bio)
			{
				foreach (Diagnosis o in diaService.GetDiagnosisAll().GetDiagnosesBio())
				{
					diagnosisDelete.Add(o.GetName());
				}
			}
			if (little)
			{
				foreach (Diagnosis o in diaService.GetDiagnosisAll().GetDiagnosesLittle())
				{
					diagnosisDelete.Add(o.GetName());
				}
			}
			if (big)
			{
				foreach (Diagnosis o in diaService.GetDiagnosisAll().GetDiagnosesBig())
				{
					diagnosisDelete.Add(o.GetName());
				}
			}

			cmbDeleteDia.Items.Clear();
			foreach (string o in diagnosisDelete)
			{
				cmbDeleteDia.Items.Add(o);
			}
			}
			catch (Exception ex) { }
		}

		private void btnDeleteCat_Click(object sender, EventArgs e)
		{
			string categoryChoice = cmbDeleteCat.Text.Trim();
			catService.DeleteCategory(categoryChoice);
			cmbDeleteCat.Text = "Виберіть категорію для видалення";
			ShowCategory();
		}

		private void btnDeleteOrg_Click(object sender, EventArgs e)
		{
			string organizationChoice = cmbDeleteOrg.Text.Trim();
			orgService.DeleteOrganization(organizationChoice);
			cmbDeleteOrg.Text = "Виберіть організацію для видалення";
			ShowOrganization();
		}

		private void ShowOrganization()
		{
			cmbDeleteOrg.Items.Clear();
			foreach (Organization o in orgService.GetOrganizations())
			{
				cmbDeleteOrg.Items.Add(o.GetName());
			}
		}

		private void ShowCategory()
		{
			cmbChoiseCatOrg.Items.Clear();
			cmbDeleteCat.Items.Clear();

			foreach (Category o in catService.GetCategories())
			{
				cmbChoiseCatOrg.Items.Add(o.GetName());
				cmbDeleteCat.Items.Add(o.GetName());
			}
		}



	}
}
