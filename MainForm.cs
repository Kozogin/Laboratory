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

		//private List<Organization> organizationsShow;

		public MainForm()
		{
			InitializeComponent();
			OrgServise = new OrganizationService();
			DiaAllService = new DiagnosisAllService();
		}

		public MainForm(CreateForm f)
		{
			InitializeComponent();
			OrgServise = new OrganizationService();
			DiaAllService = new DiagnosisAllService();
			//f.BackColor = Color.Green;
		}

		private void cmbOrganization_SelectedIndexChanged(object sender, EventArgs e)
		{
			OrgServise.ReadOrganization();
			lblCategoryOrg.Text = OrgServise.FindByIndex(cmbOrganization.SelectedIndex).GetCategory().GetName();		

		}

		private void cmdCategory_SelectedIndexChanged(object sender, EventArgs e)
		{
			txtBPrepare.Text = cmbOrganization.Text + "  ---  (" + cmdDiagnosisBig.Text + ")    " + cmdDiagnosisLitt.Text
				+ "     - " + " грн. " + "       " + DateTime.Now;
		}

		private void cmdDiagnosis_SelectedIndexChanged(object sender, EventArgs e)
		{
			txtBPrepare.Text = cmbOrganization.Text + "  ---  (" + cmdDiagnosisBig.Text + ")    " + cmdDiagnosisLitt.Text
				+ "     - " + " грн. " + "       " + DateTime.Now + "   " + dateCalendar.Value;
		}

		private void butSpend_Click(object sender, EventArgs e)
		{
			if (txtBPrepare.Text != "") { 
			txtBResult.Text += txtBPrepare.Text + "\r" + "\n";
			}
			txtBPrepare.Text = "";
		}

		private void txtBResult_TextChanged(object sender, EventArgs e)
		{

		}

		private void txtBPrepare_TextChanged(object sender, EventArgs e)
		{
			dateCalendar.Value = DateTime.Now;
		}

		private void butAdd_Click(object sender, EventArgs e)
		{			
			CreateForm createForm = new CreateForm(this);
			createForm.Show();

		}

		private void dateCalendar_ValueChanged(object sender, EventArgs e)
		{

		}

		private void MainForm_Activated(object sender, EventArgs e)
		{
			dateCalendar.Value = DateTime.Now;

			OrgServise.ReadOrganization();
			cmbOrganization.Items.Clear();
			foreach (Organization o in OrgServise.GetOrganizations())
			{
				cmbOrganization.Items.Add(o.GetName());
			}

			DiagnosisAll diaAll = DiaAllService.ReadDiagnosis();
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


		}

		private void MainForm_Load(object sender, EventArgs e)
		{

		}

		private void btnSetting_Click(object sender, EventArgs e)
		{
			SettingForm settingForm = new SettingForm(this);
			settingForm.Show();
		}

		private void cmdDiagnosisBio_SelectedIndexChanged(object sender, EventArgs e)
		{

		}
	}
	
}
