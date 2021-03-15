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
	public partial class CreateForm : Form
	{

		//private Organization Org;
		private OrganizationService orgService;
			   		

		public CreateForm(MainForm f)
		{
			InitializeComponent();
			orgService = new OrganizationService();
			//f.BackColor = Color.Yellow;
		}

		private void CreateForm_Load(object sender, EventArgs e)
		{

		}

		private void btnCreateOrg_Click(object sender, EventArgs e)
		{
			try
			{
				orgService.ReadOrganization();
			} catch(Exception ex) { }


			/*if (orgService.GetFileIsPresent())
			{

			}*/
			orgService.AddOrganization(txtBCreateOrg.Text);
			orgService.SaveOrganization();

		}

		private void txtBCreateOrg_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
