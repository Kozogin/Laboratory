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
	//public Organization Orgs { get; set; };

	public partial class MainForm : Form
	{

		private Organization Org;
		private Category C;
		private Diagnosis D;

		private List<Organization> organizationsShow;

		public MainForm()
		{
			InitializeComponent();

			C = new Category("Policlinic 2");
			D = new Diagnosis("Coronavirus 19", 945.75, C);

			BinaryFormatter formatter = new BinaryFormatter();
			
			using (FileStream fs = new FileStream("organization.dat", FileMode.OpenOrCreate))
			{
				try
				{
					organizationsShow = (List<Organization>)formatter.Deserialize(fs);

					foreach (Organization o in organizationsShow)
					{
						cmbOrganization.Items.Add(o.Name);
					}

				} catch (Exception ex)
				{

				}
			}



			cmbOrganization.Items.Add("ОКЛ");
			cmbOrganization.Items.Add("Дитяча");
			cmbOrganization.Items.Add("КДЦ");

			if (Org != null) {
				cmbOrganization.Items.Add(Org.Name);
			}

			cmdCategory.Items.Add("всі");
			cmdCategory.Items.Add("експрес");
			cmdCategory.Items.Add("органи травлення");
			cmdCategory.Items.Add("серцево-судинні");

			cmdDiagnosis.Items.Add("туберкульоз");
			cmdDiagnosis.Items.Add(D.Name);
			cmdDiagnosis.Items.Add("ангіна");
		}

		public MainForm(CreateForm f)
		{
			InitializeComponent();
			//f.BackColor = Color.Green;
		}

		private void cmbOrganization_SelectedIndexChanged(object sender, EventArgs e)
		{
			txtBPrepare.Text = cmbOrganization.Text + "  ---  (" + cmdCategory.Text + ")    " + cmdDiagnosis.Text
				+ "     - " + D.Price + " грн. " + "       " + DateTime.Now;
		}

		private void cmdCategory_SelectedIndexChanged(object sender, EventArgs e)
		{
			txtBPrepare.Text = cmbOrganization.Text + "  ---  (" + cmdCategory.Text + ")    " + cmdDiagnosis.Text
				+ "     - " + D.Price + " грн. " + "       " + DateTime.Now;
		}

		private void cmdDiagnosis_SelectedIndexChanged(object sender, EventArgs e)
		{
			txtBPrepare.Text = cmbOrganization.Text + "  ---  (" + cmdCategory.Text + ")    " + cmdDiagnosis.Text
				+ "     - " + D.Price + " грн. " + "       " + DateTime.Now + "   " + dateCalendar.Value;
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
			CreateForm newForm = new CreateForm(this);
			newForm.Show();

		}

		private void dateCalendar_ValueChanged(object sender, EventArgs e)
		{

		}
	
		

		
	}
	
}
