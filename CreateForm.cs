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
		

		public CreateForm(MainForm f)
		{
			InitializeComponent();
			orgService = new OrganizationService();
			catService = new CategoryService();
			diaService = new DiagnosisAllService();
			//f.BackColor = Color.Yellow;
		}

		private void CreateForm_Activated(object sender, EventArgs e)
		{
			try
			{
				catService.ReadCategory();
			}
			catch (Exception ex) { }			

			cmbChoiseCatOrg.Items.Clear();

			List<Category> categoryShow = catService.GetCategories();

			foreach (Category o in categoryShow)
			{
				cmbChoiseCatOrg.Items.Add(o.GetName());
			}
		}

		private void btnCreateOrg_Click(object sender, EventArgs e)
		{
			try
			{
				orgService.ReadOrganization();

			} catch(Exception ex) { }

			if (txtBCreateOrg.Text.Trim() != "")
			{			
				orgService.AddOrganization(txtBCreateOrg.Text.Trim(), catService.FindByIndex(cmbChoiseCatOrg.SelectedIndex));
				orgService.SaveOrganization();
			}
			lblCrOrgDown.Text = txtBCreateOrg.Text.Trim();
			txtBCreateOrg.Text = "";

		}			

		private void btnCreateCategory_Click(object sender, EventArgs e)
		{
			try
			{
				catService.ReadCategory();
			}
			catch (Exception ex) { }
			
			if (txtBCreateCat.Text.Trim() != "") {
				catService.AddCategory(txtBCreateCat.Text.Trim());
				catService.SaveCategory();
			}
			lblCrCat.Text = txtBCreateCat.Text.Trim();
			txtBCreateCat.Text = "";

			cmbChoiseCatOrg.Items.Clear();

			List<Category> categoryShow = catService.GetCategories();

			foreach (Category o in categoryShow)
			{
					cmbChoiseCatOrg.Items.Add(o.GetName());
			}

		}

		private void btnCreateDiagnosis_Click(object sender, EventArgs e)
		{
			try
			{
				diaService.ReadDiagnosis();

			}
			catch (Exception ex) { }

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
		}
	}
}
