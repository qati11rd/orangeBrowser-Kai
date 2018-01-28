namespace orangeBrowser_Kai.Forms
{
	partial class Setting
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tabControlSetting = new System.Windows.Forms.TabControl();
			this.tabPageGeneral = new System.Windows.Forms.TabPage();
			this.checkBoxGeneralHideHttp = new System.Windows.Forms.CheckBox();
			this.textBoxGeneralSearchPage = new System.Windows.Forms.TextBox();
			this.labelGeneralSearchPage = new System.Windows.Forms.Label();
			this.textBoxGeneralHomePage = new System.Windows.Forms.TextBox();
			this.labelGeneralHomePage = new System.Windows.Forms.Label();
			this.tabPageNico = new System.Windows.Forms.TabPage();
			this.checkBoxNicoAllowLowMode = new System.Windows.Forms.CheckBox();
			this.buttonShowPassword = new System.Windows.Forms.Button();
			this.textBoxNicoPassword = new System.Windows.Forms.TextBox();
			this.labelNicoPassword = new System.Windows.Forms.Label();
			this.textBoxNicoMail = new System.Windows.Forms.TextBox();
			this.labelNicoMail = new System.Windows.Forms.Label();
			this.tabPageWindow = new System.Windows.Forms.TabPage();
			this.labelWindowOpacityPercent = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.numericUpDownWindowOpacity = new System.Windows.Forms.NumericUpDown();
			this.buttonApply = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonOkay = new System.Windows.Forms.Button();
			this.buttonConfirm = new System.Windows.Forms.Button();
			this.buttonReset = new System.Windows.Forms.Button();
			this.tabControlSetting.SuspendLayout();
			this.tabPageGeneral.SuspendLayout();
			this.tabPageNico.SuspendLayout();
			this.tabPageWindow.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownWindowOpacity)).BeginInit();
			this.SuspendLayout();
			// 
			// tabControlSetting
			// 
			this.tabControlSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControlSetting.Controls.Add(this.tabPageGeneral);
			this.tabControlSetting.Controls.Add(this.tabPageNico);
			this.tabControlSetting.Controls.Add(this.tabPageWindow);
			this.tabControlSetting.Location = new System.Drawing.Point(0, 0);
			this.tabControlSetting.Name = "tabControlSetting";
			this.tabControlSetting.SelectedIndex = 0;
			this.tabControlSetting.Size = new System.Drawing.Size(551, 467);
			this.tabControlSetting.TabIndex = 0;
			// 
			// tabPageGeneral
			// 
			this.tabPageGeneral.Controls.Add(this.checkBoxGeneralHideHttp);
			this.tabPageGeneral.Controls.Add(this.textBoxGeneralSearchPage);
			this.tabPageGeneral.Controls.Add(this.labelGeneralSearchPage);
			this.tabPageGeneral.Controls.Add(this.textBoxGeneralHomePage);
			this.tabPageGeneral.Controls.Add(this.labelGeneralHomePage);
			this.tabPageGeneral.Location = new System.Drawing.Point(4, 22);
			this.tabPageGeneral.Name = "tabPageGeneral";
			this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageGeneral.Size = new System.Drawing.Size(543, 441);
			this.tabPageGeneral.TabIndex = 0;
			this.tabPageGeneral.Text = "General";
			this.tabPageGeneral.UseVisualStyleBackColor = true;
			// 
			// checkBoxGeneralHideHttp
			// 
			this.checkBoxGeneralHideHttp.AutoSize = true;
			this.checkBoxGeneralHideHttp.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.checkBoxGeneralHideHttp.Location = new System.Drawing.Point(11, 73);
			this.checkBoxGeneralHideHttp.Name = "checkBoxGeneralHideHttp";
			this.checkBoxGeneralHideHttp.Size = new System.Drawing.Size(86, 20);
			this.checkBoxGeneralHideHttp.TabIndex = 4;
			this.checkBoxGeneralHideHttp.Tag = "General_HideHttp";
			this.checkBoxGeneralHideHttp.Text = "HideHttp";
			this.checkBoxGeneralHideHttp.UseVisualStyleBackColor = true;
			this.checkBoxGeneralHideHttp.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
			// 
			// textBoxGeneralSearchPage
			// 
			this.textBoxGeneralSearchPage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxGeneralSearchPage.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.textBoxGeneralSearchPage.Location = new System.Drawing.Point(134, 35);
			this.textBoxGeneralSearchPage.Name = "textBoxGeneralSearchPage";
			this.textBoxGeneralSearchPage.Size = new System.Drawing.Size(401, 23);
			this.textBoxGeneralSearchPage.TabIndex = 3;
			this.textBoxGeneralSearchPage.Tag = "General_SearchPage";
			this.textBoxGeneralSearchPage.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
			// 
			// labelGeneralSearchPage
			// 
			this.labelGeneralSearchPage.AutoSize = true;
			this.labelGeneralSearchPage.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.labelGeneralSearchPage.Location = new System.Drawing.Point(8, 38);
			this.labelGeneralSearchPage.Name = "labelGeneralSearchPage";
			this.labelGeneralSearchPage.Size = new System.Drawing.Size(122, 16);
			this.labelGeneralSearchPage.TabIndex = 2;
			this.labelGeneralSearchPage.Text = "SearchPageBase";
			// 
			// textBoxGeneralHomePage
			// 
			this.textBoxGeneralHomePage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxGeneralHomePage.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.textBoxGeneralHomePage.Location = new System.Drawing.Point(134, 6);
			this.textBoxGeneralHomePage.Name = "textBoxGeneralHomePage";
			this.textBoxGeneralHomePage.Size = new System.Drawing.Size(401, 23);
			this.textBoxGeneralHomePage.TabIndex = 1;
			this.textBoxGeneralHomePage.Tag = "General_HomePage";
			this.textBoxGeneralHomePage.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
			// 
			// labelGeneralHomePage
			// 
			this.labelGeneralHomePage.AutoSize = true;
			this.labelGeneralHomePage.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.labelGeneralHomePage.Location = new System.Drawing.Point(8, 9);
			this.labelGeneralHomePage.Name = "labelGeneralHomePage";
			this.labelGeneralHomePage.Size = new System.Drawing.Size(79, 16);
			this.labelGeneralHomePage.TabIndex = 0;
			this.labelGeneralHomePage.Text = "HomePage";
			// 
			// tabPageNico
			// 
			this.tabPageNico.Controls.Add(this.checkBoxNicoAllowLowMode);
			this.tabPageNico.Controls.Add(this.buttonShowPassword);
			this.tabPageNico.Controls.Add(this.textBoxNicoPassword);
			this.tabPageNico.Controls.Add(this.labelNicoPassword);
			this.tabPageNico.Controls.Add(this.textBoxNicoMail);
			this.tabPageNico.Controls.Add(this.labelNicoMail);
			this.tabPageNico.Location = new System.Drawing.Point(4, 22);
			this.tabPageNico.Name = "tabPageNico";
			this.tabPageNico.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageNico.Size = new System.Drawing.Size(543, 441);
			this.tabPageNico.TabIndex = 1;
			this.tabPageNico.Text = "Nico";
			this.tabPageNico.UseVisualStyleBackColor = true;
			// 
			// checkBoxNicoAllowLowMode
			// 
			this.checkBoxNicoAllowLowMode.AutoSize = true;
			this.checkBoxNicoAllowLowMode.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.checkBoxNicoAllowLowMode.Location = new System.Drawing.Point(11, 73);
			this.checkBoxNicoAllowLowMode.Name = "checkBoxNicoAllowLowMode";
			this.checkBoxNicoAllowLowMode.Size = new System.Drawing.Size(124, 20);
			this.checkBoxNicoAllowLowMode.TabIndex = 7;
			this.checkBoxNicoAllowLowMode.Tag = "Nico_AllowLowMode";
			this.checkBoxNicoAllowLowMode.Text = "AllowLowMode";
			this.checkBoxNicoAllowLowMode.UseVisualStyleBackColor = true;
			// 
			// buttonShowPassword
			// 
			this.buttonShowPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonShowPassword.Location = new System.Drawing.Point(460, 35);
			this.buttonShowPassword.Name = "buttonShowPassword";
			this.buttonShowPassword.Size = new System.Drawing.Size(75, 23);
			this.buttonShowPassword.TabIndex = 6;
			this.buttonShowPassword.Text = "Show";
			this.buttonShowPassword.UseVisualStyleBackColor = true;
			this.buttonShowPassword.Click += new System.EventHandler(this.buttonShowPassword_Click);
			// 
			// textBoxNicoPassword
			// 
			this.textBoxNicoPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxNicoPassword.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.textBoxNicoPassword.Location = new System.Drawing.Point(134, 35);
			this.textBoxNicoPassword.Name = "textBoxNicoPassword";
			this.textBoxNicoPassword.PasswordChar = '*';
			this.textBoxNicoPassword.Size = new System.Drawing.Size(320, 23);
			this.textBoxNicoPassword.TabIndex = 5;
			this.textBoxNicoPassword.Tag = "Nico_Password";
			this.textBoxNicoPassword.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
			// 
			// labelNicoPassword
			// 
			this.labelNicoPassword.AutoSize = true;
			this.labelNicoPassword.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.labelNicoPassword.Location = new System.Drawing.Point(8, 38);
			this.labelNicoPassword.Name = "labelNicoPassword";
			this.labelNicoPassword.Size = new System.Drawing.Size(72, 16);
			this.labelNicoPassword.TabIndex = 4;
			this.labelNicoPassword.Tag = "";
			this.labelNicoPassword.Text = "Password";
			// 
			// textBoxNicoMail
			// 
			this.textBoxNicoMail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxNicoMail.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.textBoxNicoMail.Location = new System.Drawing.Point(134, 6);
			this.textBoxNicoMail.Name = "textBoxNicoMail";
			this.textBoxNicoMail.Size = new System.Drawing.Size(401, 23);
			this.textBoxNicoMail.TabIndex = 3;
			this.textBoxNicoMail.Tag = "Nico_Mail";
			this.textBoxNicoMail.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
			// 
			// labelNicoMail
			// 
			this.labelNicoMail.AutoSize = true;
			this.labelNicoMail.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.labelNicoMail.Location = new System.Drawing.Point(8, 9);
			this.labelNicoMail.Name = "labelNicoMail";
			this.labelNicoMail.Size = new System.Drawing.Size(88, 16);
			this.labelNicoMail.TabIndex = 2;
			this.labelNicoMail.Text = "MailAddress";
			// 
			// tabPageWindow
			// 
			this.tabPageWindow.Controls.Add(this.labelWindowOpacityPercent);
			this.tabPageWindow.Controls.Add(this.label1);
			this.tabPageWindow.Controls.Add(this.numericUpDownWindowOpacity);
			this.tabPageWindow.Location = new System.Drawing.Point(4, 22);
			this.tabPageWindow.Name = "tabPageWindow";
			this.tabPageWindow.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageWindow.Size = new System.Drawing.Size(543, 441);
			this.tabPageWindow.TabIndex = 2;
			this.tabPageWindow.Text = "Window";
			this.tabPageWindow.UseVisualStyleBackColor = true;
			// 
			// labelWindowOpacityPercent
			// 
			this.labelWindowOpacityPercent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelWindowOpacityPercent.AutoSize = true;
			this.labelWindowOpacityPercent.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.labelWindowOpacityPercent.Location = new System.Drawing.Point(519, 8);
			this.labelWindowOpacityPercent.Name = "labelWindowOpacityPercent";
			this.labelWindowOpacityPercent.Size = new System.Drawing.Size(16, 16);
			this.labelWindowOpacityPercent.TabIndex = 4;
			this.labelWindowOpacityPercent.Text = "%";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 16);
			this.label1.TabIndex = 3;
			this.label1.Text = "Opacity";
			// 
			// numericUpDownWindowOpacity
			// 
			this.numericUpDownWindowOpacity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.numericUpDownWindowOpacity.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.numericUpDownWindowOpacity.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.numericUpDownWindowOpacity.Location = new System.Drawing.Point(387, 6);
			this.numericUpDownWindowOpacity.Name = "numericUpDownWindowOpacity";
			this.numericUpDownWindowOpacity.Size = new System.Drawing.Size(126, 23);
			this.numericUpDownWindowOpacity.TabIndex = 0;
			this.numericUpDownWindowOpacity.Tag = "Window_Opacity";
			this.numericUpDownWindowOpacity.ValueChanged += new System.EventHandler(this.NumericUpDown_ValueChanged);
			// 
			// buttonApply
			// 
			this.buttonApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonApply.Enabled = false;
			this.buttonApply.Location = new System.Drawing.Point(472, 473);
			this.buttonApply.Name = "buttonApply";
			this.buttonApply.Size = new System.Drawing.Size(75, 23);
			this.buttonApply.TabIndex = 1;
			this.buttonApply.Text = "Apply";
			this.buttonApply.UseVisualStyleBackColor = true;
			this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(391, 473);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 2;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// buttonOkay
			// 
			this.buttonOkay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOkay.Location = new System.Drawing.Point(310, 473);
			this.buttonOkay.Name = "buttonOkay";
			this.buttonOkay.Size = new System.Drawing.Size(75, 23);
			this.buttonOkay.TabIndex = 3;
			this.buttonOkay.Text = "OK";
			this.buttonOkay.UseVisualStyleBackColor = true;
			this.buttonOkay.Click += new System.EventHandler(this.buttonOkay_Click);
			// 
			// buttonConfirm
			// 
			this.buttonConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonConfirm.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonConfirm.Location = new System.Drawing.Point(229, 473);
			this.buttonConfirm.Name = "buttonConfirm";
			this.buttonConfirm.Size = new System.Drawing.Size(75, 23);
			this.buttonConfirm.TabIndex = 4;
			this.buttonConfirm.Text = "Confirm";
			this.buttonConfirm.UseVisualStyleBackColor = true;
			this.buttonConfirm.Visible = false;
			this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
			// 
			// buttonReset
			// 
			this.buttonReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonReset.Location = new System.Drawing.Point(4, 473);
			this.buttonReset.Name = "buttonReset";
			this.buttonReset.Size = new System.Drawing.Size(75, 23);
			this.buttonReset.TabIndex = 5;
			this.buttonReset.Text = "Reset";
			this.buttonReset.UseVisualStyleBackColor = true;
			this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
			// 
			// Setting
			// 
			this.AcceptButton = this.buttonOkay;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(551, 508);
			this.Controls.Add(this.buttonReset);
			this.Controls.Add(this.buttonConfirm);
			this.Controls.Add(this.buttonOkay);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonApply);
			this.Controls.Add(this.tabControlSetting);
			this.Name = "Setting";
			this.Text = "Setting";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Setting_FormClosing);
			this.tabControlSetting.ResumeLayout(false);
			this.tabPageGeneral.ResumeLayout(false);
			this.tabPageGeneral.PerformLayout();
			this.tabPageNico.ResumeLayout(false);
			this.tabPageNico.PerformLayout();
			this.tabPageWindow.ResumeLayout(false);
			this.tabPageWindow.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownWindowOpacity)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControlSetting;
		private System.Windows.Forms.TabPage tabPageGeneral;
		private System.Windows.Forms.TabPage tabPageNico;
		private System.Windows.Forms.TextBox textBoxGeneralHomePage;
		private System.Windows.Forms.Label labelGeneralHomePage;
		private System.Windows.Forms.Button buttonApply;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonOkay;
		private System.Windows.Forms.Button buttonConfirm;
		private System.Windows.Forms.Button buttonReset;
		private System.Windows.Forms.TextBox textBoxGeneralSearchPage;
		private System.Windows.Forms.Label labelGeneralSearchPage;
		private System.Windows.Forms.TextBox textBoxNicoMail;
		private System.Windows.Forms.Label labelNicoMail;
		private System.Windows.Forms.CheckBox checkBoxGeneralHideHttp;
		private System.Windows.Forms.TextBox textBoxNicoPassword;
		private System.Windows.Forms.Label labelNicoPassword;
		private System.Windows.Forms.Button buttonShowPassword;
		private System.Windows.Forms.CheckBox checkBoxNicoAllowLowMode;
		private System.Windows.Forms.TabPage tabPageWindow;
		private System.Windows.Forms.NumericUpDown numericUpDownWindowOpacity;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label labelWindowOpacityPercent;
	}
}