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
	public partial class SettingForm : Form
	{
		private CategoryService CatService;
		private SettingLabService SetService;

		public SettingForm()
		{
			InitializeComponent();
			CatService = new CategoryService();
			SetService = new SettingLabService();
		}

		public SettingForm(MainForm f)
		{
			InitializeComponent();
			CatService = new CategoryService();
			SetService = new SettingLabService();
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

		private void Save_Click(object sender, EventArgs e)
		{			
			double p1 = 0;
			double p2 = 0;
			double p3 = 0;
			double p4 = 0;
			double p5 = 0;
			double p6 = 0;
			
			p1 = GetDigit(txtCategory1.Text);
			p2 = GetDigit(txtCategory2.Text);
			p3 = GetDigit(txtCategory3.Text);
			p4 = GetDigit(txtLittle.Text);
			p5 = GetDigit(txtBigWithout.Text);
			p6 = GetDigit(txtWith.Text);
			
			SetService.AddSettingLab(new SettingLab(CatService.FindByIndex(cmbCategoryOrg.SelectedIndex), p1, p2, p3, p4, p5, p6));
			SetService.SaveSettingLab();
			ShowSetting();
		}

		private void SettingForm_Activated(object sender, EventArgs e)
		{			
			try
			{
				CatService.ReadCategory();
			}
			catch (Exception ex) { }
			try
			{
				SetService.ReadSettingLab();
			}
			catch (Exception ex) { }

			cmbCategoryOrg.Items.Clear();

			foreach (Category o in CatService.GetCategories())
			{
				cmbCategoryOrg.Items.Add(o.GetName());
			}
		}

		private void cmbCategoryOrg_SelectedIndexChanged(object sender, EventArgs e)
		{
			ShowSetting();
		}		

		public void ShowSetting()
		{
			txtCategory1.Text = "";
			txtCategory2.Text = "";
			txtCategory3.Text = "";

			txtLittle.Text = "";
			txtBigWithout.Text = "";
			txtWith.Text = "";

			txtCategory1.Text = SetService.FindByCategory(cmbCategoryOrg.SelectedItem.ToString()).GetCategory1().ToString();
			txtCategory2.Text = SetService.FindByCategory(cmbCategoryOrg.SelectedItem.ToString()).GetCategory2().ToString();
			txtCategory3.Text = SetService.FindByCategory(cmbCategoryOrg.SelectedItem.ToString()).GetCategory3().ToString();

			txtLittle.Text = SetService.FindByCategory(cmbCategoryOrg.SelectedItem.ToString()).GetLittleOperation().ToString();
			txtBigWithout.Text = SetService.FindByCategory(cmbCategoryOrg.SelectedItem.ToString()).GetBigOperationWithout().ToString();
			txtWith.Text = SetService.FindByCategory(cmbCategoryOrg.SelectedItem.ToString()).GetBigOperationWith().ToString();

		}


	}
}
