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
			this.cmdCategory = new System.Windows.Forms.ComboBox();
			this.cmdDiagnosis = new System.Windows.Forms.ComboBox();
			this.butSpend = new System.Windows.Forms.Button();
			this.txtBResult = new System.Windows.Forms.TextBox();
			this.txtBPrepare = new System.Windows.Forms.TextBox();
			this.dataSet1 = new System.Data.DataSet();
			this.dateCalendar = new System.Windows.Forms.DateTimePicker();
			((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
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
			// cmdCategory
			// 
			this.cmdCategory.FormattingEnabled = true;
			resources.ApplyResources(this.cmdCategory, "cmdCategory");
			this.cmdCategory.Name = "cmdCategory";
			this.cmdCategory.SelectedIndexChanged += new System.EventHandler(this.cmdCategory_SelectedIndexChanged);
			// 
			// cmdDiagnosis
			// 
			this.cmdDiagnosis.FormattingEnabled = true;
			resources.ApplyResources(this.cmdDiagnosis, "cmdDiagnosis");
			this.cmdDiagnosis.Name = "cmdDiagnosis";
			this.cmdDiagnosis.SelectedIndexChanged += new System.EventHandler(this.cmdDiagnosis_SelectedIndexChanged);
			// 
			// butSpend
			// 
			resources.ApplyResources(this.butSpend, "butSpend");
			this.butSpend.Name = "butSpend";
			this.butSpend.UseVisualStyleBackColor = true;
			this.butSpend.Click += new System.EventHandler(this.butSpend_Click);
			// 
			// txtBResult
			// 
			resources.ApplyResources(this.txtBResult, "txtBResult");
			this.txtBResult.Name = "txtBResult";
			this.txtBResult.TextChanged += new System.EventHandler(this.txtBResult_TextChanged);
			// 
			// txtBPrepare
			// 
			resources.ApplyResources(this.txtBPrepare, "txtBPrepare");
			this.txtBPrepare.Name = "txtBPrepare";
			this.txtBPrepare.TextChanged += new System.EventHandler(this.txtBPrepare_TextChanged);
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
			this.dateCalendar.ValueChanged += new System.EventHandler(this.dateCalendar_ValueChanged);
			// 
			// MainForm
			// 
			resources.ApplyResources(this, "$this");
			this.Controls.Add(this.dateCalendar);
			this.Controls.Add(this.txtBPrepare);
			this.Controls.Add(this.txtBResult);
			this.Controls.Add(this.butSpend);
			this.Controls.Add(this.cmdDiagnosis);
			this.Controls.Add(this.cmdCategory);
			this.Controls.Add(this.cmbOrganization);
			this.Controls.Add(this.butAdd);
			this.Name = "MainForm";
			
			this.ResumeLayout(false);
			this.PerformLayout();

		}



		#endregion

		private System.Windows.Forms.Button butAdd;
		private System.Windows.Forms.ComboBox cmbOrganization;
		private System.Windows.Forms.ComboBox cmdCategory;
		private System.Windows.Forms.ComboBox cmdDiagnosis;
		private System.Windows.Forms.Button butSpend;
		private System.Windows.Forms.TextBox txtBResult;
		private System.Windows.Forms.TextBox txtBPrepare;
		private System.Data.DataSet dataSet1;
		private System.Windows.Forms.DateTimePicker dateCalendar;
	}
}

