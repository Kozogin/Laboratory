namespace Laboratory
{
	partial class MainForm
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.butAdd = new System.Windows.Forms.Button();
			this.cmbOrganization = new System.Windows.Forms.ComboBox();
			this.cmdDiagnosisBig = new System.Windows.Forms.ComboBox();
			this.cmdDiagnosisLitt = new System.Windows.Forms.ComboBox();
			this.butSpendBio = new System.Windows.Forms.Button();
			this.txtBResult = new System.Windows.Forms.TextBox();
			this.txtBPrepare = new System.Windows.Forms.TextBox();
			this.dataSet1 = new System.Data.DataSet();
			this.dateCalendar = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.rdoCategory1 = new System.Windows.Forms.RadioButton();
			this.rdoCategory2 = new System.Windows.Forms.RadioButton();
			this.rdoCategory3 = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.rdoWith = new System.Windows.Forms.RadioButton();
			this.rdoWithout = new System.Windows.Forms.RadioButton();
			this.butSpendLittle = new System.Windows.Forms.Button();
			this.butSpendBig = new System.Windows.Forms.Button();
			this.btnSetting = new System.Windows.Forms.Button();
			this.cmdDiagnosisBio = new System.Windows.Forms.ComboBox();
			this.lblCategoryOrg = new System.Windows.Forms.Label();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// butAdd
			// 
			resources.ApplyResources(this.butAdd, "butAdd");
			this.butAdd.Name = "butAdd";
			this.butAdd.UseVisualStyleBackColor = true;
			this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
			// 
			// cmbOrganization
			// 
			this.cmbOrganization.FormattingEnabled = true;
			resources.ApplyResources(this.cmbOrganization, "cmbOrganization");
			this.cmbOrganization.Name = "cmbOrganization";
			this.cmbOrganization.SelectedIndexChanged += new System.EventHandler(this.cmbOrganization_SelectedIndexChanged);
			// 
			// cmdDiagnosisBig
			// 
			this.cmdDiagnosisBig.FormattingEnabled = true;
			resources.ApplyResources(this.cmdDiagnosisBig, "cmdDiagnosisBig");
			this.cmdDiagnosisBig.Name = "cmdDiagnosisBig";
			// 
			// cmdDiagnosisLitt
			// 
			this.cmdDiagnosisLitt.FormattingEnabled = true;
			resources.ApplyResources(this.cmdDiagnosisLitt, "cmdDiagnosisLitt");
			this.cmdDiagnosisLitt.Name = "cmdDiagnosisLitt";
			// 
			// butSpendBio
			// 
			resources.ApplyResources(this.butSpendBio, "butSpendBio");
			this.butSpendBio.Name = "butSpendBio";
			this.butSpendBio.UseVisualStyleBackColor = true;
			// 
			// txtBResult
			// 
			resources.ApplyResources(this.txtBResult, "txtBResult");
			this.txtBResult.Name = "txtBResult";
			// 
			// txtBPrepare
			// 
			resources.ApplyResources(this.txtBPrepare, "txtBPrepare");
			this.txtBPrepare.Name = "txtBPrepare";
			// 
			// dataSet1
			// 
			this.dataSet1.DataSetName = "NewDataSet";
			// 
			// dateCalendar
			// 
			resources.ApplyResources(this.dateCalendar, "dateCalendar");
			this.dateCalendar.Name = "dateCalendar";
			this.dateCalendar.Value = new System.DateTime(2021, 3, 14, 4, 0, 0, 0);
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// label2
			// 
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			// 
			// label3
			// 
			resources.ApplyResources(this.label3, "label3");
			this.label3.Name = "label3";
			// 
			// rdoCategory1
			// 
			resources.ApplyResources(this.rdoCategory1, "rdoCategory1");
			this.rdoCategory1.Checked = true;
			this.rdoCategory1.Name = "rdoCategory1";
			this.rdoCategory1.TabStop = true;
			this.rdoCategory1.UseVisualStyleBackColor = true;
			// 
			// rdoCategory2
			// 
			resources.ApplyResources(this.rdoCategory2, "rdoCategory2");
			this.rdoCategory2.Name = "rdoCategory2";
			this.rdoCategory2.UseVisualStyleBackColor = true;
			// 
			// rdoCategory3
			// 
			resources.ApplyResources(this.rdoCategory3, "rdoCategory3");
			this.rdoCategory3.Name = "rdoCategory3";
			this.rdoCategory3.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.rdoCategory1);
			this.groupBox1.Controls.Add(this.rdoCategory3);
			this.groupBox1.Controls.Add(this.rdoCategory2);
			resources.ApplyResources(this.groupBox1, "groupBox1");
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.TabStop = false;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.rdoWith);
			this.groupBox2.Controls.Add(this.rdoWithout);
			resources.ApplyResources(this.groupBox2, "groupBox2");
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.TabStop = false;
			// 
			// rdoWith
			// 
			resources.ApplyResources(this.rdoWith, "rdoWith");
			this.rdoWith.Name = "rdoWith";
			this.rdoWith.UseVisualStyleBackColor = true;
			// 
			// rdoWithout
			// 
			resources.ApplyResources(this.rdoWithout, "rdoWithout");
			this.rdoWithout.Checked = true;
			this.rdoWithout.Name = "rdoWithout";
			this.rdoWithout.TabStop = true;
			this.rdoWithout.UseVisualStyleBackColor = true;
			// 
			// butSpendLittle
			// 
			resources.ApplyResources(this.butSpendLittle, "butSpendLittle");
			this.butSpendLittle.Name = "butSpendLittle";
			this.butSpendLittle.UseVisualStyleBackColor = true;
			this.butSpendLittle.Click += new System.EventHandler(this.butSpendLittle_Click);
			// 
			// butSpendBig
			// 
			resources.ApplyResources(this.butSpendBig, "butSpendBig");
			this.butSpendBig.Name = "butSpendBig";
			this.butSpendBig.UseVisualStyleBackColor = true;
			// 
			// btnSetting
			// 
			resources.ApplyResources(this.btnSetting, "btnSetting");
			this.btnSetting.Name = "btnSetting";
			this.btnSetting.UseVisualStyleBackColor = true;
			this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
			// 
			// cmdDiagnosisBio
			// 
			this.cmdDiagnosisBio.FormattingEnabled = true;
			resources.ApplyResources(this.cmdDiagnosisBio, "cmdDiagnosisBio");
			this.cmdDiagnosisBio.Name = "cmdDiagnosisBio";
			// 
			// lblCategoryOrg
			// 
			resources.ApplyResources(this.lblCategoryOrg, "lblCategoryOrg");
			this.lblCategoryOrg.Name = "lblCategoryOrg";
			// 
			// txtDescription
			// 
			resources.ApplyResources(this.txtDescription, "txtDescription");
			this.txtDescription.Name = "txtDescription";
			// 
			// label4
			// 
			resources.ApplyResources(this.label4, "label4");
			this.label4.Name = "label4";
			// 
			// MainForm
			// 
			resources.ApplyResources(this, "$this");
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtDescription);
			this.Controls.Add(this.lblCategoryOrg);
			this.Controls.Add(this.cmdDiagnosisBio);
			this.Controls.Add(this.btnSetting);
			this.Controls.Add(this.butSpendBig);
			this.Controls.Add(this.butSpendLittle);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dateCalendar);
			this.Controls.Add(this.txtBPrepare);
			this.Controls.Add(this.txtBResult);
			this.Controls.Add(this.butSpendBio);
			this.Controls.Add(this.cmdDiagnosisLitt);
			this.Controls.Add(this.cmdDiagnosisBig);
			this.Controls.Add(this.cmbOrganization);
			this.Controls.Add(this.butAdd);
			this.Name = "MainForm";
			this.Activated += new System.EventHandler(this.MainForm_Activated);
			this.Load += new System.EventHandler(this.MainForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}



		#endregion

		private System.Windows.Forms.Button butAdd;
		private System.Windows.Forms.ComboBox cmbOrganization;
		private System.Windows.Forms.ComboBox cmdDiagnosisBig;
		private System.Windows.Forms.ComboBox cmdDiagnosisLitt;
		private System.Windows.Forms.Button butSpendBio;
		private System.Windows.Forms.TextBox txtBResult;
		private System.Windows.Forms.TextBox txtBPrepare;
		private System.Data.DataSet dataSet1;
		private System.Windows.Forms.DateTimePicker dateCalendar;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.RadioButton rdoCategory1;
		private System.Windows.Forms.RadioButton rdoCategory2;
		private System.Windows.Forms.RadioButton rdoCategory3;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton rdoWith;
		private System.Windows.Forms.RadioButton rdoWithout;
		private System.Windows.Forms.Button butSpendLittle;
		private System.Windows.Forms.Button butSpendBig;
		private System.Windows.Forms.Button btnSetting;
		private System.Windows.Forms.ComboBox cmdDiagnosisBio;
		private System.Windows.Forms.Label lblCategoryOrg;
		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.Label label4;
	}
}

